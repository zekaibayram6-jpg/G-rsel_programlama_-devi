using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PorscheDealership
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            lblWelcome.Text = $"Hoşgeldin, {currentUser.FullName}";
            if (currentUser.IsAdmin)
            {
                btnAdminPanel.Visible = true;
            }
            LoadData();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabActiveOrders) LoadActiveOrders();
            else if (tabControl.SelectedTab == tabPastOrders) LoadPastOrders();
            else if (tabControl.SelectedTab == tabCatalog) LoadCatalog();
        }

        private void BtnAdminPanel_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
            LoadData(); // Reload data after admin closes panel (stock might have changed)
        }

        private void LoadData()
        {
            LoadCatalog();
            LoadActiveOrders();
            LoadPastOrders();
        }

        private void LoadCatalog()
        {
            flowCatalog.Controls.Clear();
            try
            {
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Model, Year, Price, OTV, KDV, Stock, ImagePath FROM Cars";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var car = new Car
                            {
                                Id = reader.GetInt32(0),
                                Model = reader.GetString(1),
                                Year = reader.GetInt32(2),
                                Price = reader.GetDecimal(3),
                                OTV = reader.GetDecimal(4),
                                KDV = reader.GetDecimal(5),
                                Stock = reader.GetInt32(6),
                                ImagePath = reader.IsDBNull(7) ? null : reader.GetString(7)
                            };

                            Panel pnl = new Panel() { Width = 280, Height = 320, BackColor = Color.FromArgb(50, 50, 50), Margin = new Padding(10) };
                            
                            if (!string.IsNullOrEmpty(car.ImagePath) && File.Exists(car.ImagePath))
                            {
                                PictureBox pic = new PictureBox() { Width = 260, Height = 140, Top = 10, Left = 10, SizeMode = PictureBoxSizeMode.Zoom, Image = Image.FromFile(car.ImagePath) };
                                pnl.Controls.Add(pic);
                            }
                            else
                            {
                                Label lblImg = new Label() { Text = "Resim Yok", AutoSize = false, Width = 260, Height = 140, Top = 10, Left = 10, BackColor = Color.Black, ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter };
                                pnl.Controls.Add(lblImg);
                            }

                            Label lblModel = new Label() { Text = $"{car.Model} ({car.Year})", Font = new Font("Arial", 12, FontStyle.Bold), Top = 160, Left = 10, Width = 260, ForeColor = Color.White };
                            pnl.Controls.Add(lblModel);

                            decimal finalPrice = car.CalculateTotalPrice();
                            Label lblPrice = new Label() { Text = $"Fiyat: {finalPrice:C0}\n(ÖTV %{car.OTV*100}, KDV %{car.KDV*100})", Top = 190, Left = 10, Width = 260, Height = 40, ForeColor = Color.LightGreen };
                            pnl.Controls.Add(lblPrice);

                            Label lblStock = new Label() { Text = $"Stok: {car.Stock}", Top = 240, Left = 10, Width = 260, ForeColor = car.Stock > 0 ? Color.Orange : Color.Red };
                            pnl.Controls.Add(lblStock);

                            Button btnBuy = new Button() { Top = 270, Left = 10, Width = 260, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                            btnBuy.FlatAppearance.BorderSize = 0;
                            
                            if (car.Stock > 0)
                            {
                                btnBuy.Text = "Satın Al";
                                btnBuy.BackColor = Color.DarkRed;
                                btnBuy.Click += (s, e) => BuyCar(car, finalPrice);
                            }
                            else
                            {
                                btnBuy.Text = "Stok Bitti";
                                btnBuy.BackColor = Color.Gray;
                                btnBuy.Enabled = false;
                            }
                            
                            // Eğer giriş yapan kişi admin ise "Satın Al" veya "Stok Bitti" butonu hiç görünmesin
                            if (currentUser.IsAdmin)
                            {
                                btnBuy.Visible = false;
                            }

                            pnl.Controls.Add(btnBuy);

                            flowCatalog.Controls.Add(pnl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Katalog yüklenirken hata: " + ex.Message);
            }
        }

        private void BuyCar(Car car, decimal finalPrice)
        {
            var result = MessageBox.Show($"{car.Model} aracını {finalPrice:C0} fiyatına satın almak istediğinize emin misiniz?", "Satın Alma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string updateStock = "UPDATE Cars SET Stock = Stock - 1 WHERE Id = @id AND Stock > 0";
                                using (var cmd = new SqlCommand(updateStock, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", car.Id);
                                    int rows = cmd.ExecuteNonQuery();
                                    if (rows == 0)
                                    {
                                        MessageBox.Show("Üzgünüz, stok yetersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        transaction.Rollback();
                                        return;
                                    }
                                }

                                string insertOrder = "INSERT INTO Orders (UserId, CarId, TotalPrice, OrderDate, Status) VALUES (@uid, @cid, @price, @date, 'Bekliyor')";
                                using (var cmd = new SqlCommand(insertOrder, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@uid", currentUser.Id);
                                    cmd.Parameters.AddWithValue("@cid", car.Id);
                                    cmd.Parameters.AddWithValue("@price", finalPrice);
                                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Siparişiniz başarıyla alındı. Aktif siparişlerim sekmesinden takip edebilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                LoadCatalog();
                                LoadActiveOrders();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Satın alma sırasında hata: " + ex.Message);
                }
            }
        }

        private void LoadActiveOrders()
        {
            LoadOrdersToGrid("Bekliyor", dgvActiveOrders);
        }

        private void LoadPastOrders()
        {
            LoadOrdersToGrid("Teslim Edildi", dgvPastOrders);
        }

        private void LoadOrdersToGrid(string status, DataGridView dgv)
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT o.Id as [Sipariş No], c.Model as [Araç Modeli], o.TotalPrice as [Toplam Fiyat], o.OrderDate as [Sipariş Tarihi], o.Status as [Durum]
                        FROM Orders o
                        JOIN Cars c ON o.CarId = c.Id
                        WHERE o.UserId = @uid AND o.Status = @status
                        ORDER BY o.OrderDate DESC";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUser.Id);
                        cmd.Parameters.AddWithValue("@status", status);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(reader);
                            dgv.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siparişler yüklenirken hata: " + ex.Message);
            }
        }

        private void OrderTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                bool statusChanged = false;
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Orders SET Status = 'Teslim Edildi' WHERE Status = 'Bekliyor' AND DATEDIFF(minute, OrderDate, GETDATE()) >= 1";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            statusChanged = true;
                        }
                    }
                }

                if (statusChanged)
                {
                    if (tabControl.SelectedTab == tabActiveOrders) LoadActiveOrders();
                    if (tabControl.SelectedTab == tabPastOrders) LoadPastOrders();
                }
            }
            catch
            {
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PorscheDealership
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Model, Stock, ImagePath FROM Cars";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dataTable = new System.Data.DataTable();
                        dataTable.Load(reader);
                        dgvCars.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araçlar yüklenirken hata: " + ex.Message);
            }
        }

        private void BtnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0) return;
            
            int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Id"].Value);
            
            if (int.TryParse(txtStock.Text, out int newStock))
            {
                try
                {
                    using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Cars SET Stock = @s WHERE Id = @id";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@s", newStock);
                            cmd.Parameters.AddWithValue("@id", carId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Stok güncellendi.");
                    LoadCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen listeden bir araç seçin.");
                return;
            }

            int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Id"].Value);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Copy image to app directory to keep it relative
                        string appDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                        if (!Directory.Exists(appDir))
                            Directory.CreateDirectory(appDir);

                        string ext = Path.GetExtension(ofd.FileName);
                        string fileName = $"car_{carId}_{DateTime.Now.Ticks}{ext}";
                        string targetPath = Path.Combine(appDir, fileName);

                        File.Copy(ofd.FileName, targetPath, true);

                        using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Cars SET ImagePath = @img WHERE Id = @id";
                            using (var cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@img", targetPath);
                                cmd.Parameters.AddWithValue("@id", carId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Resim başarıyla yüklendi!");
                        LoadCars();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void DgvCars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                txtStock.Text = dgvCars.SelectedRows[0].Cells["Stock"].Value.ToString();
            }
        }
    }
}

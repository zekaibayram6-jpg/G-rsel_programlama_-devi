using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PorscheDealership
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                lblMessage.Text = "Lütfen tüm alanları doldurun.";
                return;
            }

            try
            {
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Password, FullName, IsAdmin) VALUES (@u, @p, @f, 0)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@f", txtFullName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kayıt başarılı! Şimdi giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Kayıt hatası: " + ex.Message;
            }
        }
    }
}

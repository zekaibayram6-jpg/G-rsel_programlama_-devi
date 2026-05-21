using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PorscheDealership
{
    public partial class LoginForm : Form
    {
        public User LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.Text = "Kullanıcı adı ve şifre boş olamaz.";
                return;
            }

            try
            {
                using (var conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Username, FullName, IsAdmin FROM Users WHERE Username = @u AND Password = @p";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LoggedInUser = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    FullName = reader.GetString(2),
                                    IsAdmin = reader.GetBoolean(3)
                                };
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                lblMessage.Text = "Hatalı kullanıcı adı veya şifre.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata: " + ex.Message;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void BtnAdminLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
            BtnLogin_Click(sender, e);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Windows.Forms;

namespace PorscheDealership
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Initialize database tables and dummy data
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı başlatılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show Login Form first
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login is successful, open Main Form with the logged in user
                Application.Run(new MainForm(loginForm.LoggedInUser));
            }
        }
    }
}
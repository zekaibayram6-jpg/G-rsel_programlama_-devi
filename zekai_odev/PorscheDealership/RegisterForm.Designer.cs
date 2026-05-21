namespace PorscheDealership
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblUsername = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblPassword = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblFullName = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblTitle
            lblTitle.Text = "Yeni Hesap Oluştur";
            lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.Top = 20;
            lblTitle.Left = 50;
            lblTitle.Width = 300;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUsername
            lblUsername.Text = "Kullanıcı Adı:";
            lblUsername.Top = 80;
            lblUsername.Left = 50;
            lblUsername.Width = 100;

            // txtUsername
            this.txtUsername.Top = 80;
            this.txtUsername.Left = 150;
            this.txtUsername.Width = 180;
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblPassword
            lblPassword.Text = "Şifre:";
            lblPassword.Top = 120;
            lblPassword.Left = 50;
            lblPassword.Width = 100;

            // txtPassword
            this.txtPassword.Top = 120;
            this.txtPassword.Left = 150;
            this.txtPassword.Width = 180;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblFullName
            lblFullName.Text = "Ad Soyad:";
            lblFullName.Top = 160;
            lblFullName.Left = 50;
            lblFullName.Width = 100;

            // txtFullName
            this.txtFullName.Top = 160;
            this.txtFullName.Left = 150;
            this.txtFullName.Width = 180;
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtFullName.ForeColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnRegister
            this.btnRegister.Text = "Kayıt Ol";
            this.btnRegister.Top = 210;
            this.btnRegister.Left = 150;
            this.btnRegister.Width = 180;
            this.btnRegister.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);

            // lblMessage
            this.lblMessage.Top = 260;
            this.lblMessage.Left = 50;
            this.lblMessage.Width = 300;
            this.lblMessage.ForeColor = System.Drawing.Color.Orange;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // RegisterForm
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblMessage);
            this.Name = "RegisterForm";
            this.Text = "Porsche Dealership - Kayıt Ol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ForeColor = System.Drawing.Color.White;
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblMessage;
    }
}

namespace PorscheDealership
{
    partial class LoginForm
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            btnAdminLogin = new Button();
            lblMessage = new Label();
            lblTitle = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(40, 40, 40);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(150, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(40, 40, 40);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(150, 120);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkRed;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(150, 170);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(80, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Giriş Yap";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DarkSlateGray;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(250, 170);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(80, 23);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // btnAdminLogin
            // 
            btnAdminLogin.BackColor = Color.DimGray;
            btnAdminLogin.FlatAppearance.BorderSize = 0;
            btnAdminLogin.FlatStyle = FlatStyle.Flat;
            btnAdminLogin.Location = new Point(150, 220);
            btnAdminLogin.Name = "btnAdminLogin";
            btnAdminLogin.Size = new Size(180, 23);
            btnAdminLogin.TabIndex = 7;
            btnAdminLogin.Text = "Hızlı Admin Girişi";
            btnAdminLogin.UseVisualStyleBackColor = false;
            btnAdminLogin.Click += BtnAdminLogin_Click;
            // 
            // lblMessage
            // 
            lblMessage.ForeColor = Color.Orange;
            lblMessage.Location = new Point(50, 260);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(300, 23);
            lblMessage.TabIndex = 8;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Porsche Yetkili Satıcısı";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(50, 80);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Kullanıcı Adı:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(50, 120);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Şifre:";
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(400, 320);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(btnAdminLogin);
            Controls.Add(lblMessage);
            ForeColor = Color.White;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Porsche Dealership - Giriş Yap";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.Label lblMessage;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
    }
}

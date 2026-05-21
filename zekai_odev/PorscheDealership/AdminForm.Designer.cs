namespace PorscheDealership
{
    partial class AdminForm
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
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Yönetim Paneli - Araç ve Stok Kontrolü";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Top = 15;
            this.lblTitle.Left = 20;
            this.lblTitle.Width = 500;
            this.lblTitle.ForeColor = System.Drawing.Color.LightGray;

            // dgvCars
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.BackgroundColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.ForeColor = System.Drawing.Color.Black;
            this.dgvCars.Location = new System.Drawing.Point(20, 60);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(740, 300);
            this.dgvCars.TabIndex = 0;
            this.dgvCars.SelectionChanged += new System.EventHandler(this.DgvCars_SelectionChanged);

            // lblStock
            this.lblStock.Text = "Yeni Stok:";
            this.lblStock.Top = 380;
            this.lblStock.Left = 20;
            this.lblStock.Width = 100;
            this.lblStock.ForeColor = System.Drawing.Color.White;

            // txtStock
            this.txtStock.Top = 380;
            this.txtStock.Left = 120;
            this.txtStock.Width = 100;
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtStock.ForeColor = System.Drawing.Color.White;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnUpdateStock
            this.btnUpdateStock.Text = "Stok Güncelle";
            this.btnUpdateStock.Top = 375;
            this.btnUpdateStock.Left = 240;
            this.btnUpdateStock.Width = 120;
            this.btnUpdateStock.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdateStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStock.FlatAppearance.BorderSize = 0;
            this.btnUpdateStock.Click += new System.EventHandler(this.BtnUpdateStock_Click);

            // btnSelectImage
            this.btnSelectImage.Text = "Araca Resim Ekle (Seçili)";
            this.btnSelectImage.Top = 375;
            this.btnSelectImage.Left = 400;
            this.btnSelectImage.Width = 200;
            this.btnSelectImage.BackColor = System.Drawing.Color.DarkRed;
            this.btnSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectImage.FlatAppearance.BorderSize = 0;
            this.btnSelectImage.Click += new System.EventHandler(this.BtnSelectImage_Click);

            // AdminForm
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnUpdateStock);
            this.Controls.Add(this.btnSelectImage);
            this.Name = "AdminForm";
            this.Text = "Porsche Dealership - Admin Panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStock;
    }
}

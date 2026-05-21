namespace PorscheDealership
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCatalog = new System.Windows.Forms.TabPage();
            this.flowCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.tabActiveOrders = new System.Windows.Forms.TabPage();
            this.dgvActiveOrders = new System.Windows.Forms.DataGridView();
            this.tabPastOrders = new System.Windows.Forms.TabPage();
            this.dgvPastOrders = new System.Windows.Forms.DataGridView();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.orderTimer = new System.Windows.Forms.Timer(this.components);

            this.tabControl.SuspendLayout();
            this.tabCatalog.SuspendLayout();
            this.tabActiveOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveOrders)).BeginInit();
            this.tabPastOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastOrders)).BeginInit();
            this.SuspendLayout();

            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.LightGray;
            this.lblWelcome.Location = new System.Drawing.Point(20, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(500, 30);
            this.lblWelcome.Text = "Hoşgeldin";

            //
            // btnAdminPanel
            //
            this.btnAdminPanel.Location = new System.Drawing.Point(820, 10);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(140, 30);
            this.btnAdminPanel.Text = "Yönetim Panelini Aç";
            this.btnAdminPanel.BackColor = System.Drawing.Color.DarkRed;
            this.btnAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminPanel.FlatAppearance.BorderSize = 0;
            this.btnAdminPanel.Visible = false;
            this.btnAdminPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdminPanel.Click += new System.EventHandler(this.BtnAdminPanel_Click);

            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabCatalog);
            this.tabControl.Controls.Add(this.tabActiveOrders);
            this.tabControl.Controls.Add(this.tabPastOrders);
            this.tabControl.Location = new System.Drawing.Point(20, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(940, 600);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);

            // 
            // tabCatalog
            // 
            this.tabCatalog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabCatalog.Controls.Add(this.flowCatalog);
            this.tabCatalog.Location = new System.Drawing.Point(4, 24);
            this.tabCatalog.Name = "tabCatalog";
            this.tabCatalog.Padding = new System.Windows.Forms.Padding(3);
            this.tabCatalog.Size = new System.Drawing.Size(932, 572);
            this.tabCatalog.TabIndex = 0;
            this.tabCatalog.Text = "Araç Kataloğu";

            // 
            // flowCatalog
            // 
            this.flowCatalog.AutoScroll = true;
            this.flowCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCatalog.Location = new System.Drawing.Point(3, 3);
            this.flowCatalog.Name = "flowCatalog";
            this.flowCatalog.Padding = new System.Windows.Forms.Padding(10);
            this.flowCatalog.Size = new System.Drawing.Size(926, 566);
            this.flowCatalog.TabIndex = 0;

            // 
            // tabActiveOrders
            // 
            this.tabActiveOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabActiveOrders.Controls.Add(this.dgvActiveOrders);
            this.tabActiveOrders.Location = new System.Drawing.Point(4, 24);
            this.tabActiveOrders.Name = "tabActiveOrders";
            this.tabActiveOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabActiveOrders.Size = new System.Drawing.Size(932, 572);
            this.tabActiveOrders.TabIndex = 1;
            this.tabActiveOrders.Text = "Aktif Siparişlerim";

            // 
            // dgvActiveOrders
            // 
            this.dgvActiveOrders.AllowUserToAddRows = false;
            this.dgvActiveOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvActiveOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveOrders.ForeColor = System.Drawing.Color.Black;
            this.dgvActiveOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvActiveOrders.Name = "dgvActiveOrders";
            this.dgvActiveOrders.ReadOnly = true;
            this.dgvActiveOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActiveOrders.Size = new System.Drawing.Size(926, 566);
            this.dgvActiveOrders.TabIndex = 0;

            // 
            // tabPastOrders
            // 
            this.tabPastOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPastOrders.Controls.Add(this.dgvPastOrders);
            this.tabPastOrders.Location = new System.Drawing.Point(4, 24);
            this.tabPastOrders.Name = "tabPastOrders";
            this.tabPastOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPastOrders.Size = new System.Drawing.Size(932, 572);
            this.tabPastOrders.TabIndex = 2;
            this.tabPastOrders.Text = "Geçmiş Siparişlerim";

            // 
            // dgvPastOrders
            // 
            this.dgvPastOrders.AllowUserToAddRows = false;
            this.dgvPastOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPastOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvPastOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPastOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPastOrders.ForeColor = System.Drawing.Color.Black;
            this.dgvPastOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvPastOrders.Name = "dgvPastOrders";
            this.dgvPastOrders.ReadOnly = true;
            this.dgvPastOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPastOrders.Size = new System.Drawing.Size(926, 566);
            this.dgvPastOrders.TabIndex = 0;

            // 
            // orderTimer
            // 
            this.orderTimer.Enabled = true;
            this.orderTimer.Interval = 10000;
            this.orderTimer.Tick += new System.EventHandler(this.OrderTimer_Tick);

            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAdminPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Porsche Dealership - Dashboard";
            
            this.tabControl.ResumeLayout(false);
            this.tabCatalog.ResumeLayout(false);
            this.tabActiveOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveOrders)).EndInit();
            this.tabPastOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastOrders)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCatalog;
        private System.Windows.Forms.TabPage tabActiveOrders;
        private System.Windows.Forms.TabPage tabPastOrders;
        private System.Windows.Forms.FlowLayoutPanel flowCatalog;
        private System.Windows.Forms.DataGridView dgvActiveOrders;
        private System.Windows.Forms.DataGridView dgvPastOrders;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Timer orderTimer;
        private System.Windows.Forms.Button btnAdminPanel;
    }
}

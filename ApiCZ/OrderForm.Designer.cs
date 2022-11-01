
namespace ApiCZ
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backButton = new ApiCZ.Controls.RoundButton();
            this.updateStatusButton = new ApiCZ.Controls.RoundButton();
            this.orderKMButton = new ApiCZ.Controls.RoundButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.uploadButton = new ApiCZ.Controls.RoundButton();
            this.newOrderTimer = new System.Windows.Forms.Timer(this.components);
            this.enabledTimer = new System.Windows.Forms.Timer(this.components);
            this.checkStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.199629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.875F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.90572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.90572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.90572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.744915F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.268F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.35509F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.197696F));
            this.tableLayoutPanel1.Controls.Add(this.backButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.updateStatusButton, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.orderKMButton, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.topPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uploadButton, 8, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.723577F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.471545F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.487805F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.642277F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.7317F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.130081F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.6696885F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1091, 492);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.borderColor = System.Drawing.Color.Black;
            this.backButton.borderSize = 2;
            this.backButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.backButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.backButton.Icon = ((System.Drawing.Image)(resources.GetObject("backButton.Icon")));
            this.backButton.Location = new System.Drawing.Point(16, 451);
            this.backButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.backButton.Name = "backButton";
            this.backButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.backButton.rounded = true;
            this.backButton.rounding = 40;
            this.backButton.Size = new System.Drawing.Size(178, 34);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "В главное меню";
            //this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // updateStatusButton
            // 
            this.updateStatusButton.borderColor = System.Drawing.Color.Black;
            this.updateStatusButton.borderSize = 2;
            this.updateStatusButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.updateStatusButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.updateStatusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateStatusButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.updateStatusButton.Icon = ((System.Drawing.Image)(resources.GetObject("updateStatusButton.Icon")));
            this.updateStatusButton.Location = new System.Drawing.Point(734, 451);
            this.updateStatusButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.updateStatusButton.Name = "updateStatusButton";
            this.updateStatusButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.updateStatusButton.rounded = true;
            this.updateStatusButton.rounding = 40;
            this.updateStatusButton.Size = new System.Drawing.Size(160, 34);
            this.updateStatusButton.TabIndex = 15;
            this.updateStatusButton.Text = "Обновить статус заказов";
            //this.updateStatusButton.Click += new System.EventHandler(this.updateStatusButton_Click);
            // 
            // orderKMButton
            // 
            this.orderKMButton.borderColor = System.Drawing.Color.Black;
            this.orderKMButton.borderSize = 2;
            this.orderKMButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.orderKMButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.orderKMButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderKMButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderKMButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.orderKMButton.Icon = ((System.Drawing.Image)(resources.GetObject("orderKMButton.Icon")));
            this.orderKMButton.Location = new System.Drawing.Point(900, 63);
            this.orderKMButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.orderKMButton.Name = "orderKMButton";
            this.orderKMButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.orderKMButton.rounded = true;
            this.orderKMButton.rounding = 40;
            this.orderKMButton.Size = new System.Drawing.Size(172, 21);
            this.orderKMButton.TabIndex = 11;
            this.orderKMButton.Text = "Создать новый заказ";
            //this.orderKMButton.Click += new System.EventHandler(this.orderKMButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.tableLayoutPanel1.SetColumnSpan(this.topPanel, 10);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1085, 32);
            this.topPanel.TabIndex = 11;
            // 
            // uploadButton
            // 
            this.uploadButton.borderColor = System.Drawing.Color.Black;
            this.uploadButton.borderSize = 2;
            this.uploadButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.uploadButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.uploadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uploadButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uploadButton.Icon = ((System.Drawing.Image)(resources.GetObject("uploadButton.Icon")));
            this.uploadButton.Location = new System.Drawing.Point(900, 451);
            this.uploadButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.uploadButton.rounded = true;
            this.uploadButton.rounding = 40;
            this.uploadButton.Size = new System.Drawing.Size(172, 34);
            this.uploadButton.TabIndex = 11;
            this.uploadButton.Text = "Выгрузить коды";
            //this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // newOrderTimer
            // 
            this.newOrderTimer.Enabled = true;
            //this.newOrderTimer.Tick += new System.EventHandler(this.newOrderTimer_Tick);
            // 
            // enabledTimer
            // 
            this.enabledTimer.Enabled = true;
            //this.enabledTimer.Tick += new System.EventHandler(this.enabledTimer_Tick);
            // 
            // checkStatusTimer
            // 
            this.checkStatusTimer.Interval = 3000;
            //this.checkStatusTimer.Tick += new System.EventHandler(this.checkStatusTimer_Tick);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel topPanel;
        private Controls.RoundButton orderKMButton;
        private Controls.RoundButton uploadButton;
        private Controls.RoundButton updateStatusButton;
        private Controls.RoundButton backButton;
        private System.Windows.Forms.Timer newOrderTimer;
        private System.Windows.Forms.Timer enabledTimer;
        private System.Windows.Forms.Timer checkStatusTimer;
    }
}
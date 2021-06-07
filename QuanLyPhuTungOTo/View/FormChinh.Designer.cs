namespace QuanLyPhuTungOTo
{
    partial class FormChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThong = new System.Windows.Forms.ToolStripMenuItem();
            this.DangKyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BanSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.tinTứcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẩnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mộtSốĐiềuCầnQuanTâmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThong,
            this.thoátToolStripMenuItem,
            this.chứcNăngToolStripMenuItem,
            this.tinTứcToolStripMenuItem,
            this.liênHệToolStripMenuItem,
            this.hướngDẫnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(940, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThong
            // 
            this.heThong.BackColor = System.Drawing.Color.White;
            this.heThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DangKyTaiKhoan,
            this.LogOut});
            this.heThong.Image = ((System.Drawing.Image)(resources.GetObject("heThong.Image")));
            this.heThong.Name = "heThong";
            this.heThong.Size = new System.Drawing.Size(111, 24);
            this.heThong.Text = "Trang Chủ";
            // 
            // DangKyTaiKhoan
            // 
            this.DangKyTaiKhoan.Name = "DangKyTaiKhoan";
            this.DangKyTaiKhoan.Size = new System.Drawing.Size(201, 24);
            this.DangKyTaiKhoan.Text = "Đăng ký tài khoản";
            this.DangKyTaiKhoan.Click += new System.EventHandler(this.DangKyTaiKhoan_Click);
            // 
            // LogOut
            // 
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(201, 24);
            this.LogOut.Text = "Thoát";
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.thoátToolStripMenuItem.Text = "Giới Thiệu";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BanSanPham,
            this.nhapSanPham,
            this.QuanLy});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.chứcNăngToolStripMenuItem.Text = "Quản Lý";
            // 
            // BanSanPham
            // 
            this.BanSanPham.BackColor = System.Drawing.Color.LightPink;
            this.BanSanPham.Name = "BanSanPham";
            this.BanSanPham.Size = new System.Drawing.Size(181, 24);
            this.BanSanPham.Text = "Bán sản phẩm";
            this.BanSanPham.Click += new System.EventHandler(this.BanSanPham_Click);
            // 
            // nhapSanPham
            // 
            this.nhapSanPham.BackColor = System.Drawing.Color.LightPink;
            this.nhapSanPham.Name = "nhapSanPham";
            this.nhapSanPham.Size = new System.Drawing.Size(181, 24);
            this.nhapSanPham.Text = "Nhập sản phẩm";
            this.nhapSanPham.Click += new System.EventHandler(this.NhapSanPham_Click);
            // 
            // QuanLy
            // 
            this.QuanLy.BackColor = System.Drawing.Color.LightPink;
            this.QuanLy.Name = "QuanLy";
            this.QuanLy.Size = new System.Drawing.Size(181, 24);
            this.QuanLy.Text = "Quản lý";
            this.QuanLy.Click += new System.EventHandler(this.QuanLy_Click);
            // 
            // tinTứcToolStripMenuItem
            // 
            this.tinTứcToolStripMenuItem.Name = "tinTứcToolStripMenuItem";
            this.tinTứcToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.tinTứcToolStripMenuItem.Text = "Tin Tức";
            this.tinTứcToolStripMenuItem.Click += new System.EventHandler(this.tinTứcToolStripMenuItem_Click);
            // 
            // liênHệToolStripMenuItem
            // 
            this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.liênHệToolStripMenuItem.Text = "Liên hệ";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.hướngDẫnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẩnSửDụngToolStripMenuItem,
            this.mộtSốĐiềuCầnQuanTâmToolStripMenuItem});
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn";
            // 
            // hướngDẩnSửDụngToolStripMenuItem
            // 
            this.hướngDẩnSửDụngToolStripMenuItem.Name = "hướngDẩnSửDụngToolStripMenuItem";
            this.hướngDẩnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.hướngDẩnSửDụngToolStripMenuItem.Text = "Hướng dẩn sử dụng";
            // 
            // mộtSốĐiềuCầnQuanTâmToolStripMenuItem
            // 
            this.mộtSốĐiềuCầnQuanTâmToolStripMenuItem.Name = "mộtSốĐiềuCầnQuanTâmToolStripMenuItem";
            this.mộtSốĐiềuCầnQuanTâmToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.mộtSốĐiềuCầnQuanTâmToolStripMenuItem.Text = "Một số điều cần quan tâm";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.LightPink;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 617);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ PHỤ TÙNG Ô TÔ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem heThong;
        public System.Windows.Forms.ToolStripMenuItem BanSanPham;
        public System.Windows.Forms.ToolStripMenuItem nhapSanPham;
        public System.Windows.Forms.ToolStripMenuItem QuanLy;
        private System.Windows.Forms.ToolStripMenuItem hướngDẩnSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mộtSốĐiềuCầnQuanTâmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogOut;
        private System.Windows.Forms.ToolStripMenuItem tinTứcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liênHệToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem DangKyTaiKhoan;
    }
}


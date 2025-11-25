namespace GUI_Poly
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            loạiSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            sảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            thẻLưuĐộngToolStripMenuItem = new ToolStripMenuItem();
            phiếuBánHàngToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            pnMain = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, danhMụcToolStripMenuItem, bánHàngToolStripMenuItem, nhânViênToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1222, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem, thoátToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(181, 26);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(181, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(181, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loạiSảnPhẩmToolStripMenuItem, sảnPhẩmToolStripMenuItem });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(90, 24);
            danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // loạiSảnPhẩmToolStripMenuItem
            // 
            loạiSảnPhẩmToolStripMenuItem.Name = "loạiSảnPhẩmToolStripMenuItem";
            loạiSảnPhẩmToolStripMenuItem.Size = new Size(189, 26);
            loạiSảnPhẩmToolStripMenuItem.Text = "Loại Sản Phẩm";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            sảnPhẩmToolStripMenuItem.Size = new Size(189, 26);
            sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thẻLưuĐộngToolStripMenuItem, phiếuBánHàngToolStripMenuItem });
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(88, 24);
            bánHàngToolStripMenuItem.Text = "Bán Hàng";
            // 
            // thẻLưuĐộngToolStripMenuItem
            // 
            thẻLưuĐộngToolStripMenuItem.Name = "thẻLưuĐộngToolStripMenuItem";
            thẻLưuĐộngToolStripMenuItem.Size = new Size(197, 26);
            thẻLưuĐộngToolStripMenuItem.Text = "Thẻ Lưu Động";
            // 
            // phiếuBánHàngToolStripMenuItem
            // 
            phiếuBánHàngToolStripMenuItem.Name = "phiếuBánHàngToolStripMenuItem";
            phiếuBánHàngToolStripMenuItem.Size = new Size(197, 26);
            phiếuBánHàngToolStripMenuItem.Text = "Phiếu Bán Hàng";
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(91, 24);
            nhânViênToolStripMenuItem.Text = "Nhân Viên";
            nhânViênToolStripMenuItem.Click += nhânViênToolStripMenuItem_Click;
            // 
            // pnMain
            // 
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(0, 28);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1222, 651);
            pnMain.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 679);
            Controls.Add(pnMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "frmMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem thẻLưuĐộngToolStripMenuItem;
        private ToolStripMenuItem phiếuBánHàngToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem;
        private Panel pnMain;
    }
}
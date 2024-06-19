namespace ThiTN
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_MH = new DevExpress.XtraBars.BarButtonItem();
            this.btnGV = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Giaovien_Dangky = new DevExpress.XtraBars.BarButtonItem();
            this.btn_De = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Thi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.btnFrmMonHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DE_btn = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MAGV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btn_MH,
            this.btnGV,
            this.btn_Giaovien_Dangky,
            this.btn_De,
            this.btn_Thi});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1258, 193);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // btn_MH
            // 
            this.btn_MH.Id = 1;
            this.btn_MH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_MH.ImageOptions.Image")));
            this.btn_MH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_MH.ImageOptions.LargeImage")));
            this.btn_MH.Name = "btn_MH";
            this.btn_MH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonHoc_ItemClick);
            // 
            // btnGV
            // 
            this.btnGV.Id = 2;
            this.btnGV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGV.ImageOptions.Image")));
            this.btnGV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGV.ImageOptions.LargeImage")));
            this.btnGV.Name = "btnGV";
            this.btnGV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btn_Giaovien_Dangky
            // 
            this.btn_Giaovien_Dangky.Id = 3;
            this.btn_Giaovien_Dangky.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Giaovien_Dangky.ImageOptions.Image")));
            this.btn_Giaovien_Dangky.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Giaovien_Dangky.ImageOptions.LargeImage")));
            this.btn_Giaovien_Dangky.Name = "btn_Giaovien_Dangky";
            this.btn_Giaovien_Dangky.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Giaovien_Dangky_ItemClick);
            // 
            // btn_De
            // 
            this.btn_De.Id = 4;
            this.btn_De.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_De.ImageOptions.Image")));
            this.btn_De.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_De.ImageOptions.LargeImage")));
            this.btn_De.Name = "btn_De";
            this.btn_De.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // btn_Thi
            // 
            this.btn_Thi.Id = 5;
            this.btn_Thi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thi.ImageOptions.Image")));
            this.btn_Thi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Thi.ImageOptions.LargeImage")));
            this.btn_Thi.Name = "btn_Thi";
            this.btn_Thi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Thi_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.btnFrmMonHoc,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.DE_btn,
            this.ribbonPageGroup6,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "QUẢN TRỊ";
            // 
            // btnFrmMonHoc
            // 
            this.btnFrmMonHoc.ItemLinks.Add(this.btn_MH);
            this.btnFrmMonHoc.Name = "btnFrmMonHoc";
            this.btnFrmMonHoc.Text = "MÔN HỌC";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "KHOA";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "SINH VIÊN";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnGV);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "GIÁO VIÊN";
            // 
            // DE_btn
            // 
            this.DE_btn.AllowTextClipping = false;
            this.DE_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DE_btn.ImageOptions.Image")));
            this.DE_btn.ItemLinks.Add(this.btn_De, true);
            this.DE_btn.Name = "DE_btn";
            this.DE_btn.Text = "ĐỀ";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btn_Thi);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "THI";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_Giaovien_Dangky);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ĐĂNG KÝ THI";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "BÁO CÁO";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAGV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 859);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1258, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MAGV
            // 
            this.MAGV.Name = "MAGV";
            this.MAGV.Size = new System.Drawing.Size(51, 20);
            this.MAGV.Text = "MAGV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(57, 20);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(55, 20);
            this.NHOM.Text = "NHOM";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 885);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Ribbon = this.ribbonControl1;
            this.Text = "THI TRẮC NGHIỆM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btnFrmMonHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup DE_btn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btn_MH;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MAGV;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.BarButtonItem btnGV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btn_Giaovien_Dangky;
        private DevExpress.XtraBars.BarButtonItem btn_De;
        private DevExpress.XtraBars.BarButtonItem btn_Thi;
    }
}


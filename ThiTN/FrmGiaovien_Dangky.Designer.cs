﻿namespace ThiTN
{
    partial class FrmGiaovien_Dangky
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
            System.Windows.Forms.Label mAGVLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label lANLabel;
            System.Windows.Forms.Label sOCAUTHILabel;
            System.Windows.Forms.Label tHOIGIANLabel;
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.Windows.Forms.Label mALOPLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiaovien_Dangky));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btn_delete = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_thoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dS1 = new ThiTN.DS1();
            this.bdsGVDK = new System.Windows.Forms.BindingSource(this.components);
            this.gIAOVIEN_DANGKYTableAdapter = new ThiTN.DS1TableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.tableAdapterManager = new ThiTN.DS1TableAdapters.TableAdapterManager();
            this.bODE_DANGKYTableAdapter = new ThiTN.DS1TableAdapters.BODE_DANGKYTableAdapter();
            this.gcGVDK = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGVDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chiTiet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmbMALOP = new System.Windows.Forms.ComboBox();
            this.bdsLOP = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTRINHDO = new System.Windows.Forms.ComboBox();
            this.cmbMAMH = new System.Windows.Forms.ComboBox();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.txtTHOIGIAN = new DevExpress.XtraEditors.SpinEdit();
            this.txtSOCAUTHI = new DevExpress.XtraEditors.SpinEdit();
            this.txtLAN = new DevExpress.XtraEditors.SpinEdit();
            this.txtNGAYTHI = new DevExpress.XtraEditors.DateEdit();
            this.txtMAGV = new DevExpress.XtraEditors.TextEdit();
            this.bdsBDDK = new System.Windows.Forms.BindingSource(this.components);
            this.mONHOCTableAdapter = new ThiTN.DS1TableAdapters.MONHOCTableAdapter();
            this.lOPTableAdapter = new ThiTN.DS1TableAdapters.LOPTableAdapter();
            mAGVLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            sOCAUTHILabel = new System.Windows.Forms.Label();
            tHOIGIANLabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            mALOPLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHOIGIAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOCAUTHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGAYTHI.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGAYTHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAGV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBDDK)).BeginInit();
            this.SuspendLayout();
            // 
            // mAGVLabel
            // 
            mAGVLabel.AutoSize = true;
            mAGVLabel.Location = new System.Drawing.Point(64, 66);
            mAGVLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mAGVLabel.Name = "mAGVLabel";
            mAGVLabel.Size = new System.Drawing.Size(46, 16);
            mAGVLabel.TabIndex = 0;
            mAGVLabel.Text = "MAGV:";
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(339, 148);
            nGAYTHILabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(67, 16);
            nGAYTHILabel.TabIndex = 8;
            nGAYTHILabel.Text = "NGÀY THI:";
            // 
            // lANLabel
            // 
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(671, 148);
            lANLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(34, 16);
            lANLabel.TabIndex = 10;
            lANLabel.Text = "LẦN:";
            // 
            // sOCAUTHILabel
            // 
            sOCAUTHILabel.AutoSize = true;
            sOCAUTHILabel.Location = new System.Drawing.Point(32, 228);
            sOCAUTHILabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            sOCAUTHILabel.Name = "sOCAUTHILabel";
            sOCAUTHILabel.Size = new System.Drawing.Size(81, 16);
            sOCAUTHILabel.TabIndex = 12;
            sOCAUTHILabel.Text = "SỐ CÂU THI:";
            // 
            // tHOIGIANLabel
            // 
            tHOIGIANLabel.AutoSize = true;
            tHOIGIANLabel.Location = new System.Drawing.Point(331, 228);
            tHOIGIANLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            tHOIGIANLabel.Name = "tHOIGIANLabel";
            tHOIGIANLabel.Size = new System.Drawing.Size(73, 16);
            tHOIGIANLabel.TabIndex = 14;
            tHOIGIANLabel.Text = "THỜI GIAN:";
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(317, 69);
            mAMHLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(95, 16);
            mAMHLabel.TabIndex = 15;
            mAMHLabel.Text = "TÊN MÔN HỌC:";
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(40, 146);
            tRINHDOLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(70, 16);
            tRINHDOLabel.TabIndex = 16;
            tRINHDOLabel.Text = "TRÌNH ĐỘ:";
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(651, 66);
            mALOPLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(56, 16);
            mALOPLabel.TabIndex = 17;
            mALOPLabel.Text = "MÃ LỚP:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnGhi,
            this.btn_delete,
            this.btn_thoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_delete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_thoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btn_delete
            // 
            this.btn_delete.Caption = "Xóa";
            this.btn_delete.Id = 2;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.LargeImage")));
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_delete_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 1;
            this.btnGhi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.Image")));
            this.btnGhi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.LargeImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Caption = "Thoát";
            this.btn_thoat.Id = 3;
            this.btn_thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_thoat.ImageOptions.Image")));
            this.btn_thoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_thoat.ImageOptions.LargeImage")));
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_thoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1189, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 902);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1189, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 872);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1189, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 872);
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1189, 89);
            this.panelControl1.TabIndex = 4;
            // 
            // dS1
            // 
            this.dS1.DataSetName = "DS1";
            this.dS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsGVDK
            // 
            this.bdsGVDK.DataMember = "GIAOVIEN_DANGKY";
            this.bdsGVDK.DataSource = this.dS1;
            // 
            // gIAOVIEN_DANGKYTableAdapter
            // 
            this.gIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODE_DANGKYTableAdapter = this.bODE_DANGKYTableAdapter;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = this.gIAOVIEN_DANGKYTableAdapter;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ThiTN.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bODE_DANGKYTableAdapter
            // 
            this.bODE_DANGKYTableAdapter.ClearBeforeFill = true;
            // 
            // gcGVDK
            // 
            this.gcGVDK.DataSource = this.bdsGVDK;
            this.gcGVDK.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcGVDK.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcGVDK.Location = new System.Drawing.Point(0, 119);
            this.gcGVDK.MainView = this.gridView1;
            this.gcGVDK.Margin = new System.Windows.Forms.Padding(4);
            this.gcGVDK.MenuManager = this.barManager1;
            this.gcGVDK.Name = "gcGVDK";
            this.gcGVDK.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcGVDK.Size = new System.Drawing.Size(1189, 271);
            this.gcGVDK.TabIndex = 6;
            this.gcGVDK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGVDK,
            this.colMAGV,
            this.colMAMH,
            this.colMALOP,
            this.colTRINHDO,
            this.colNGAYTHI,
            this.colLAN,
            this.colSOCAUTHI,
            this.colTHOIGIAN,
            this.chiTiet});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gcGVDK;
            this.gridView1.Name = "gridView1";
            // 
            // colMAGVDK
            // 
            this.colMAGVDK.FieldName = "MAGVDK";
            this.colMAGVDK.MinWidth = 27;
            this.colMAGVDK.Name = "colMAGVDK";
            this.colMAGVDK.Visible = true;
            this.colMAGVDK.VisibleIndex = 8;
            this.colMAGVDK.Width = 100;
            // 
            // colMAGV
            // 
            this.colMAGV.FieldName = "MAGV";
            this.colMAGV.MinWidth = 27;
            this.colMAGV.Name = "colMAGV";
            this.colMAGV.Visible = true;
            this.colMAGV.VisibleIndex = 0;
            this.colMAGV.Width = 100;
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 27;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            this.colMAMH.Width = 100;
            // 
            // colMALOP
            // 
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.MinWidth = 27;
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 2;
            this.colMALOP.Width = 100;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.MinWidth = 27;
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 3;
            this.colTRINHDO.Width = 100;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.MinWidth = 27;
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 4;
            this.colNGAYTHI.Width = 100;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.MinWidth = 27;
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 5;
            this.colLAN.Width = 100;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.MinWidth = 27;
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 6;
            this.colSOCAUTHI.Width = 100;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.MinWidth = 27;
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 7;
            this.colTHOIGIAN.Width = 100;
            // 
            // chiTiet
            // 
            this.chiTiet.Caption = "Chi Tiết";
            this.chiTiet.ColumnEdit = this.repositoryItemButtonEdit1;
            this.chiTiet.MinWidth = 27;
            this.chiTiet.Name = "chiTiet";
            this.chiTiet.Visible = true;
            this.chiTiet.VisibleIndex = 9;
            this.chiTiet.Width = 100;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.NullText = "Chi Tiết";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(mALOPLabel);
            this.panelControl2.Controls.Add(this.cmbMALOP);
            this.panelControl2.Controls.Add(tRINHDOLabel);
            this.panelControl2.Controls.Add(this.cmbTRINHDO);
            this.panelControl2.Controls.Add(mAMHLabel);
            this.panelControl2.Controls.Add(this.cmbMAMH);
            this.panelControl2.Controls.Add(tHOIGIANLabel);
            this.panelControl2.Controls.Add(this.txtTHOIGIAN);
            this.panelControl2.Controls.Add(sOCAUTHILabel);
            this.panelControl2.Controls.Add(this.txtSOCAUTHI);
            this.panelControl2.Controls.Add(lANLabel);
            this.panelControl2.Controls.Add(this.txtLAN);
            this.panelControl2.Controls.Add(nGAYTHILabel);
            this.panelControl2.Controls.Add(this.txtNGAYTHI);
            this.panelControl2.Controls.Add(mAGVLabel);
            this.panelControl2.Controls.Add(this.txtMAGV);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 390);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1189, 512);
            this.panelControl2.TabIndex = 7;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // cmbMALOP
            // 
            this.cmbMALOP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "MALOP", true));
            this.cmbMALOP.DataSource = this.bdsLOP;
            this.cmbMALOP.DisplayMember = "TENLOP";
            this.cmbMALOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMALOP.FormattingEnabled = true;
            this.cmbMALOP.Location = new System.Drawing.Point(719, 63);
            this.cmbMALOP.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMALOP.Name = "cmbMALOP";
            this.cmbMALOP.Size = new System.Drawing.Size(205, 24);
            this.cmbMALOP.TabIndex = 18;
            this.cmbMALOP.ValueMember = "MALOP";
            // 
            // bdsLOP
            // 
            this.bdsLOP.DataMember = "LOP";
            this.bdsLOP.DataSource = this.dS1;
            // 
            // cmbTRINHDO
            // 
            this.cmbTRINHDO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "TRINHDO", true));
            this.cmbTRINHDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTRINHDO.FormattingEnabled = true;
            this.cmbTRINHDO.Location = new System.Drawing.Point(124, 143);
            this.cmbTRINHDO.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTRINHDO.Name = "cmbTRINHDO";
            this.cmbTRINHDO.Size = new System.Drawing.Size(132, 24);
            this.cmbTRINHDO.TabIndex = 17;
            // 
            // cmbMAMH
            // 
            this.cmbMAMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "MAMH", true));
            this.cmbMAMH.DataSource = this.bdsMH;
            this.cmbMAMH.DisplayMember = "TENMH";
            this.cmbMAMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAMH.FormattingEnabled = true;
            this.cmbMAMH.Location = new System.Drawing.Point(420, 64);
            this.cmbMAMH.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMAMH.Name = "cmbMAMH";
            this.cmbMAMH.Size = new System.Drawing.Size(189, 24);
            this.cmbMAMH.TabIndex = 16;
            this.cmbMAMH.ValueMember = "MAMH";
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.dS1;
            // 
            // txtTHOIGIAN
            // 
            this.txtTHOIGIAN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "THOIGIAN", true));
            this.txtTHOIGIAN.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTHOIGIAN.Location = new System.Drawing.Point(420, 224);
            this.txtTHOIGIAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTHOIGIAN.MenuManager = this.barManager1;
            this.txtTHOIGIAN.Name = "txtTHOIGIAN";
            this.txtTHOIGIAN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTHOIGIAN.Size = new System.Drawing.Size(189, 24);
            this.txtTHOIGIAN.TabIndex = 15;
            // 
            // txtSOCAUTHI
            // 
            this.txtSOCAUTHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "SOCAUTHI", true));
            this.txtSOCAUTHI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSOCAUTHI.Location = new System.Drawing.Point(124, 224);
            this.txtSOCAUTHI.Margin = new System.Windows.Forms.Padding(4);
            this.txtSOCAUTHI.MenuManager = this.barManager1;
            this.txtSOCAUTHI.Name = "txtSOCAUTHI";
            this.txtSOCAUTHI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSOCAUTHI.Size = new System.Drawing.Size(133, 24);
            this.txtSOCAUTHI.TabIndex = 13;
            // 
            // txtLAN
            // 
            this.txtLAN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "LAN", true));
            this.txtLAN.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLAN.Location = new System.Drawing.Point(719, 144);
            this.txtLAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtLAN.MenuManager = this.barManager1;
            this.txtLAN.Name = "txtLAN";
            this.txtLAN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLAN.Size = new System.Drawing.Size(205, 24);
            this.txtLAN.TabIndex = 11;
            // 
            // txtNGAYTHI
            // 
            this.txtNGAYTHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "NGAYTHI", true));
            this.txtNGAYTHI.EditValue = null;
            this.txtNGAYTHI.Location = new System.Drawing.Point(420, 144);
            this.txtNGAYTHI.Margin = new System.Windows.Forms.Padding(4);
            this.txtNGAYTHI.MenuManager = this.barManager1;
            this.txtNGAYTHI.Name = "txtNGAYTHI";
            this.txtNGAYTHI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNGAYTHI.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNGAYTHI.Size = new System.Drawing.Size(189, 22);
            this.txtNGAYTHI.TabIndex = 9;
            // 
            // txtMAGV
            // 
            this.txtMAGV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "MAGV", true));
            this.txtMAGV.Location = new System.Drawing.Point(124, 63);
            this.txtMAGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMAGV.MenuManager = this.barManager1;
            this.txtMAGV.Name = "txtMAGV";
            this.txtMAGV.Size = new System.Drawing.Size(133, 22);
            this.txtMAGV.TabIndex = 1;
            // 
            // bdsBDDK
            // 
            this.bdsBDDK.DataMember = "FK_BODE_DANGKY_GIAOVIEN_DANGKY";
            this.bdsBDDK.DataSource = this.bdsGVDK;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // FrmGiaovien_Dangky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1189, 922);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.gcGVDK);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGiaovien_Dangky";
            this.Text = "FrmGiaovien_Dangky";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGiaovien_Dangky_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHOIGIAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOCAUTHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGAYTHI.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGAYTHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAGV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBDDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource bdsGVDK;
        private DS1 dS1;
        private DS1TableAdapters.GIAOVIEN_DANGKYTableAdapter gIAOVIEN_DANGKYTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcGVDK;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SpinEdit txtLAN;
        private DevExpress.XtraEditors.DateEdit txtNGAYTHI;
        private DevExpress.XtraEditors.TextEdit txtMAGV;
        private DevExpress.XtraEditors.SpinEdit txtTHOIGIAN;
        private DevExpress.XtraEditors.SpinEdit txtSOCAUTHI;
        private DS1TableAdapters.BODE_DANGKYTableAdapter bODE_DANGKYTableAdapter;
        private System.Windows.Forms.BindingSource bdsBDDK;
        private System.Windows.Forms.ComboBox cmbMAMH;
        private System.Windows.Forms.BindingSource bdsMH;
        private DS1TableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private System.Windows.Forms.ComboBox cmbTRINHDO;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private System.Windows.Forms.BindingSource bdsLOP;
        private DS1TableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.ComboBox cmbMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGVDK;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn chiTiet;
        private DevExpress.XtraBars.BarButtonItem btn_delete;
        private DevExpress.XtraBars.BarButtonItem btn_thoat;
    }
}
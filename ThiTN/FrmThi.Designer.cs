﻿namespace ThiTN
{
    partial class FrmThi
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
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label tENMHLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tENLOPTextBox = new System.Windows.Forms.TextBox();
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tN_CSDLPTDataSet = new ThiTN.TN_CSDLPTDataSet();
            this.mALOPTextBox = new System.Windows.Forms.TextBox();
            this.tb_hoTen = new System.Windows.Forms.TextBox();
            this.tb_maSV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb_BaiThi = new System.Windows.Forms.GroupBox();
            this.lb_ThoiGianHeader2 = new System.Windows.Forms.Label();
            this.lb_ThoiGianHeader1 = new System.Windows.Forms.Label();
            this.lb_soCau2 = new System.Windows.Forms.Label();
            this.lb_soCau1 = new System.Windows.Forms.Label();
            this.btn_TimDeThi = new System.Windows.Forms.Button();
            this.se_Lan = new DevExpress.XtraEditors.SpinEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_NgayThi = new System.Windows.Forms.DateTimePicker();
            this.ccb_MonHoc = new System.Windows.Forms.ComboBox();
            this.mONHOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mONHOCTableAdapter = new ThiTN.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new ThiTN.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_ThoiGian2 = new System.Windows.Forms.Label();
            this.lb_ThoiGian1 = new System.Windows.Forms.Label();
            this.btn_NopBai = new System.Windows.Forms.Button();
            this.btn_batDau = new System.Windows.Forms.Button();
            this.pn_CauHoi = new System.Windows.Forms.Panel();
            this.radio_D = new System.Windows.Forms.RadioButton();
            this.radio_B = new System.Windows.Forms.RadioButton();
            this.radio_C = new System.Windows.Forms.RadioButton();
            this.radio_A = new System.Windows.Forms.RadioButton();
            this.btn_tiep = new System.Windows.Forms.Button();
            this.btn_truoc = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_D = new System.Windows.Forms.TextBox();
            this.tb_C = new System.Windows.Forms.TextBox();
            this.tb_B = new System.Windows.Forms.TextBox();
            this.tb_A = new System.Windows.Forms.TextBox();
            this.tb_CAUHOI = new System.Windows.Forms.TextBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lOPTableAdapter = new ThiTN.TN_CSDLPTDataSetTableAdapters.LOPTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.col_CauHoi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_DapAn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            mALOPLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            tENMHLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).BeginInit();
            this.gb_BaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.se_Lan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.pn_CauHoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(27, 28);
            mALOPLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(46, 13);
            mALOPLabel.TabIndex = 7;
            mALOPLabel.Text = "Mã Lớp:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Location = new System.Drawing.Point(21, 54);
            tENLOPLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(50, 13);
            tENLOPLabel.TabIndex = 8;
            tENLOPLabel.Text = "Tên Lớp:";
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(29, 28);
            tENMHLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(49, 13);
            tENMHLabel.TabIndex = 0;
            tENMHLabel.Text = "Tên MH:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(tENLOPLabel);
            this.groupBox1.Controls.Add(this.tENLOPTextBox);
            this.groupBox1.Controls.Add(mALOPLabel);
            this.groupBox1.Controls.Add(this.mALOPTextBox);
            this.groupBox1.Controls.Add(this.tb_hoTen);
            this.groupBox1.Controls.Add(this.tb_maSV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(618, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Sinh Viên";
            // 
            // tENLOPTextBox
            // 
            this.tENLOPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOPBindingSource, "TENLOP", true));
            this.tENLOPTextBox.Enabled = false;
            this.tENLOPTextBox.Location = new System.Drawing.Point(84, 52);
            this.tENLOPTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tENLOPTextBox.Name = "tENLOPTextBox";
            this.tENLOPTextBox.Size = new System.Drawing.Size(253, 20);
            this.tENLOPTextBox.TabIndex = 9;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.tN_CSDLPTDataSet;
            // 
            // tN_CSDLPTDataSet
            // 
            this.tN_CSDLPTDataSet.DataSetName = "TN_CSDLPTDataSet";
            this.tN_CSDLPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mALOPTextBox
            // 
            this.mALOPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOPBindingSource, "MALOP", true));
            this.mALOPTextBox.Enabled = false;
            this.mALOPTextBox.Location = new System.Drawing.Point(84, 27);
            this.mALOPTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mALOPTextBox.Name = "mALOPTextBox";
            this.mALOPTextBox.Size = new System.Drawing.Size(253, 20);
            this.mALOPTextBox.TabIndex = 8;
            // 
            // tb_hoTen
            // 
            this.tb_hoTen.Enabled = false;
            this.tb_hoTen.Location = new System.Drawing.Point(409, 54);
            this.tb_hoTen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_hoTen.Name = "tb_hoTen";
            this.tb_hoTen.Size = new System.Drawing.Size(195, 20);
            this.tb_hoTen.TabIndex = 7;
            // 
            // tb_maSV
            // 
            this.tb_maSV.Enabled = false;
            this.tb_maSV.Location = new System.Drawing.Point(409, 24);
            this.tb_maSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_maSV.Name = "tb_maSV";
            this.tb_maSV.Size = new System.Drawing.Size(195, 20);
            this.tb_maSV.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã SV:";
            // 
            // gb_BaiThi
            // 
            this.gb_BaiThi.Controls.Add(this.lb_ThoiGianHeader2);
            this.gb_BaiThi.Controls.Add(this.lb_ThoiGianHeader1);
            this.gb_BaiThi.Controls.Add(this.lb_soCau2);
            this.gb_BaiThi.Controls.Add(this.lb_soCau1);
            this.gb_BaiThi.Controls.Add(this.btn_TimDeThi);
            this.gb_BaiThi.Controls.Add(this.se_Lan);
            this.gb_BaiThi.Controls.Add(this.label6);
            this.gb_BaiThi.Controls.Add(this.label5);
            this.gb_BaiThi.Controls.Add(this.dtp_NgayThi);
            this.gb_BaiThi.Controls.Add(tENMHLabel);
            this.gb_BaiThi.Controls.Add(this.ccb_MonHoc);
            this.gb_BaiThi.Location = new System.Drawing.Point(640, 10);
            this.gb_BaiThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_BaiThi.Name = "gb_BaiThi";
            this.gb_BaiThi.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_BaiThi.Size = new System.Drawing.Size(543, 92);
            this.gb_BaiThi.TabIndex = 1;
            this.gb_BaiThi.TabStop = false;
            this.gb_BaiThi.Text = "Bài Thi";
            // 
            // lb_ThoiGianHeader2
            // 
            this.lb_ThoiGianHeader2.AutoSize = true;
            this.lb_ThoiGianHeader2.Location = new System.Drawing.Point(490, 61);
            this.lb_ThoiGianHeader2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ThoiGianHeader2.Name = "lb_ThoiGianHeader2";
            this.lb_ThoiGianHeader2.Size = new System.Drawing.Size(50, 13);
            this.lb_ThoiGianHeader2.TabIndex = 16;
            this.lb_ThoiGianHeader2.Text = "100 Phút";
            this.lb_ThoiGianHeader2.Visible = false;
            // 
            // lb_ThoiGianHeader1
            // 
            this.lb_ThoiGianHeader1.AutoSize = true;
            this.lb_ThoiGianHeader1.Location = new System.Drawing.Point(435, 61);
            this.lb_ThoiGianHeader1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ThoiGianHeader1.Name = "lb_ThoiGianHeader1";
            this.lb_ThoiGianHeader1.Size = new System.Drawing.Size(56, 13);
            this.lb_ThoiGianHeader1.TabIndex = 15;
            this.lb_ThoiGianHeader1.Text = "Thời Gian:";
            this.lb_ThoiGianHeader1.Visible = false;
            // 
            // lb_soCau2
            // 
            this.lb_soCau2.AutoSize = true;
            this.lb_soCau2.Location = new System.Drawing.Point(481, 28);
            this.lb_soCau2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_soCau2.Name = "lb_soCau2";
            this.lb_soCau2.Size = new System.Drawing.Size(25, 13);
            this.lb_soCau2.TabIndex = 14;
            this.lb_soCau2.Text = "100";
            this.lb_soCau2.Visible = false;
            // 
            // lb_soCau1
            // 
            this.lb_soCau1.AutoSize = true;
            this.lb_soCau1.Location = new System.Drawing.Point(435, 28);
            this.lb_soCau1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_soCau1.Name = "lb_soCau1";
            this.lb_soCau1.Size = new System.Drawing.Size(45, 13);
            this.lb_soCau1.TabIndex = 13;
            this.lb_soCau1.Text = "Số Câu:";
            this.lb_soCau1.Visible = false;
            // 
            // btn_TimDeThi
            // 
            this.btn_TimDeThi.Location = new System.Drawing.Point(354, 56);
            this.btn_TimDeThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TimDeThi.Name = "btn_TimDeThi";
            this.btn_TimDeThi.Size = new System.Drawing.Size(56, 19);
            this.btn_TimDeThi.TabIndex = 6;
            this.btn_TimDeThi.Text = "Tìm";
            this.btn_TimDeThi.UseVisualStyleBackColor = true;
            this.btn_TimDeThi.Click += new System.EventHandler(this.btn_TimDeThi_Click);
            // 
            // se_Lan
            // 
            this.se_Lan.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.se_Lan.Location = new System.Drawing.Point(322, 26);
            this.se_Lan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.se_Lan.Name = "se_Lan";
            this.se_Lan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.se_Lan.Size = new System.Drawing.Size(88, 20);
            this.se_Lan.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lần:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày Thi:";
            // 
            // dtp_NgayThi
            // 
            this.dtp_NgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayThi.Location = new System.Drawing.Point(88, 58);
            this.dtp_NgayThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_NgayThi.Name = "dtp_NgayThi";
            this.dtp_NgayThi.Size = new System.Drawing.Size(162, 20);
            this.dtp_NgayThi.TabIndex = 2;
            this.dtp_NgayThi.Value = new System.DateTime(2024, 6, 23, 0, 0, 0, 0);
            // 
            // ccb_MonHoc
            // 
            this.ccb_MonHoc.DataSource = this.mONHOCBindingSource;
            this.ccb_MonHoc.DisplayMember = "TENMH";
            this.ccb_MonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccb_MonHoc.FormattingEnabled = true;
            this.ccb_MonHoc.Location = new System.Drawing.Point(88, 25);
            this.ccb_MonHoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ccb_MonHoc.Name = "ccb_MonHoc";
            this.ccb_MonHoc.Size = new System.Drawing.Size(162, 21);
            this.ccb_MonHoc.TabIndex = 1;
            this.ccb_MonHoc.ValueMember = "MAMH";
            // 
            // mONHOCBindingSource
            // 
            this.mONHOCBindingSource.DataMember = "MONHOC";
            this.mONHOCBindingSource.DataSource = this.tN_CSDLPTDataSet;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODE_DANGKYTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = this.mONHOCTableAdapter;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ThiTN.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_ThoiGian2);
            this.panel1.Controls.Add(this.lb_ThoiGian1);
            this.panel1.Controls.Add(this.btn_NopBai);
            this.panel1.Controls.Add(this.btn_batDau);
            this.panel1.Location = new System.Drawing.Point(7, 143);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 66);
            this.panel1.TabIndex = 2;
            // 
            // lb_ThoiGian2
            // 
            this.lb_ThoiGian2.AutoSize = true;
            this.lb_ThoiGian2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThoiGian2.Location = new System.Drawing.Point(669, 15);
            this.lb_ThoiGian2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ThoiGian2.Name = "lb_ThoiGian2";
            this.lb_ThoiGian2.Size = new System.Drawing.Size(82, 31);
            this.lb_ThoiGian2.TabIndex = 3;
            this.lb_ThoiGian2.Text = "60:00";
            this.lb_ThoiGian2.Visible = false;
            // 
            // lb_ThoiGian1
            // 
            this.lb_ThoiGian1.AutoSize = true;
            this.lb_ThoiGian1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThoiGian1.Location = new System.Drawing.Point(532, 16);
            this.lb_ThoiGian1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ThoiGian1.Name = "lb_ThoiGian1";
            this.lb_ThoiGian1.Size = new System.Drawing.Size(139, 31);
            this.lb_ThoiGian1.TabIndex = 2;
            this.lb_ThoiGian1.Text = "Thời Gian:";
            this.lb_ThoiGian1.Visible = false;
            // 
            // btn_NopBai
            // 
            this.btn_NopBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NopBai.Location = new System.Drawing.Point(980, 10);
            this.btn_NopBai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_NopBai.Name = "btn_NopBai";
            this.btn_NopBai.Size = new System.Drawing.Size(181, 41);
            this.btn_NopBai.TabIndex = 1;
            this.btn_NopBai.Text = "Nộp Bài";
            this.btn_NopBai.UseVisualStyleBackColor = true;
            this.btn_NopBai.Visible = false;
            this.btn_NopBai.Click += new System.EventHandler(this.btn_NopBai_Click);
            // 
            // btn_batDau
            // 
            this.btn_batDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batDau.Location = new System.Drawing.Point(26, 13);
            this.btn_batDau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_batDau.Name = "btn_batDau";
            this.btn_batDau.Size = new System.Drawing.Size(249, 38);
            this.btn_batDau.TabIndex = 0;
            this.btn_batDau.Text = "Bắt đầu";
            this.btn_batDau.UseVisualStyleBackColor = true;
            this.btn_batDau.Visible = false;
            this.btn_batDau.Click += new System.EventHandler(this.btn_batDau_Click);
            // 
            // pn_CauHoi
            // 
            this.pn_CauHoi.Controls.Add(this.radio_D);
            this.pn_CauHoi.Controls.Add(this.radio_B);
            this.pn_CauHoi.Controls.Add(this.radio_C);
            this.pn_CauHoi.Controls.Add(this.radio_A);
            this.pn_CauHoi.Controls.Add(this.btn_tiep);
            this.pn_CauHoi.Controls.Add(this.btn_truoc);
            this.pn_CauHoi.Controls.Add(this.label10);
            this.pn_CauHoi.Controls.Add(this.label9);
            this.pn_CauHoi.Controls.Add(this.label8);
            this.pn_CauHoi.Controls.Add(this.label7);
            this.pn_CauHoi.Controls.Add(this.tb_D);
            this.pn_CauHoi.Controls.Add(this.tb_C);
            this.pn_CauHoi.Controls.Add(this.tb_B);
            this.pn_CauHoi.Controls.Add(this.tb_A);
            this.pn_CauHoi.Controls.Add(this.tb_CAUHOI);
            this.pn_CauHoi.Controls.Add(this.lb_stt);
            this.pn_CauHoi.Controls.Add(this.label1);
            this.pn_CauHoi.Location = new System.Drawing.Point(9, 225);
            this.pn_CauHoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pn_CauHoi.Name = "pn_CauHoi";
            this.pn_CauHoi.Size = new System.Drawing.Size(1058, 384);
            this.pn_CauHoi.TabIndex = 3;
            this.pn_CauHoi.Visible = false;
            // 
            // radio_D
            // 
            this.radio_D.AutoSize = true;
            this.radio_D.Location = new System.Drawing.Point(663, 230);
            this.radio_D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radio_D.Name = "radio_D";
            this.radio_D.Size = new System.Drawing.Size(14, 13);
            this.radio_D.TabIndex = 21;
            this.radio_D.UseVisualStyleBackColor = true;
            this.radio_D.Click += new System.EventHandler(this.radio_D_Click);
            // 
            // radio_B
            // 
            this.radio_B.AutoSize = true;
            this.radio_B.Location = new System.Drawing.Point(663, 150);
            this.radio_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radio_B.Name = "radio_B";
            this.radio_B.Size = new System.Drawing.Size(14, 13);
            this.radio_B.TabIndex = 20;
            this.radio_B.UseVisualStyleBackColor = true;
            this.radio_B.Click += new System.EventHandler(this.radio_B_Click);
            // 
            // radio_C
            // 
            this.radio_C.AutoSize = true;
            this.radio_C.Location = new System.Drawing.Point(170, 228);
            this.radio_C.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radio_C.Name = "radio_C";
            this.radio_C.Size = new System.Drawing.Size(14, 13);
            this.radio_C.TabIndex = 19;
            this.radio_C.UseVisualStyleBackColor = true;
            this.radio_C.Click += new System.EventHandler(this.radio_C_Click);
            // 
            // radio_A
            // 
            this.radio_A.AutoSize = true;
            this.radio_A.Cursor = System.Windows.Forms.Cursors.Default;
            this.radio_A.Location = new System.Drawing.Point(170, 150);
            this.radio_A.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radio_A.Name = "radio_A";
            this.radio_A.Size = new System.Drawing.Size(14, 13);
            this.radio_A.TabIndex = 18;
            this.radio_A.UseVisualStyleBackColor = true;
            this.radio_A.Click += new System.EventHandler(this.radio_A_Click);
            // 
            // btn_tiep
            // 
            this.btn_tiep.Enabled = false;
            this.btn_tiep.Location = new System.Drawing.Point(969, 311);
            this.btn_tiep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_tiep.Name = "btn_tiep";
            this.btn_tiep.Size = new System.Drawing.Size(56, 33);
            this.btn_tiep.TabIndex = 17;
            this.btn_tiep.Text = "Tiếp";
            this.btn_tiep.UseVisualStyleBackColor = true;
            this.btn_tiep.Click += new System.EventHandler(this.btn_tiep_Click);
            // 
            // btn_truoc
            // 
            this.btn_truoc.Enabled = false;
            this.btn_truoc.Location = new System.Drawing.Point(170, 311);
            this.btn_truoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_truoc.Name = "btn_truoc";
            this.btn_truoc.Size = new System.Drawing.Size(56, 33);
            this.btn_truoc.TabIndex = 16;
            this.btn_truoc.Text = "Trước";
            this.btn_truoc.UseVisualStyleBackColor = true;
            this.btn_truoc.Click += new System.EventHandler(this.btn_truoc_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(644, 230);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "D.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(644, 150);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "B.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "C.";
            // 
            // tb_D
            // 
            this.tb_D.Location = new System.Drawing.Point(689, 213);
            this.tb_D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_D.Multiline = true;
            this.tb_D.Name = "tb_D";
            this.tb_D.Size = new System.Drawing.Size(337, 41);
            this.tb_D.TabIndex = 6;
            // 
            // tb_C
            // 
            this.tb_C.Location = new System.Drawing.Point(196, 213);
            this.tb_C.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_C.Multiline = true;
            this.tb_C.Name = "tb_C";
            this.tb_C.Size = new System.Drawing.Size(337, 41);
            this.tb_C.TabIndex = 5;
            // 
            // tb_B
            // 
            this.tb_B.Location = new System.Drawing.Point(689, 136);
            this.tb_B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_B.Multiline = true;
            this.tb_B.Name = "tb_B";
            this.tb_B.Size = new System.Drawing.Size(337, 41);
            this.tb_B.TabIndex = 4;
            // 
            // tb_A
            // 
            this.tb_A.Location = new System.Drawing.Point(196, 136);
            this.tb_A.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_A.Multiline = true;
            this.tb_A.Name = "tb_A";
            this.tb_A.Size = new System.Drawing.Size(337, 41);
            this.tb_A.TabIndex = 3;
            // 
            // tb_CAUHOI
            // 
            this.tb_CAUHOI.Location = new System.Drawing.Point(170, 45);
            this.tb_CAUHOI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_CAUHOI.Multiline = true;
            this.tb_CAUHOI.Name = "tb_CAUHOI";
            this.tb_CAUHOI.Size = new System.Drawing.Size(857, 65);
            this.tb_CAUHOI.TabIndex = 2;
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(126, 47);
            this.lb_stt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(13, 13);
            this.lb_stt.TabIndex = 1;
            this.lb_stt.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Câu Số:";
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_CauHoi,
            this.col_DapAn});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1089, 225);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(99, 384);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // col_CauHoi
            // 
            this.col_CauHoi.Text = "Câu Hỏi";
            // 
            // col_DapAn
            // 
            this.col_DapAn.Text = "Đáp Án";
            // 
            // FrmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pn_CauHoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_BaiThi);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmThi";
            this.Text = "FrmThi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmThi_FormClosing_1);
            this.Load += new System.EventHandler(this.FrmThi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).EndInit();
            this.gb_BaiThi.ResumeLayout(false);
            this.gb_BaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.se_Lan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pn_CauHoi.ResumeLayout(false);
            this.pn_CauHoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_BaiThi;
        private System.Windows.Forms.TextBox tb_hoTen;
        private System.Windows.Forms.TextBox tb_maSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private TN_CSDLPTDataSet tN_CSDLPTDataSet;
        private System.Windows.Forms.BindingSource mONHOCBindingSource;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.SpinEdit se_Lan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_NgayThi;
        private System.Windows.Forms.Button btn_TimDeThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_ThoiGian2;
        private System.Windows.Forms.Label lb_ThoiGian1;
        private System.Windows.Forms.Button btn_NopBai;
        private System.Windows.Forms.Button btn_batDau;
        private System.Windows.Forms.Panel pn_CauHoi;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private TN_CSDLPTDataSetTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.TextBox tENLOPTextBox;
        private System.Windows.Forms.TextBox mALOPTextBox;
        private System.Windows.Forms.ComboBox ccb_MonHoc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_D;
        private System.Windows.Forms.TextBox tb_C;
        private System.Windows.Forms.TextBox tb_B;
        private System.Windows.Forms.TextBox tb_A;
        private System.Windows.Forms.TextBox tb_CAUHOI;
        private System.Windows.Forms.Button btn_tiep;
        private System.Windows.Forms.Button btn_truoc;
        private System.Windows.Forms.RadioButton radio_D;
        private System.Windows.Forms.RadioButton radio_B;
        private System.Windows.Forms.RadioButton radio_C;
        private System.Windows.Forms.RadioButton radio_A;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col_CauHoi;
        private System.Windows.Forms.ColumnHeader col_DapAn;
        private System.Windows.Forms.Label lb_ThoiGianHeader2;
        private System.Windows.Forms.Label lb_ThoiGianHeader1;
        private System.Windows.Forms.Label lb_soCau2;
        private System.Windows.Forms.Label lb_soCau1;
    }
}
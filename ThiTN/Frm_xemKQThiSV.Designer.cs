namespace ThiTN
{
    partial class Frm_xemKQThiSV
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
            System.Windows.Forms.Label tENMHLabel;
            this.gb_BaiThi = new System.Windows.Forms.GroupBox();
            this.cbb_monHoc = new System.Windows.Forms.ComboBox();
            this.mONHOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tN_CSDLPTDataSet = new ThiTN.TN_CSDLPTDataSet();
            this.btn_TimDeThi = new System.Windows.Forms.Button();
            this.se_Lan = new DevExpress.XtraEditors.SpinEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.mONHOCTableAdapter = new ThiTN.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new ThiTN.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            tENMHLabel = new System.Windows.Forms.Label();
            this.gb_BaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Lan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(39, 34);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(58, 16);
            tENMHLabel.TabIndex = 0;
            tENMHLabel.Text = "Tên MH:";
            // 
            // gb_BaiThi
            // 
            this.gb_BaiThi.Controls.Add(this.cbb_monHoc);
            this.gb_BaiThi.Controls.Add(this.btn_TimDeThi);
            this.gb_BaiThi.Controls.Add(this.se_Lan);
            this.gb_BaiThi.Controls.Add(this.label6);
            this.gb_BaiThi.Controls.Add(tENMHLabel);
            this.gb_BaiThi.Location = new System.Drawing.Point(12, 21);
            this.gb_BaiThi.Name = "gb_BaiThi";
            this.gb_BaiThi.Size = new System.Drawing.Size(776, 160);
            this.gb_BaiThi.TabIndex = 2;
            this.gb_BaiThi.TabStop = false;
            this.gb_BaiThi.Text = "Bài Thi";
            // 
            // cbb_monHoc
            // 
            this.cbb_monHoc.DataSource = this.mONHOCBindingSource;
            this.cbb_monHoc.DisplayMember = "TENMH";
            this.cbb_monHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_monHoc.FormattingEnabled = true;
            this.cbb_monHoc.Location = new System.Drawing.Point(103, 32);
            this.cbb_monHoc.Name = "cbb_monHoc";
            this.cbb_monHoc.Size = new System.Drawing.Size(253, 24);
            this.cbb_monHoc.TabIndex = 7;
            this.cbb_monHoc.ValueMember = "MAMH";
            // 
            // mONHOCBindingSource
            // 
            this.mONHOCBindingSource.DataMember = "MONHOC";
            this.mONHOCBindingSource.DataSource = this.tN_CSDLPTDataSet;
            // 
            // tN_CSDLPTDataSet
            // 
            this.tN_CSDLPTDataSet.DataSetName = "TN_CSDLPTDataSet";
            this.tN_CSDLPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_TimDeThi
            // 
            this.btn_TimDeThi.Location = new System.Drawing.Point(617, 69);
            this.btn_TimDeThi.Name = "btn_TimDeThi";
            this.btn_TimDeThi.Size = new System.Drawing.Size(75, 23);
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
            this.se_Lan.Location = new System.Drawing.Point(575, 32);
            this.se_Lan.Name = "se_Lan";
            this.se_Lan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.se_Lan.Size = new System.Drawing.Size(117, 24);
            this.se_Lan.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lần:";
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
            // Frm_xemKQThiSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 283);
            this.Controls.Add(this.gb_BaiThi);
            this.Name = "Frm_xemKQThiSV";
            this.Text = "Frm_xemKQThiSV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_xemKQThiSV_Load);
            this.gb_BaiThi.ResumeLayout(false);
            this.gb_BaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.se_Lan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_BaiThi;
        private System.Windows.Forms.Button btn_TimDeThi;
        private DevExpress.XtraEditors.SpinEdit se_Lan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_monHoc;
        private TN_CSDLPTDataSet tN_CSDLPTDataSet;
        private System.Windows.Forms.BindingSource mONHOCBindingSource;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}
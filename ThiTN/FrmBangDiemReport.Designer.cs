namespace ThiTN
{
    partial class FrmBangDiemReport
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
            System.Windows.Forms.Label mAMHLabel;
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bdsLOP = new System.Windows.Forms.BindingSource(this.components);
            this.dS1 = new ThiTN.DS1();
            this.lOPTableAdapter = new ThiTN.DS1TableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new ThiTN.DS1TableAdapters.TableAdapterManager();
            this.cmbML = new System.Windows.Forms.ComboBox();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.mONHOCTableAdapter = new ThiTN.DS1TableAdapters.MONHOCTableAdapter();
            this.cmbLan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMH = new System.Windows.Forms.ComboBox();
            this.preview = new System.Windows.Forms.Button();
            mALOPLabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.preview);
            this.panelControl1.Controls.Add(this.cmbMH);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cmbLan);
            this.panelControl1.Controls.Add(mAMHLabel);
            this.panelControl1.Controls.Add(mALOPLabel);
            this.panelControl1.Controls.Add(this.cmbML);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 439);
            this.panelControl1.TabIndex = 0;
            // 
            // bdsLOP
            // 
            this.bdsLOP.DataMember = "LOP";
            this.bdsLOP.DataSource = this.dS1;
            // 
            // dS1
            // 
            this.dS1.DataSetName = "DS1";
            this.dS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.LOPTableAdapter = this.lOPTableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ThiTN.DS1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(49, 45);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(49, 13);
            mALOPLabel.TabIndex = 0;
            mALOPLabel.Text = "Tên Lớp:";
            // 
            // cmbML
            // 
            this.cmbML.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsLOP, "MALOP", true));
            this.cmbML.DataSource = this.bdsLOP;
            this.cmbML.DisplayMember = "TENLOP";
            this.cmbML.FormattingEnabled = true;
            this.cmbML.Location = new System.Drawing.Point(100, 42);
            this.cmbML.Name = "cmbML";
            this.cmbML.Size = new System.Drawing.Size(121, 21);
            this.cmbML.TabIndex = 1;
            this.cmbML.ValueMember = "MALOP";
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.dS1;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(274, 48);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(73, 13);
            mAMHLabel.TabIndex = 2;
            mAMHLabel.Text = "Tên Môn Học:";
            // 
            // cmbLan
            // 
            this.cmbLan.FormattingEnabled = true;
            this.cmbLan.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbLan.Location = new System.Drawing.Point(588, 45);
            this.cmbLan.Name = "cmbLan";
            this.cmbLan.Size = new System.Drawing.Size(121, 21);
            this.cmbLan.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lần:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbMH
            // 
            this.cmbMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMH, "MAMH", true));
            this.cmbMH.DataSource = this.bdsMH;
            this.cmbMH.DisplayMember = "TENMH";
            this.cmbMH.FormattingEnabled = true;
            this.cmbMH.Location = new System.Drawing.Point(353, 42);
            this.cmbMH.Name = "cmbMH";
            this.cmbMH.Size = new System.Drawing.Size(138, 21);
            this.cmbMH.TabIndex = 6;
            this.cmbMH.ValueMember = "MAMH";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(634, 124);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(75, 23);
            this.preview.TabIndex = 7;
            this.preview.Text = "Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // FrmBangDiemReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmBangDiemReport";
            this.Text = "FrmBangDiemReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBangDiemReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DS1 dS1;
        private System.Windows.Forms.BindingSource bdsLOP;
        private DS1TableAdapters.LOPTableAdapter lOPTableAdapter;
        private DS1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbML;
        private System.Windows.Forms.BindingSource bdsMH;
        private DS1TableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLan;
        private System.Windows.Forms.ComboBox cmbMH;
        private System.Windows.Forms.Button preview;
    }
}
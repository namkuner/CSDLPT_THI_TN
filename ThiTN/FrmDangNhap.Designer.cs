namespace ThiTN
{
    partial class FrmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.coSo = new System.Windows.Forms.ComboBox();
            this.taiKhoan = new System.Windows.Forms.TextBox();
            this.matKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSV = new System.Windows.Forms.RadioButton();
            this.checkGV = new System.Windows.Forms.RadioButton();
            this.grbMASV = new System.Windows.Forms.GroupBox();
            this.MASV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbMASV.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cơ sở";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // coSo
            // 
            this.coSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coSo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coSo.FormattingEnabled = true;
            this.coSo.Location = new System.Drawing.Point(337, 59);
            this.coSo.Name = "coSo";
            this.coSo.Size = new System.Drawing.Size(219, 30);
            this.coSo.TabIndex = 3;
            this.coSo.SelectedIndexChanged += new System.EventHandler(this.coSo_SelectedIndexChanged);
            // 
            // taiKhoan
            // 
            this.taiKhoan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taiKhoan.Location = new System.Drawing.Point(337, 177);
            this.taiKhoan.Name = "taiKhoan";
            this.taiKhoan.Size = new System.Drawing.Size(219, 29);
            this.taiKhoan.TabIndex = 4;
            // 
            // matKhau
            // 
            this.matKhau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matKhau.Location = new System.Drawing.Point(337, 230);
            this.matKhau.Name = "matKhau";
            this.matKhau.Size = new System.Drawing.Size(219, 29);
            this.matKhau.TabIndex = 5;
            this.matKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(264, 309);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(472, 309);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSV);
            this.groupBox1.Controls.Add(this.checkGV);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(337, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 44);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // checkSV
            // 
            this.checkSV.AutoSize = true;
            this.checkSV.Location = new System.Drawing.Point(135, 19);
            this.checkSV.Name = "checkSV";
            this.checkSV.Size = new System.Drawing.Size(90, 23);
            this.checkSV.TabIndex = 1;
            this.checkSV.TabStop = true;
            this.checkSV.Text = "Sinh Viên";
            this.checkSV.UseVisualStyleBackColor = true;
            this.checkSV.CheckedChanged += new System.EventHandler(this.checkSV_CheckedChanged);
            // 
            // checkGV
            // 
            this.checkGV.AutoSize = true;
            this.checkGV.Location = new System.Drawing.Point(6, 19);
            this.checkGV.Name = "checkGV";
            this.checkGV.Size = new System.Drawing.Size(93, 23);
            this.checkGV.TabIndex = 0;
            this.checkGV.TabStop = true;
            this.checkGV.Text = "Giáo Viên";
            this.checkGV.UseVisualStyleBackColor = true;
            this.checkGV.CheckedChanged += new System.EventHandler(this.checkGV_CheckedChanged);
            // 
            // grbMASV
            // 
            this.grbMASV.Controls.Add(this.MASV);
            this.grbMASV.Controls.Add(this.label4);
            this.grbMASV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMASV.Location = new System.Drawing.Point(575, 112);
            this.grbMASV.Name = "grbMASV";
            this.grbMASV.Size = new System.Drawing.Size(220, 44);
            this.grbMASV.TabIndex = 9;
            this.grbMASV.TabStop = false;
            // 
            // MASV
            // 
            this.MASV.Location = new System.Drawing.Point(109, 12);
            this.MASV.Name = "MASV";
            this.MASV.Size = new System.Drawing.Size(100, 26);
            this.MASV.TabIndex = 1;
            this.MASV.TextChanged += new System.EventHandler(this.MASV_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã sinh viên";
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbMASV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.matKhau);
            this.Controls.Add(this.taiKhoan);
            this.Controls.Add(this.coSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDangNhap";
            this.Text = "FrmDangNhap";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbMASV.ResumeLayout(false);
            this.grbMASV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox coSo;
        private System.Windows.Forms.TextBox taiKhoan;
        private System.Windows.Forms.TextBox matKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton checkGV;
        private System.Windows.Forms.RadioButton checkSV;
        private System.Windows.Forms.GroupBox grbMASV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MASV;
    }
}
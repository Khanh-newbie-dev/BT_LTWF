namespace Entity_Framework_Core
{
    partial class QLSV
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvStudents = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            txt_FullName = new TextBox();
            label3 = new Label();
            txtGrade = new TextBox();
            btn_Add = new Button();
            btn_Edit = new Button();
            btn_Remove = new Button();
            btn_Reload = new Button();
            btn_Filter = new Button();
            label4 = new Label();
            cboFaculty = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.AllowDrop = true;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(25, 180);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(1008, 327);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellClick += dgvStudents_CellClick;
            dgvStudents.CellContentClick += this.dgvStudents_CellContentClick;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(245, 9);
            label1.Name = "label1";
            label1.Size = new Size(575, 44);
            label1.TabIndex = 2;
            label1.Text = "QUẢN LÝ SINH VIÊN - EF CORE(CRUD ĐẦY ĐỦ)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 69);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 3;
            label2.Text = "Họ tên: ";
            // 
            // txt_FullName
            // 
            txt_FullName.Location = new Point(138, 68);
            txt_FullName.Name = "txt_FullName";
            txt_FullName.Size = new Size(323, 27);
            txt_FullName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(500, 65);
            label3.Name = "label3";
            label3.Size = new Size(58, 23);
            label3.TabIndex = 5;
            label3.Text = "Điểm:";
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(583, 65);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(218, 27);
            txtGrade.TabIndex = 6;
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(94, 127);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(80, 35);
            btn_Add.TabIndex = 7;
            btn_Add.Text = "Thêm";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.Location = new Point(234, 127);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(80, 35);
            btn_Edit.TabIndex = 8;
            btn_Edit.Text = "Sửa";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // btn_Remove
            // 
            btn_Remove.Location = new Point(390, 127);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new Size(80, 35);
            btn_Remove.TabIndex = 9;
            btn_Remove.Text = "Xoá";
            btn_Remove.UseVisualStyleBackColor = true;
            btn_Remove.Click += btn_Remove_Click;
            // 
            // btn_Reload
            // 
            btn_Reload.Location = new Point(583, 127);
            btn_Reload.Name = "btn_Reload";
            btn_Reload.Size = new Size(143, 35);
            btn_Reload.TabIndex = 10;
            btn_Reload.Text = "Tải lại danh sách";
            btn_Reload.UseVisualStyleBackColor = true;
            btn_Reload.Click += btn_Reload_Click;
            // 
            // btn_Filter
            // 
            btn_Filter.Location = new Point(763, 127);
            btn_Filter.Name = "btn_Filter";
            btn_Filter.Size = new Size(193, 35);
            btn_Filter.TabIndex = 11;
            btn_Filter.Text = "Lọc SV đạt(LINQ)";
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(839, 66);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 12;
            label4.Text = "Khoa:";
            // 
            // cboFaculty
            // 
            cboFaculty.FormattingEnabled = true;
            cboFaculty.Location = new Point(900, 65);
            cboFaculty.Name = "cboFaculty";
            cboFaculty.Size = new Size(123, 28);
            cboFaculty.TabIndex = 13;
            // 
            // QLSV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 519);
            Controls.Add(cboFaculty);
            Controls.Add(label4);
            Controls.Add(btn_Filter);
            Controls.Add(btn_Reload);
            Controls.Add(btn_Remove);
            Controls.Add(btn_Edit);
            Controls.Add(btn_Add);
            Controls.Add(txtGrade);
            Controls.Add(label3);
            Controls.Add(txt_FullName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvStudents);
            Name = "QLSV";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudents;
        private Label label1;
        private Label label2;
        private TextBox txt_FullName;
        private Label label3;
        private TextBox txtGrade;
        private Button btn_Add;
        private Button btn_Edit;
        private Button btn_Remove;
        private Button btn_Reload;
        private Button btn_Filter;
        private Label label4;
        private ComboBox cboFaculty;
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Entity_Framework_Core
{
    public partial class QLSV : Form
    {
        private int _selectedStudentId = 0;

        public QLSV()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFaculties();
            LoadData();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string name, out double grade, out int facultyId))
                return;

            try
            {
                using var context = new AppDbContext();
                var newStudent = new Student
                {
                    FullName = name,
                    Grade = grade,
                    FacultyId = facultyId
                };

                context.Students.Add(newStudent);
                context.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Vui lòng click chọn một sinh viên trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out string name, out double grade, out int facultyId))
                return;

            try
            {
                using var context = new AppDbContext();
                var student = context.Students.Find(_selectedStudentId);

                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                student.FullName = name;
                student.Grade = grade;
                student.FacultyId = facultyId;

                context.SaveChanges();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Vui lòng click chọn một sinh viên trên bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var context = new AppDbContext();
                var student = context.Students.Find(_selectedStudentId);

                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = new AppDbContext();
                var passList = context.Students
                                      .AsNoTracking()
                                      .Include(s => s.Faculty)
                                      .Where(s => s.Grade >= 5.0)
                                      .OrderByDescending(s => s.Grade)
                                      .Select(s => new
                                      {
                                          Mã_SV = s.Id,
                                          Họ_Tên = s.FullName,
                                          Điểm = s.Grade,
                                          Tên_Khoa = s.Faculty != null ? s.Faculty.FacultyName : "Chưa phân khoa",
                                          FacultyId = s.FacultyId
                                      })
                                      .ToList();

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = passList;

                if (dgvStudents.Columns["FacultyId"] != null)
                    dgvStudents.Columns["FacultyId"].Visible = false;

                MessageBox.Show($"Tìm thấy {passList.Count} sinh viên đạt (Điểm >= 5.0)!", "Kết quả lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Rows[e.RowIndex].Cells["Mã_SV"].Value != null)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                _selectedStudentId = Convert.ToInt32(row.Cells["Mã_SV"].Value);
                txt_FullName.Text = row.Cells["Họ_Tên"].Value?.ToString();
                txtGrade.Text = row.Cells["Điểm"].Value?.ToString();
                if (row.Cells["FacultyId"].Value != null)
                {
                    cboFaculty.SelectedValue = Convert.ToInt32(row.Cells["FacultyId"].Value);
                }
            }
        }

        private void LoadFaculties()
        {
            try
            {
                using var context = new AppDbContext();
                var faculties = context.Faculties.AsNoTracking().ToList();

                cboFaculty.DataSource = faculties;
                cboFaculty.DisplayMember = "FacultyName"; 
                cboFaculty.ValueMember = "Id";         
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách Khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                using var context = new AppDbContext();
                var list = context.Students
                                  .AsNoTracking()
                                  .Include(s => s.Faculty)
                                  .OrderByDescending(s => s.Id)
                                  .Select(s => new
                                  {
                                      Mã_SV = s.Id,
                                      Họ_Tên = s.FullName,
                                      Điểm = s.Grade,
                                      Tên_Khoa = s.Faculty != null ? s.Faculty.FacultyName : "Chưa phân khoa",
                                      FacultyId = s.FacultyId
                                  })
                                  .ToList();

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = list;

                if (dgvStudents.Columns["FacultyId"] != null)
                {
                    dgvStudents.Columns["FacultyId"].Visible = false;
                }

                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(out string name, out double grade, out int facultyId)
        {
            name = txt_FullName.Text.Trim();
            grade = 0;
            facultyId = 0;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_FullName.Focus();
                return false;
            }

            if (!double.TryParse(txtGrade.Text.Trim(), out grade) || grade < 0 || grade > 10)
            {
                MessageBox.Show("Điểm số phải là số thực từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrade.Focus();
                return false;
            }

            if (cboFaculty.SelectedValue == null || !int.TryParse(cboFaculty.SelectedValue.ToString(), out facultyId))
            {
                MessageBox.Show("Vui lòng chọn Khoa hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFaculty.Focus();
                return false;
            }

            return true;
        }
        private void ClearForm()
        {
            _selectedStudentId = 0;
            txt_FullName.Clear();
            txtGrade.Clear();
            if (cboFaculty.Items.Count > 0)
                cboFaculty.SelectedIndex = 0;
            txt_FullName.Focus();
        }
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
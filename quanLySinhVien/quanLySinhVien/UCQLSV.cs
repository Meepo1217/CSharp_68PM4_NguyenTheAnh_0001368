using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class UCQLSV : UserControl
    {
        private int selectedId = -1;
        public UCQLSV()
        {
            InitializeComponent();
        }

        private void UCQLSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxGioiTinh();
            LoadComboBoxLop();
        }

        public void LoadData()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_sinhvien> dSSV = db.tbl_sinhviens.ToList();
            dataGridView1.DataSource = dSSV;
        }

        public void LoadComboBoxGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = -1;

        }
        public void LoadComboBoxLop()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_lophoc> dSLop = db.tbl_lophocs.ToList();
            cboLop.DataSource = dSLop;
            cboLop.DisplayMember = "tenlop";
            cboLop.ValueMember = "malop";
            cboLop.SelectedIndex = -1;
        }

        private void btlThem_Click(object sender, EventArgs e)
        {
            DatabaseDataContext db = new DatabaseDataContext();
            tbl_sinhvien sv = new tbl_sinhvien();
            sv.masv = txtMaSV.Text;
            sv.hoten = txtHoTen.Text;
            sv.gioitinh = cboGioiTinh.SelectedItem.ToString();
            sv.ngaysinh = dtpNgaySinh.Value;
            sv.malop = cboLop.SelectedValue.ToString();
            db.tbl_sinhviens.InsertOnSubmit(sv);
            db.SubmitChanges();
            LoadData();
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class UCQLSV : UserControl
    {
        private int selectedId = -1;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private string currentSearchQuery = "";
        public UCQLSV()
        {
            InitializeComponent();
        }

        private void UCQLSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxGioiTinh();
            LoadComboBoxLop();
        }

        public void LoadData()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            var query = db.tbl_sinhviens.AsQueryable();

            if (!string.IsNullOrEmpty(currentSearchQuery))
            {
                query = query.Where(x => x.hoten.Contains(currentSearchQuery) || 
                                         x.masv.Contains(currentSearchQuery) || 
                                         x.malop.Contains(currentSearchQuery));
            }

            totalRecords = query.Count();
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            var dSSV = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            dataGridView1.DataSource = dSSV;

            label7.Text = $"Trang {currentPage}/{totalPages}   |   {totalRecords} bản ghi";
        }

        public void LoadComboBoxGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = -1;

        }
        public void LoadComboBoxLop()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_lophoc> dSLop = db.tbl_lophocs.ToList();
            cboLop.DataSource = dSLop;
            cboLop.DisplayMember = "tenlop";
            cboLop.ValueMember = "malop";
            cboLop.SelectedIndex = -1;
        }

        private void btlThem_Click(object sender, EventArgs e)
        {
            DatabaseDataContext db = new DatabaseDataContext();
            tbl_sinhvien sv = new tbl_sinhvien();
            sv.masv = txtMaSV.Text;
            sv.hoten = txtHoTen.Text;
            sv.gioitinh = cboGioiTinh.SelectedItem.ToString();
            sv.ngaysinh = dtpNgaySinh.Value;
            sv.malop = cboLop.SelectedValue.ToString();
            db.tbl_sinhviens.InsertOnSubmit(sv);
            db.SubmitChanges();
            LoadData();
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboLop.SelectedIndex = -1;
            cboGioiTinh.SelectedIndex = -1;
            selectedId = -1;
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if (row.Cells["id"].Value != null)
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                    txtMaSV.Text = row.Cells["masv"].Value?.ToString();
                    txtHoTen.Text = row.Cells["hoten"].Value?.ToString();
                    cboGioiTinh.SelectedItem = row.Cells["gioitinh"].Value?.ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
                    cboLop.SelectedValue = row.Cells["malop"].Value?.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa từ danh sách!");
                return;
            }
            DatabaseDataContext db = new DatabaseDataContext();
            var sv = db.tbl_sinhviens.SingleOrDefault(x => x.id == selectedId);
            if (sv != null)
            {
                sv.masv = txtMaSV.Text;
                sv.hoten = txtHoTen.Text;
                if (cboGioiTinh.SelectedItem != null) sv.gioitinh = cboGioiTinh.SelectedItem.ToString();
                sv.ngaysinh = dtpNgaySinh.Value;
                if (cboLop.SelectedValue != null) sv.malop = cboLop.SelectedValue.ToString();
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin sinh viên thành công!");
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa từ danh sách!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseDataContext db = new DatabaseDataContext();
                var sv = db.tbl_sinhviens.SingleOrDefault(x => x.id == selectedId);
                if (sv != null)
                {
                    db.tbl_sinhviens.DeleteOnSubmit(sv);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa sinh viên thành công!");
                    button3_Click(sender, e);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentSearchQuery = textBox5.Text.Trim();
            currentPage = 1;
            LoadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadData();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage = totalPages;
                LoadData();
            }
        }
    }
}

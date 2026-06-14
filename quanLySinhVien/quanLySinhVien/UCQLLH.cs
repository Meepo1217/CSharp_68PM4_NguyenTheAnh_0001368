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
    public partial class UCQLLH : UserControl
    {
        private int selectedId = -1;

        public UCQLLH()
        {
            InitializeComponent();
        }

        private void UCQLLH_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            Column1.DataPropertyName = "id";
            Column2.DataPropertyName = "malop";
            Column3.DataPropertyName = "tenlop";
            Column4.DataPropertyName = "ghichu";
            
            LoadData();
            textBox1.ReadOnly = true; // Mã ID auto-generated or read-only
        }

        public void LoadData()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            var dSLop = db.tbl_lophocs.ToList();
            dataGridView1.DataSource = dSLop;
        }

        private void button1_Click(object sender, EventArgs e) // Thêm
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ mã lớp và tên lớp!");
                return;
            }
            DatabaseDataContext db = new DatabaseDataContext();
            
            // Check duplicate
            if (db.tbl_lophocs.Any(x => x.malop == textBox2.Text))
            {
                MessageBox.Show("Mã lớp này đã tồn tại!");
                return;
            }

            tbl_lophoc lh = new tbl_lophoc();
            lh.malop = textBox2.Text;
            lh.tenlop = textBox3.Text;
            lh.ghichu = textBox4.Text;
            db.tbl_lophocs.InsertOnSubmit(lh);
            db.SubmitChanges();
            MessageBox.Show("Thêm lớp học thành công!");
            LoadData();
            button3_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e) // Sửa
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần sửa!");
                return;
            }
            DatabaseDataContext db = new DatabaseDataContext();
            var lh = db.tbl_lophocs.SingleOrDefault(x => x.id == selectedId);
            if (lh != null)
            {
                lh.malop = textBox2.Text;
                lh.tenlop = textBox3.Text;
                lh.ghichu = textBox4.Text;
                db.SubmitChanges();
                MessageBox.Show("Sửa lớp học thành công!");
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e) // Xóa
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này? Tất cả sinh viên thuộc lớp cũng có thể bị ảnh hưởng.", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseDataContext db = new DatabaseDataContext();
                var lh = db.tbl_lophocs.SingleOrDefault(x => x.id == selectedId);
                if (lh != null)
                {
                    db.tbl_lophocs.DeleteOnSubmit(lh);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa lớp học thành công!");
                    button3_Click(sender, e);
                    LoadData();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Làm mới
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            selectedId = -1;
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Column1"].Value != null)
                {
                    selectedId = Convert.ToInt32(row.Cells["Column1"].Value);
                    textBox1.Text = row.Cells["Column1"].Value?.ToString(); // ID
                    textBox2.Text = row.Cells["Column2"].Value?.ToString(); // Mã lớp
                    textBox3.Text = row.Cells["Column3"].Value?.ToString(); // Tên lớp
                    textBox4.Text = row.Cells["Column4"].Value?.ToString(); // Ghi chú
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_Poly;
using DTO_Poly;

namespace GUI_Poly
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhanVien();
        }
        private void LoadDanhSachNhanVien()
        {
            BUSNhanVien bUSNhanVien = new BUSNhanVien();
            dgvdanhsachnhanvien.DataSource = null;
            dgvdanhsachnhanvien.DataSource = bUSNhanVien.GetNhanVienList();

            dgvdanhsachnhanvien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvdanhsachnhanvien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvdanhsachnhanvien.Columns["Email"].HeaderText = "Email";
            dgvdanhsachnhanvien.Columns["MatKhau"].HeaderText = "MatKhau";
            dgvdanhsachnhanvien.Columns["VaiTro"].Visible = false;
            dgvdanhsachnhanvien.Columns["TrangThai"].Visible = false;
            dgvdanhsachnhanvien.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvdanhsachnhanvien.Columns["VaiTroText"].HeaderText = "Vai Trò";
        }
        private void ClearForm()
        {
            btbthem.Enabled = true;
            btbsua.Enabled = false;
            btbxoa.Enabled = true;
            btbreset.Enabled = false;
            txtmanhanvien.Clear();
            txthoten.Clear();
            txtEmail.Clear();
            txtxacnhanmatkhau.Clear();
            radionhanvien.Checked = true;
            radioquanly.Checked = false;
            radiohoatdong.Checked = true;
            radiotamngung.Checked = false;
        }

        private void btbthem_Click(object sender, EventArgs e)
        {
            string maNV = txtmanhanvien.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            string xacNhanMK = txtxacnhanmatkhau.Text.Trim();
            bool vaiTro;

            if (radionhanvien.Checked)
            {
                vaiTro = false;
            }
            else
            {
                vaiTro = true;
            }
            bool trangThai;
            if (radiohoatdong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhan viên");
                return;
            }
            //if (!matKhau.Equals(xacNhanMK))
            //{
            //MessageBox.Show("Xác nhận mật khẩu không khớp.");
            //return;
            //}
            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                HoTen = hoTen,
                Email = email,
                MatKhau = matKhau,
                VaiTro = vaiTro,
                TrangThai = trangThai,
            };
            BUSNhanVien bus = new BUSNhanVien();
            string result = bus.InsertNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông thành công");
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void dgvdanhsachnhanvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdanhsachnhanvien.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtmanhanvien.Text = row.Cells["MaNhanVien"].Value.ToString();
            txthoten.Text = row.Cells["HoTen"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtmatkhau.Text = row.Cells["MatKhau"].Value.ToString();
            txtxacnhanmatkhau.Text = row.Cells["MatKhau"].Value.ToString();

            bool vaiTro = Convert.ToBoolean(row.Cells["VaiTro"].Value);
            if (vaiTro == false)
            {
                radionhanvien.Checked = true;
            }
            else
            {
                radioquanly.Checked = true;
            }

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai == false)
            {
                radiohoatdong.Checked = true;
            }
            else
            {
                radiohoatdong.Checked = true;
            }

            // Bật nút "Sửa"
            btbthem.Enabled = false;
            btbsua.Enabled = true;
            btbxoa.Enabled = true;
            // Tắt chỉnh sửa mã nhân viên
            txtmanhanvien.Enabled = false;
        }

        private void btbsua_Click(object sender, EventArgs e)
        {
            string maNV = txtmanhanvien.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();
            string xacNhanMK = txtxacnhanmatkhau.Text.Trim();
            bool vaiTro;

            if (radionhanvien.Checked)
            {
                vaiTro = false;
            }
            else
            {
                vaiTro = true;
            }
            bool trangThai;
            if (radiohoatdong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhan viên");
                return;
            }
            //if (!matKhau.Equals(xacNhanMK))
            //{
            //MessageBox.Show("Xác nhận mật khẩu không khớp.");
            //return;
            //}
            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                HoTen = hoTen,
                Email = email,
                MatKhau = matKhau,
                VaiTro = vaiTro,
                TrangThai = trangThai,
            };
            BUSNhanVien bus = new BUSNhanVien();
            string result = bus.UpdateNhanVien(nv);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông thành công");
                ClearForm();
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btbxoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtmanhanvien.Text.Trim();
            string name = txthoten.Text.Trim();
            if (string.IsNullOrEmpty(maNhanVien))
            {
                if (dgvdanhsachnhanvien.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvdanhsachnhanvien.SelectedRows[0];
                    maNhanVien = selectedRow.Cells["MaNhanVien"].Value.ToString();
                    name = selectedRow.Cells["HoTen"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNhanVien} - {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSNhanVien bus = new BUSNhanVien();
                string kq = bus.DeleteNhanVien(maNhanVien);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin nhân viên {maNhanVien} - {name} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}

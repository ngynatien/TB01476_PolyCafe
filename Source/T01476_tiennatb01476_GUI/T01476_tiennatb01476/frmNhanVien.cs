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
            btbxoa.Enabled = true ;
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
    }
}

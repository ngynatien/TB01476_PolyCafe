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
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void txttim_TextChanged(object sender, EventArgs e)
        {

        }

        private void btbthemloai_Click(object sender, EventArgs e)
        {
            string maLoai = txtmaloai.Text.Trim();
            string tenLoai = txttenloai.Text.Trim();
            string ghiChu = txtghichulaoi.Text.Trim();

            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin thẻ lưu động.");
                return;
            }
            LoaiSanPham loai = new LoaiSanPham
            {
                MaLoai = maLoai,
                TenLoai = tenLoai,
                GhiChu = ghiChu
            };
            BUSLoaiSanPham bus = new BUSLoaiSanPham();
            string result = bus.InsertLoaiSanPham(loai);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachLoaiSP();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachLoaiSP();
        }

        private void btbxoaloai_Click(object sender, EventArgs e)
        {
            string maLoai = txtmaloai.Text.Trim();
            string tenLoai = txttenloai.Text.Trim();
            string ghiChu = txtghichulaoi.Text.Trim();
            if (string.IsNullOrEmpty(maLoai))
            {
                if (dgvdanhsachsanpham.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvdanhsachsanpham.SelectedRows[0];
                    maLoai = selectedRow.Cells["MaLoai"].Value.ToString();
                    tenLoai = selectedRow.Cells["TenLoai"].Value.ToString();
                    ghiChu = selectedRow.Cells["GhiChu"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin loại sản phẩm cần xóa xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại sản phẩm {maLoai} - {tenLoai}?", "Xác nhận xóa",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSLoaiSanPham bus = new BUSLoaiSanPham();
                string kq = bus.DeleteLoaiSanPham(maLoai);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin loại sản phẩm {maLoai} - {tenLoai} thành công!", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachLoaiSP();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btbsualoai_Click(object sender, EventArgs e)
        {
            string maLoai = txtmaloai.Text.Trim();
            string tenLoai = txttenloai.Text.Trim();
            string ghiChu = txtghichulaoi.Text.Trim();

            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin loại sản phẩm.");
                return;
            }
            LoaiSanPham loaiSanPham = new LoaiSanPham
            {
                MaLoai = maLoai,
                TenLoai = tenLoai,
                GhiChu = ghiChu
            };
            BUSLoaiSanPham bus = new BUSLoaiSanPham();
            string result = bus.UpdateLoaiSanPham(loaiSanPham);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachLoaiSP();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btbresetloai_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachLoaiSP();
        }
        private void ClearForm()
        {
            btbthemloai.Enabled = true;
            btbsualoai.Enabled = false;
            btbxoaloai.Enabled = true;
            txtmaloai.Clear();
            txtghichulaoi.Clear();
            txttenloai.Clear();
        }
        private void LoadDanhSachLoaiSP()
        {
            BUSLoaiSanPham busLoaiSp = new BUSLoaiSanPham();
            dgvdanhsachsanpham.DataSource = null;
            dgvdanhsachsanpham.DataSource = busLoaiSp.GetLoaiSanPhamList();
            dgvdanhsachsanpham.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgvdanhsachsanpham.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgvdanhsachsanpham.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvdanhsachsanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvdanhsachsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdanhsachsanpham.Rows[e.RowIndex];
            txtmaloai.Text = row.Cells["MaLoai"].Value.ToString();
            txttenloai.Text = row.Cells["TenLoai"].Value.ToString();
            txtghichulaoi.Text = row.Cells["GhiChu"].Value.ToString();


            btbthemloai.Enabled = false;
            btbsualoai.Enabled = true;
            btbxoaloai.Enabled = true;
            txtmaloai.Enabled = false;
        }

        private void dgvdanhsachsanpham_Resize(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
            txtdongia.Mask = "0000000000";
        }



        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadLoaiSanPham();
            LoadDanhSachSanPham();
        }
        private void ClearForm()
        {
            btbthem.Enabled = true;
            btbsua.Enabled = false;
            btbxoa.Enabled = true;
            txtmasanpham.Clear();
            txttensanpham.Clear();
            txtdongia.Clear();
            rdbhoatdong.Checked = true;
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();
                cboLoaiSanPham.DataSource = dsLoai;
                cboLoaiSanPham.ValueMember = "MaLoai";
                cboLoaiSanPham.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachSanPham()
        {
            BUSSanPham bUSSanPham = new BUSSanPham();
            dgvdanhsachsanpham.DataSource = null;
            List<SanPham> lstSP = bUSSanPham.GetSanPhamList();
            dgvdanhsachsanpham.DataSource = lstSP;
        }
        private void btbthem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txttensanpham.Text.Trim();
                string donGiaText = txtdongia.Text.Trim();
                string maLoai = cboLoaiSanPham.SelectedValue?.ToString();
                bool trangThai = rdbhoatdong.Checked;

                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal donGia;
                if (!decimal.TryParse(donGiaText, out donGia))
                {
                    MessageBox.Show("Đơn giá phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SanPham sp = new SanPham
                {
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai
                };

                BUSSanPham bUSSanPham = new BUSSanPham();
                bUSSanPham.InsertSanPham(sp);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btbsua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txttensanpham.Text.Trim();
                string donGiaText = txtdongia.Text.Trim();
                string maLoai = cboLoaiSanPham.SelectedValue?.ToString();
                bool trangThai = rdbhoatdong.Checked;
                string maSP = txtmasanpham.Text.Trim();

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(donGiaText, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SanPham sp = new SanPham
                {
                    MaSanPham = maSP,
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai

                };

                BUSSanPham bUSSanPham = new BUSSanPham();
                string result = bUSSanPham.UpdateSanPham(sp);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btbxoa_Click(object sender, EventArgs e)
        {
            string maSP = txtmasanpham.Text.Trim();
            string tenSP = string.Empty;
            string hinhAnh = string.Empty;

            if (string.IsNullOrEmpty(maSP))
            {
                if (dgvdanhsachsanpham.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvdanhsachsanpham.SelectedRows[0];
                    maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                    tenSP = selectedRow.Cells["TenSanPham"].Value.ToString();
                    hinhAnh = selectedRow.Cells["HinhAnh"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                tenSP = txttensanpham.Text.Trim();
            }
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} - {tenSP}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSSanPham bus = new BUSSanPham();
                string kq = bus.DeleteSanPham(maSP);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin sản phẩm {maSP} - {tenSP} thành công!", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvdanhsachsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdanhsachsanpham.Rows[e.RowIndex];
            txtmasanpham.Text = row.Cells["MaSanPham"].Value.ToString();
            txttensanpham.Text = row.Cells["TenSanPham"].Value.ToString();
            txtdongia.Text = row.Cells["DonGia"].Value.ToString();
            cboLoaiSanPham.SelectedValue = row.Cells["MaLoai"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdbhoatdong.Checked = true;
            }
            else
            {
                rdbngungban.Checked = true;
            }
            btbthem.Enabled = false;
            btbsua.Enabled = true;
            btbxoa.Enabled = true;
            
        }
    }
}
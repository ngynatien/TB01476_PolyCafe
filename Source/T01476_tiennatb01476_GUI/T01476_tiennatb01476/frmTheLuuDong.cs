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
    public partial class frmTheLuuDong : Form
    {
        public frmTheLuuDong()
        {
            InitializeComponent();
        }

        private void btbthem_Click(object sender, EventArgs e)
        {
            string maThe = txtmathe.Text.Trim();
            string chuSoHuu = txtchusohu.Text.Trim();

            bool trangThai;
            if (cbhoatdong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(chuSoHuu))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin thẻ lưu động.");
                return;
            }
            TheLuuDong theLuuDong = new TheLuuDong()
            {
                MaThe = maThe,
                ChuSoHuu = chuSoHuu,
                TrangThai = trangThai
            };
            BUSTheLuuDong bus = new BUSTheLuuDong();
            string result = bus.InsertTheLuuDong(theLuuDong);

            if (string.IsNullOrEmpty((string)result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachThe();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btbreset_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachThe();
        }

        private void frmTheLuuDong_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachThe();
        }
        private void ClearForm()
        {
            btbthem.Enabled = true;
            btbsua.Enabled = false;
            btbxoa.Enabled = true;
            txtmathe.Clear();
            txtchusohu.Clear();
            cbhoatdong.Checked = true;
        }
        private void LoadDanhSachThe()
        {
            BUSTheLuuDong bUSTheLuuDong = new BUSTheLuuDong();
            dgvtheluudong.DataSource = null;
            dgvtheluudong.DataSource = bUSTheLuuDong.GetTheLuuDongsList();
        }

        private void dgvtheluudong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvtheluudong.Rows[e.RowIndex];
            txtmathe.Text = row.Cells["MaThe"].Value.ToString();
            txtchusohu.Text = row.Cells["ChuSoHuu"].Value.ToString();

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            cbhoatdong.Checked = trangThai;

            btbthem.Enabled = false;
            btbxoa.Enabled = true;
            btbsua.Enabled = true;
            txtmathe.Enabled = false;
        }

        private void btbsua_Click(object sender, EventArgs e)
        {
            string maThe = txtmathe.Text.Trim();
            string chuSoHuu = txtchusohu.Text.Trim();

            bool trangThai;
            if (cbhoatdong.Checked)
            {
                trangThai = true;
            }
            else
            {
                trangThai = false;
            }
            if (string.IsNullOrEmpty(chuSoHuu))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin thẻ lưu động.");
                return;
            }
            TheLuuDong theLuuDong = new TheLuuDong()
            {
                MaThe = maThe,
                ChuSoHuu = chuSoHuu,
                TrangThai = trangThai
            };
            BUSTheLuuDong bus = new BUSTheLuuDong();
            string result = bus.InsertTheLuuDong(theLuuDong);

            if (string.IsNullOrEmpty((string)result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachThe();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btbxoa_Click(object sender, EventArgs e)
        {
            string maThe = txtmathe.Text.Trim();
            string chuSoHuu = txtchusohu.Text.Trim();
            if (string.IsNullOrEmpty(maThe))
            {
                if (dgvtheluudong.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvtheluudong.SelectedRows[0];
                    maThe = selectedRow.Cells["MaThe"].Value.ToString();
                    chuSoHuu = selectedRow.Cells["ChuSoHuu"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một thẻ lưu động để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thẻ lưu động {maThe} - {chuSoHuu}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                BUSTheLuuDong bus = new BUSTheLuuDong();
                string kq = bus.DeleteTheLuuDong(maThe);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin thẻ lưu động {maThe} - {chuSoHuu} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachThe();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btbxoa_Resize(object sender, EventArgs e)
        {

        }

        private void frmTheLuuDong_Resize(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = 10;
        }
    }
}

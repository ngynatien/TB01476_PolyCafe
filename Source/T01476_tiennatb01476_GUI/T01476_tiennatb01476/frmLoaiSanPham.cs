using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}

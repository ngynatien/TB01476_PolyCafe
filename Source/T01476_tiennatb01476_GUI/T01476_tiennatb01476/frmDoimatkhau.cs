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
using UTIL_Poly;

namespace GUI_Poly
{
    public partial class frmDoimatkhau : Form
    {
        public frmDoimatkhau()
        {
            InitializeComponent();
        }
        BUSNhanVien busNhanVien = new BUSNhanVien();
        private void btbdoimatkhau_Click(object sender, EventArgs e)
        {
            if (!AuthUtil.user.MatKhau.Equals(txtmatkhaucu.Text))
            {
                MessageBox.Show(this, "Mật khẩu cũ chưa đúng!!!");
            }
            else
            {
                if (!txtmatkhaumoi.Text.Equals(txtxacnhanmatkhaumoi.Text))
                {
                    MessageBox.Show(this, "Xác nhận mật khẩu mới chưa trùng khớp!!!");
                }
                else
                {


                    if (busNhanVien.ResetMatKhau(AuthUtil.user.Email, txtmatkhaumoi.Text))
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công!!!");

                        AuthUtil.user.MatKhau = txtmatkhaumoi.Text;
                    }
                    else MessageBox.Show("Đổi mật khẩu thất bại, vui lòng kiểm tra lại!!!");
                }
            }
        }
    }
}

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
using UTIL_Poly;

namespace GUI_Poly
{
    public partial class frmLogin : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btbdangnhap_Click(object sender, EventArgs e)
        {
            string username = txttendangnhap.Text;
            string password = txtmatkhau.Text;
            NhanVien nv = busNhanVien.DangNhap(username, password);
            if (nv == null)
            {
                MessageBox.Show(this, "Tài khoản hoạc mật khẩu không chính xác!");
            }
            else
            {
                if (nv.TrangThai == false)
                {
                    MessageBox.Show(this, "Tài khoản đang tạm khóa, vui lòng liên hệ Admin!");
                    return;
                }
                AuthUtil.user = nv;
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
        }
    }
}

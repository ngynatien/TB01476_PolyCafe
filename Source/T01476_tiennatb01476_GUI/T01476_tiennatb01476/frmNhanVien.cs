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

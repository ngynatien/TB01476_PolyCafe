using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Poly;
using DTO_Poly;

namespace BLL_Poly
{
    public class BUSNhanVien
    {
        DALNhanVien dalNhanVien = new DALNhanVien();
        public NhanVien DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            { 
                return null; 
            }
            return dalNhanVien.getNhanVien(username, password);
        }
        public bool ResetMatKhau(string email,  string password)
        {
            try
            {
                if (string.IsNullOrEmpty (email) || string.IsNullOrEmpty (password))
                {
                    return false;
                }
                dalNhanVien.ResetMatKhau(password, email);
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}

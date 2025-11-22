using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Poly;

namespace DAL_Poly
{
    public class DALNhanVien
    {
        public NhanVien getNhanVien(string email, string password)
        {
            string sql = "SELECT * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(password);
            NhanVien nv = DBUtil.Value<NhanVien>(sql, thamSo);
            return nv;
        }
        public void ResetMatKhau(string password,  string email)
        {
            try
            {
                string sql = "UPDATE NhanVien SET MatKhau = @0 WHERE Email =@1";
                List<object> thamSo = new List<object>();
                thamSo.Add(password);
                thamSo.Add(email);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

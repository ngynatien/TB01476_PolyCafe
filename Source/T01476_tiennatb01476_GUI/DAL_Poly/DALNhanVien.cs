using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Poly;
using Microsoft.Data.SqlClient;

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
        public List<NhanVien> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<NhanVien> list = new List<NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    NhanVien entity = new NhanVien();
                    entity.MaNhanVien = reader.GetString("MaNhanVien");
                    entity.HoTen = reader.GetString("HoTen");
                    entity.Email = reader.GetString("Email");
                    entity.MatKhau = reader.GetString("MatKhau");
                    entity.VaiTro = reader.GetBoolean("VaiTro");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }
    }
}

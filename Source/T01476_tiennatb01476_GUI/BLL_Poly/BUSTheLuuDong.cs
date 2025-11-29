using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Poly;
using DTO_Poly;

namespace BLL_Poly
{
    public class BUSTheLuuDong
    {
        DALTheLuuDong dalTheLuuDong = new DALTheLuuDong();
        public List<TheLuuDong> GetTheLuuDongsList()
        {
            return dalTheLuuDong.selectAll();
        }
        public string InsertTheLuuDong(TheLuuDong the)
        {
            try
            {
                the.MaThe = dalTheLuuDong.generateMaTheLuuDong();
                if (string.IsNullOrEmpty(the.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ";
                }
                dalTheLuuDong.insertTheLuuDong(the);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới thành công";
                return "Lỗi: " + ex.Message;
            }
        }
        public string DeleteTheLuuDong(string maThe)
        {
            try
            {
                if (string.IsNullOrEmpty(maThe))
                {
                    return "Mã thẻ lưu động không hợp lệ";
                }
                dalTheLuuDong.deleteTheLuuDong(maThe);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xoa khong thanh khong";
                return "Lỗi: " + ex.Message;
            }
        }
        public string UpdateTheLuuDong(TheLuuDong nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ";
                }
                dalTheLuuDong.updateTheLuuDong(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return"Cap nhat khong thanh cong";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}


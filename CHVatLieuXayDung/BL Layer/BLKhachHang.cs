using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHVatLieuXayDung.DA_Layer;
using System.Data;
using System.Data.SqlClient;

namespace CHVatLieuXayDung.BL_Layer
{
    class BLKhachHang
    {
        DataProvider dp;
        public BLKhachHang(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangKhachHang()
        {
            return dp.ExecuteQueryDataTable("spLayBangKhachHang", CommandType.StoredProcedure);
        }
        public int KiemTraMaKho(string makh)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaKH", CommandType.StoredProcedure, new SqlParameter("@MaKH_kt", makh));
        }
        public DataTable TimKH(string tenkh)
        {
            return dp.ExecuteQueryDataTable("spTimKH", CommandType.StoredProcedure, new SqlParameter("@TenKH", tenkh));
        }
        public bool ThemKhachHang(string makh, string tenkh,string sdt, string diachi,string email, string macn)
        {
            return dp.ExecuteNonQuery("spThemKhachHang", CommandType.StoredProcedure, new SqlParameter("@MaKH", makh), 
                new SqlParameter("@TenKH", tenkh), new SqlParameter("@SDT", sdt),
                new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email), new SqlParameter("@MaCN", macn));
        }
        public bool XoaKH(string makh)
        {
            return dp.ExecuteNonQuery("spXoaKhachHang", CommandType.StoredProcedure, new SqlParameter("@MaKH", makh));
        }
        public bool CapNhatKH(string makh, string tenkh, string sdt, string diachi, string email, string macn)
        {
            return dp.ExecuteNonQuery("spCapNhatKhachHang", CommandType.StoredProcedure, new SqlParameter("@MaKH", makh),
                new SqlParameter("@TenKH", tenkh), new SqlParameter("@SDT", sdt),
                new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email), new SqlParameter("@MaCN", macn));
        }

    }
}

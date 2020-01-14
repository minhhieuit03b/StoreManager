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
    class BLNhaCungCap
    {
        DataProvider dp;
        public BLNhaCungCap(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangNhaCungCap()
        {
            return dp.ExecuteQueryDataTable("spLayBangNhaCungCap", CommandType.StoredProcedure);
        }
        public int KiemTraMaNCC(string mancc)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaNCC", CommandType.StoredProcedure, new SqlParameter("@MaNCC_kt", mancc));
        }
        public DataTable TimNCC(string tenncc)
        {
            return dp.ExecuteQueryDataTable("spTimNCC", CommandType.StoredProcedure, new SqlParameter("@TenNCC", tenncc));
        }
        public bool ThemNCC(string mancc, string tenncc, string sdt, string diachi, string email)
        {
            return dp.ExecuteNonQuery("spThemNhaCungCap", CommandType.StoredProcedure,
                new SqlParameter("@MaNCC", mancc), new SqlParameter("@TenNCC", tenncc), new SqlParameter("@SDT", sdt),
                new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email));
        }
        public bool XoaNCC(string mancc)
        {
            return dp.ExecuteNonQuery("spXoaNhaCungCap", CommandType.StoredProcedure, new SqlParameter("@MaNCC", mancc));
        }
        public bool CapNhatNCC(string mancc, string tenncc, string sdt, string diachi, string email)
        {
            return dp.ExecuteNonQuery("spCapNhatNhaCungCap", CommandType.StoredProcedure,
                new SqlParameter("@MaNCC", mancc), new SqlParameter("@TenNCC", tenncc), new SqlParameter("@SDT", sdt),
                new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email));
        }
    }
}

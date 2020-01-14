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
    class BLKho
    {
        DataProvider dp;
        public BLKho(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangKho()
        {
            return dp.ExecuteQueryDataTable("spLayBangKho", CommandType.StoredProcedure);
        }
        public DataTable ThongKeHangHoaTheoKho(string makho)
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM fnThongKeHangHoaTheoKho('"+makho+"')", CommandType.Text);
        }

        public int KiemTraMaKho(string makho)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaKho", CommandType.StoredProcedure, new SqlParameter("@MaKho_kt", makho));
        }
        public bool ThemKho(string makho,string tenkho,string diachi,string macn)
        {
            return dp.ExecuteNonQuery("spThemKho", CommandType.StoredProcedure, new SqlParameter("@MaKho",makho), new SqlParameter("@TenKho",tenkho),
                new SqlParameter("@DiaChi",diachi), new SqlParameter("@MaCN",macn));
        }
        public bool XoaKho(string makho)
        {
            return dp.ExecuteNonQuery("spXoaKho", CommandType.StoredProcedure, new SqlParameter("@MaKho", makho));
        }
        public bool CapNhatKho(string makho, string tenkho, string diachi, string macn)
        {
            return dp.ExecuteNonQuery("spCapNhatKho", CommandType.StoredProcedure, new SqlParameter("@MaKho", makho), 
                new SqlParameter("@TenKho", tenkho),
                new SqlParameter("@DiaChi", diachi), new SqlParameter("@MaCN", macn));
        }

    }
}

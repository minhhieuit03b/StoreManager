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
    class BLHangHoa
    {
        DataProvider dp;
        public BLHangHoa(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangHangHoa()
        {
            return dp.ExecuteQueryDataTable("spLayBangHangHoa", CommandType.StoredProcedure);
        }
        public DataTable LayMaHHSLTKkhac0()
        {
            return dp.ExecuteQueryDataTable("spLayMahhSLTKkhac0", CommandType.StoredProcedure);
        }
        public DataTable LayGiaTheoMaHH(string MaHH)
        {
            return dp.ExecuteQueryDataTable("SELECT dbo.fnLayGiaTheoMaHH('"+MaHH+"') as gia", CommandType.Text);
        }
        public DataTable LayHHSL0()
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM dbo.fnLayHHcoSL0('0')", CommandType.Text);
        }
        public DataTable LayHHSLDuoi10000()
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM dbo.fnLayHHcoSLduoi10000('10000')", CommandType.Text);
        }
        public DataTable LayHHSLTren10000()
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM dbo.fnLayHHcoSLTren10000('10000')", CommandType.Text);
        }
        public DataTable TimHH(string tenhh)
        {
            return dp.ExecuteQueryDataTable("spTimHH", CommandType.StoredProcedure, new SqlParameter("@TenHH", tenhh));
        }

        public bool ThemHangHoa(string MaHH,string TenHH,int SoLuongTonKho,int Gia,string MaNCC,string MaKho,string GhiChu)
        {
            return dp.ExecuteNonQuery("spThemHangHoa", CommandType.StoredProcedure,new SqlParameter("@MaHH",MaHH), 
                new SqlParameter("@TenHH",TenHH), new SqlParameter("@SoLuongTonKho",SoLuongTonKho), 
                new SqlParameter("@GiaHH",Gia), new SqlParameter("@MaNCC",MaNCC), new SqlParameter("@MaKho",MaKho), 
                new SqlParameter("@GhiChu",GhiChu));
        }
        public int KiemTraMaHH(string MaHH)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaHH", CommandType.StoredProcedure, new SqlParameter("@MaHH_kt", MaHH));
        }
        public bool XoaHangHoa(string MaHH)
        {
            return dp.ExecuteNonQuery("spXoaHangHoa", CommandType.StoredProcedure, new SqlParameter("@MaHH", MaHH));
        }
        public bool CapNhatHangHoa(string MaHH, string TenHH, int SoLuongTonKho, int Gia, string MaNCC, string MaKho, string GhiChu)
        {
            return dp.ExecuteNonQuery("spCapNhatHangHoa", CommandType.StoredProcedure, new SqlParameter("@MaHH", MaHH),
                new SqlParameter("@TenHH", TenHH), new SqlParameter("@SoLuongTonKho", SoLuongTonKho),
                new SqlParameter("@GiaHH", Gia), new SqlParameter("@MaNCC", MaNCC), new SqlParameter("@MaKho", MaKho),
                new SqlParameter("@GhiChu", GhiChu));
        }

    }
}

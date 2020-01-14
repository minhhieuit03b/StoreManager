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
    class BLPhieuNhap
    {
        DataProvider dp;
        public BLPhieuNhap(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangPhieuNhap()
        {
            return dp.ExecuteQueryDataTable("spLayBangPhieuNhap", CommandType.StoredProcedure);
        }
        public DataTable LayNgayNhap()
        {
            return dp.ExecuteQueryDataTable("spLayNgayNhap", CommandType.StoredProcedure);
        }
        public DataTable ThongKeChiPhiMuaTheoNgay(string ngay)
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM dbo.fnThongKeChiPhiMuaTheoNgay('"+ngay+"')", CommandType.Text);
        }
        public int KiemTraMaPN(string mapn)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaPN", CommandType.StoredProcedure, new SqlParameter("@MaPN_kt", mapn));
        }
        public bool ThemPN(string mapn, string manv, string mahh, string mancc, string ngaynhap , string ghichu,string xuly,int soluong,int gia )
        {
            return dp.ExecuteNonQuery("spThemPhieuNhapHang", CommandType.StoredProcedure,
                new SqlParameter("@MaPN", mapn), new SqlParameter("@MaNV", manv), new SqlParameter("@MaHH", mahh),
                new SqlParameter("@MaNCC", mancc), new SqlParameter("@NgayNhap", ngaynhap), new SqlParameter("@GhiChu", ghichu),
                new SqlParameter("@XuLy", xuly), new SqlParameter("@SoLuong", soluong) ,new SqlParameter("@DonGia", gia));
        }
        public bool XoaPN(string mapn)
        {
            return dp.ExecuteNonQuery("spXoaPhieuNhap", CommandType.StoredProcedure, new SqlParameter("@MaPN", mapn));
        }
        public bool CapNhatPN(string mapn, string manv, string mahh, string mancc, string ngaynhap, string ghichu, string xuly, int soluong, int gia)
        {
            return dp.ExecuteNonQuery("spCapNhatPhieuNhap", CommandType.StoredProcedure,
                new SqlParameter("@MaPN", mapn), new SqlParameter("@MaNV", manv), new SqlParameter("@MaHH", mahh),
                new SqlParameter("@MaNCC", mancc), new SqlParameter("@NgayNhap", ngaynhap), new SqlParameter("@GhiChu", ghichu),
                new SqlParameter("@XuLy", xuly), new SqlParameter("@SoLuong", soluong), new SqlParameter("@DonGia", gia));
        }

    }
}

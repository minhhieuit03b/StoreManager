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
    class BLPhieuXuat
    {
        DataProvider dp;
        public BLPhieuXuat(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangPhieuXuat()
        {
            return dp.ExecuteQueryDataTable("spLayBangPhieuXuat", CommandType.StoredProcedure);
        }
        public DataTable LayNgayXuat()
        {
            return dp.ExecuteQueryDataTable("spLayNgayXuat", CommandType.StoredProcedure);
        }
        public DataTable ThongKeDoanhThuTheoNgay(string ngay)
        {
            return dp.ExecuteQueryDataTable("SELECT * FROM dbo.fnThongKeDoanhThuTheoNgay('" + ngay + "')", CommandType.Text);
        }
        public int KiemTraMaPX(string mapx)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaPX", CommandType.StoredProcedure, new SqlParameter("@MaPX_kt", mapx));
        }
        public bool ThemPX(string mapx, string manv, string makh, string mahh, string ngayxuat, string ghichu, string xuly, int soluong, int gia)
        {
            return dp.ExecuteNonQuery("spThemPhieuXuatHang", CommandType.StoredProcedure,
                new SqlParameter("@MaPX", mapx), new SqlParameter("@MaNV", manv), new SqlParameter("@MaKH", makh),
                new SqlParameter("@MaHH", mahh), new SqlParameter("@NgayXuat", ngayxuat), new SqlParameter("@GhiChu", ghichu),
                new SqlParameter("@XuLy", xuly), new SqlParameter("@SoLuong", soluong), new SqlParameter("@DonGia", gia));
        }
        public bool XoaPX(string mapx)
        {
            return dp.ExecuteNonQuery("spXoaPhieuXuat", CommandType.StoredProcedure, new SqlParameter("@MaPX", mapx));
        }
        public bool CapNhatPX(string mapx, string manv, string makh, string mahh, string ngayxuat, string ghichu, string xuly, int soluong, int gia)
        {
            return dp.ExecuteNonQuery("spCapNhatPhieuXuat", CommandType.StoredProcedure,
                new SqlParameter("@MaPX", mapx), new SqlParameter("@MaNV", manv), new SqlParameter("@MaKH", makh),
                new SqlParameter("@MaHH", mahh), new SqlParameter("@NgayXuat", ngayxuat), new SqlParameter("@GhiChu", ghichu),
                new SqlParameter("@XuLy", xuly), new SqlParameter("@SoLuong", soluong), new SqlParameter("@DonGia", gia));
        }

    }
}

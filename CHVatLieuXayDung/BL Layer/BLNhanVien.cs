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
    class BLNhanVien
    {
        DataProvider dp;
        public BLNhanVien(string dbsource, string id, string pass)
        {
            dp = new DataProvider(dbsource, id, pass);
            dp.InitialConnectionString(dbsource, id, pass);
        }
        public DataTable LayBangNhanVien()
        {
            return dp.ExecuteQueryDataTable("spLayBangNhanVien", CommandType.StoredProcedure);
        }
        public DataTable TimNV(string tennv)
        {
            return dp.ExecuteQueryDataTable("spTimNV", CommandType.StoredProcedure,new SqlParameter("@TenNV",tennv));
        }
        public DataTable LayNVtheoGT(string gioitinh)
        {
            return dp.ExecuteQueryDataTable("spLayNVtheoGT", CommandType.StoredProcedure, new SqlParameter("@GioiTinh", gioitinh));
        }
        public bool DoiMatKhau(string manv, string mkcu, string mkmoi)
        {
            return dp.ExecuteNonQuery("spDoiMatKhau", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv), new SqlParameter("@MKCu", mkcu), new SqlParameter("@MKMoi", mkmoi));
        }
        public DataTable QuenMK(string manv, string sdtvaemail)
        {
            return dp.ExecuteQueryDataTable("spLayMK", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv), new SqlParameter("@SDTandMail", sdtvaemail));
        }
        public DataTable LayThongTinNV(string manv)
        {
            return dp.ExecuteQueryDataTable("spLayThongTinNV", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv));
        }
        public int KiemTraQuyen(string manv)
        {
            return dp.ExecuteScalar<int>("spKiemTraQuyen", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv));
        }
        public int KiemTraMaNV(string manv)
        {
            return dp.ExecuteScalar<int>("spKiemTraMaNV", CommandType.StoredProcedure, new SqlParameter("@MaNV_kt", manv));
        }
        public bool ThemNV(string manv,string tennv, string gioitinh, string sdt, string diachi, string email, string matkhau, string quyen, string chinhanh)
        {
            return dp.ExecuteNonQuery("spThemNhanVien", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv), new SqlParameter("@TenNV", tennv), 
                new SqlParameter("@GioiTinh", gioitinh), new SqlParameter("@SDT", sdt), new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email), 
                new SqlParameter("@MatKhau", matkhau), new SqlParameter("@Quyen", quyen), new SqlParameter("@MaCN", chinhanh));
        }
        public bool XoaNV(string manv)
        {
            return dp.ExecuteNonQuery("spXoaNhanVien", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv));
        }
        public bool CapNhatNV(string manv, string tennv, string gioitinh, string sdt, string diachi, string email, string matkhau, string quyen, string chinhanh)
        {
            return dp.ExecuteNonQuery("spCapNhatNhanVien", CommandType.StoredProcedure, new SqlParameter("@MaNV", manv), new SqlParameter("@TenNV", tennv),
                new SqlParameter("@GioiTinh", gioitinh), new SqlParameter("@SDT", sdt), new SqlParameter("@DiaChi", diachi), new SqlParameter("@Email", email),
                new SqlParameter("@MatKhau", matkhau), new SqlParameter("@Quyen", quyen), new SqlParameter("@MaCN", chinhanh));
        }

    }
}

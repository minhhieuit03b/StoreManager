using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHVatLieuXayDung.DA_Layer;
using CHVatLieuXayDung.BL_Layer;
using System.Data.SqlClient;

namespace CHVatLieuXayDung
{
    public partial class frmThongTinCaNhan : Form
    {
        BLNhanVien dbNhanVien;
        DataTable dt = null;
        public frmThongTinCaNhan()
        {
            InitializeComponent();
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }
        private void FrmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Clear();
            dt = dbNhanVien.LayThongTinNV(frmDangNhap.Manv);
            lbManv.Text = dt.Rows[0][0].ToString();
            lbTen.Text = dt.Rows[0][1].ToString();
            lbGioiTinh.Text = dt.Rows[0][2].ToString();
            lbSDT.Text = dt.Rows[0][3].ToString();
            lbDiaChi.Text = dt.Rows[0][4].ToString();
            lbEmail.Text = dt.Rows[0][5].ToString();
            lbMK.Text = dt.Rows[0][6].ToString();
            lbQuyen.Text = dt.Rows[0][7].ToString();
            lbChiNhanh.Text = dt.Rows[0][8].ToString();

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}

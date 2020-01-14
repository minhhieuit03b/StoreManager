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
    public partial class frmThongTinChiNhanh : Form
    {
        BLChiNhanh dbChiNhanh;
        DataTable dt = null;
        public frmThongTinChiNhanh()
        {
            InitializeComponent();
            dbChiNhanh = new BLChiNhanh(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }

        private void FrmThongTinChiNhanh_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Clear();
            dt = dbChiNhanh.LayThongTinCN();

            lbMaCN.Text = dt.Rows[0][0].ToString();
            lbTen.Text = dt.Rows[0][1].ToString();
            lbSDT.Text = dt.Rows[0][2].ToString();
            lbDiaChi.Text = dt.Rows[0][3].ToString();
            lbTG.Text = dt.Rows[0][4].ToString();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
                this.Close();
        }
    }
}

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
    public partial class frmQuenMatKhau : Form
    {
        BLNhanVien dbNhanVien;
        DataProvider pro;
        DataTable dt = null;
        public string da = "COMPUTER\\YUKITRAN";
        public string id = "sa";
        public string pass = "123";
        public frmQuenMatKhau()
        {
            InitializeComponent();
            dbNhanVien = new BLNhanVien(da, id, pass);
        }

        private void BntApDung_Click(object sender, EventArgs e)
        {
            pro = new DataProvider(da,id,pass);
            if (pro.TestConnection(da, id, pass) == true)
            {
                dt = dbNhanVien.QuenMK(txtManv.Text, txtSDTvaEmail.Text);
                txtMK.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TL = MessageBox.Show("Bạn Muốn Đổi Lại Mật Khẩu Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TL == DialogResult.OK)
            {
                frmDoiMatKhau f = new frmDoiMatKhau();
                f.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }
    }
}

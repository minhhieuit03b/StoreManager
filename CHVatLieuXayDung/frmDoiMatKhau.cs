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
    public partial class frmDoiMatKhau : Form
    {
        BLNhanVien dbNhanVien;
        public frmDoiMatKhau()
        {
            InitializeComponent();
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TL = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (TL == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void BntApDung_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtManv.Text == "" && txtMkcu.Text == "" && txtMkmoi.Text == "")
                {
                    MessageBox.Show("Chưa Điền Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dbNhanVien.DoiMatKhau(txtManv.Text, txtMkcu.Text, txtMkmoi.Text);
                    DialogResult TL = MessageBox.Show("Đổi Thành Công! Bạn Muốn Thoát", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (TL == DialogResult.OK)
                    {
                        this.Close();
                        //frmDangNhap fdn = new frmDangNhap();
                        //this.ParentForm.Close();
                        //fdn.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thành công !Sai Thông Tin ?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtManv.Text = frmDangNhap.Manv;
            txtManv.Enabled = false;
        }
    }
}

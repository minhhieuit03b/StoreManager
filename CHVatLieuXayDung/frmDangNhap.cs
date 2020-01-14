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

namespace CHVatLieuXayDung
{
    public partial class frmDangNhap : Form
    {
        public static string Manv;
        public string dbsource;
        DataProvider dbvinder;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            if(radioButtonCN1.Checked == true)
            {
                this.dbsource = "COMPUTER\\YUKITRAN2";
                dbvinder = new DataProvider(this.dbsource, txtDN.Text, txtMK.Text);
                if (dbvinder.TestConnection(this.dbsource, txtDN.Text, txtMK.Text) == true)
                {
                    MessageBox.Show("Kết Nối Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Manv = txtDN.Text;
                    this.Hide();
                    frmMain fmain = new frmMain();
                    fmain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không Thành Công!Sai tài khoản","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else if (radioButtonCN2.Checked == true)
            {
                this.dbsource = "COMPUTER\\YUKITRAN3";
                dbvinder = new DataProvider(this.dbsource, txtDN.Text, txtMK.Text);
                if (dbvinder.TestConnection(this.dbsource, txtDN.Text, txtMK.Text) == true)
                {
                    MessageBox.Show("Kết Nối Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Manv = txtDN.Text;
                    this.Visible = false;
                    frmMain fmain = new frmMain();
                    fmain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không Thành Công! Sai tài khoản?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa Chọn Chi Nhánh Cần Đăng Nhập !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TL = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (TL == DialogResult.OK)
            {
                this.Close();
                System.Windows.Forms.Application.Exit();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau f = new frmQuenMatKhau();
            f.ShowDialog();
        }
    }
}

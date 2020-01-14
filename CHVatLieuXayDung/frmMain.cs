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
    public partial class frmMain : Form
    {
        BLNhanVien dbNhanVien;
        bool KT;
        public frmMain()
        {
            InitializeComponent();
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }

        private void XemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXem xm = new frmXem();
            xm.ShowDialog();
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap fdn = new frmDangNhap();
            fdn.Show();
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau fdmk = new frmDoiMatKhau();
            fdmk.ShowDialog();
        }

        private void ThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan ftt = new frmThongTinCaNhan();
            ftt.ShowDialog();
        }

        private void HàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa fhh = new frmHangHoa();
            fhh.ShowDialog();
        }

        private void KhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho fk = new frmKho();
            fk.ShowDialog();
        }

        private void NhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap fncc = new frmNhaCungCap();
            fncc.ShowDialog();
        }

        private void ThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinChiNhanh fttcn = new frmThongTinChiNhanh();
            fttcn.ShowDialog();
        }

        private void KháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang fkh = new frmKhachHang();
            fkh.ShowDialog();
        }

        private void PhiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhapHang fpn = new frmPhieuNhapHang();
            fpn.ShowDialog();
        }

        private void PhiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuatHang fpxh = new frmPhieuXuatHang();
            fpxh.ShowDialog();
        }

        private void NhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (KT == true)
            {
                frmNhanVien fnv = new frmNhanVien();
                fnv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn Không Có Quyền Thao Tác !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if(dbNhanVien.KiemTraQuyen(frmDangNhap.Manv) == 1)
            {
                KT = true;
            }
            else
            {
                KT = false;
            }
        }
    }
}

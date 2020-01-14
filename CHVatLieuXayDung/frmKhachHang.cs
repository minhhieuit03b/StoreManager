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
    public partial class frmKhachHang : Form
    {
        BLKhachHang dbKhachHang;
        bool them;
        DataTable dtKhachHang = null;
        public frmKhachHang()
        {
            InitializeComponent();
            dbKhachHang = new BLKhachHang(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }
        void LoadData()
        {
            try
            {
                DvgKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DvgKhachHang.Enabled = true;
                //
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                //
                dtKhachHang = dbKhachHang.LayBangKhachHang();
                DvgKhachHang.DataSource = dtKhachHang;
                //
                this.btnHuy.Enabled = false;
                this.btnLuu.Enabled = false;
                //
                this.btnSua.Enabled = true;
                this.btnTaiLai.Enabled = true;
                this.btnThem.Enabled = true;
                this.btnTroVe.Enabled = true;
                this.btnXoa.Enabled = true;
                //
                this.txtTimKH.Enabled = true;
                this.btnTim.Enabled = true;
                this.txtTimKH.ResetText();
                //
                this.txtDiaChi.Enabled = false;
                this.txtTenKH.Enabled = false;
                this.txtMaKH.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtSDT.Enabled = false;
                //
                this.txtMaCN.Enabled = false;
                //
                DvgKhachHang_CellClick(null, null);
                this.txtMaKH.Focus();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Rồi! Không Load Được Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            //
            this.txtDiaChi.Enabled = true;
            this.txtTenKH.Enabled = true;
            this.txtMaKH.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtSDT.Enabled = true;
            //
            this.txtTimKH.Enabled = false;
            this.btnTim.Enabled = false;
            this.txtTimKH.ResetText();
            //
            this.txtDiaChi.ResetText();
            this.txtTenKH.ResetText();
            this.txtMaKH.ResetText();
            this.txtEmail.ResetText();
            this.txtSDT.ResetText();
            //
            this.txtMaKH.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            them = false;
            //
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            //
            this.txtTimKH.Enabled = false;
            this.btnTim.Enabled = false;
            //
            this.txtDiaChi.Enabled = true;
            this.txtTenKH.Enabled = true;
            this.txtMaKH.Enabled = false;
            this.txtEmail.Enabled = true;
            this.txtSDT.Enabled = true;
            //
            this.txtMaKH.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbKhachHang.XoaKH(this.txtMaKH.Text) == true)
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    LoadData();
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không Xóa được. Lỗi rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                if (dbKhachHang.KiemTraMaKho(txtMaKH.Text) == 0)
                {
                    if (dbKhachHang.ThemKhachHang(this.txtMaKH.Text, this.txtTenKH.Text,this.txtSDT.Text, this.txtDiaChi.Text,this.txtEmail.Text, this.txtMaCN.Text) == true)
                    {
                        MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không Thể Thêm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Trùng Mã Khách Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbKhachHang.CapNhatKH(this.txtMaKH.Text, this.txtTenKH.Text, this.txtSDT.Text, this.txtDiaChi.Text, this.txtEmail.Text, this.txtMaCN.Text) == true)
                {
                    MessageBox.Show("Cập nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không Thể Cập Nhật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnTroVe_Click(object sender, EventArgs e)
        {
            DialogResult TL = MessageBox.Show("Bạn có chắc muốn trở về?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (TL == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DvgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = DvgKhachHang.CurrentCell.RowIndex;
            txtMaKH.Text = DvgKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenKH.Text = DvgKhachHang.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = DvgKhachHang.Rows[r].Cells[2].Value.ToString();
            txtDiaChi.Text = DvgKhachHang.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = DvgKhachHang.Rows[r].Cells[4].Value.ToString();
            txtMaCN.Text = DvgKhachHang.Rows[r].Cells[5].Value.ToString();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            DataTable dtTim;
            dtTim = dbKhachHang.TimKH(txtTimKH.Text);
            DvgKhachHang.DataSource = dtTim;
        }
    }
}

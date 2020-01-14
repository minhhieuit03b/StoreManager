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
    public partial class frmNhaCungCap : Form
    {
        BLNhaCungCap dbNhaCungCap;
        bool them;
        DataTable dtNhaCC = null;
        public frmNhaCungCap()
        {
            InitializeComponent();
            dbNhaCungCap = new BLNhaCungCap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }
        void LoadData()
        {
            try
            {
                DvgNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DvgNCC.Enabled = true;
                //
                dtNhaCC = new DataTable();
                dtNhaCC.Clear();
                //
                dtNhaCC = dbNhaCungCap.LayBangNhaCungCap();
                DvgNCC.DataSource = dtNhaCC;
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
                this.txtTimNCC.Enabled = true;
                this.btnTim.Enabled = true;
                this.txtTimNCC.ResetText();
                //
                this.txtDiaChi.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtMaNCC.Enabled = false;
                this.txtTenNCC.Enabled = false;
                this.txtSDT.Enabled = false;
                //
                DvgNCC_CellClick(null, null);
                this.txtMaNCC.Focus();
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
            this.txtTenNCC.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();
            this.txtMaNCC.ResetText();
            //
            this.txtDiaChi.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtMaNCC.Enabled = true;
            this.txtTenNCC.Enabled = true;
            this.txtSDT.Enabled = true;
            //
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //
            this.txtTimNCC.Enabled = false;
            this.btnTim.Enabled = false;
            this.txtTimNCC.ResetText();
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            //
            this.txtMaNCC.Focus();
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
            this.txtTimNCC.Enabled = false;
            this.btnTim.Enabled = false;
            //
            this.txtDiaChi.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtMaNCC.Enabled = false;
            this.txtSDT.Enabled = true;
            this.txtTenNCC.Enabled = true;
            //
            this.txtMaNCC.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbNhaCungCap.XoaNCC(this.txtMaNCC.Text) == true)
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
                if (dbNhaCungCap.KiemTraMaNCC(txtMaNCC.Text) == 0)
                {
                    if (dbNhaCungCap.ThemNCC(this.txtMaNCC.Text, this.txtTenNCC.Text, this.txtSDT.Text, this.txtDiaChi.Text, this.txtEmail.Text) == true)
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
                    MessageBox.Show("Trùng Mã NCC", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbNhaCungCap.CapNhatNCC(this.txtMaNCC.Text, this.txtTenNCC.Text, this.txtSDT.Text, this.txtDiaChi.Text, this.txtEmail.Text) == true)
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

        private void DvgNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = DvgNCC.CurrentCell.RowIndex;
            txtMaNCC.Text = DvgNCC.Rows[r].Cells[0].Value.ToString();
            txtTenNCC.Text = DvgNCC.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = DvgNCC.Rows[r].Cells[2].Value.ToString();
            txtDiaChi.Text = DvgNCC.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = DvgNCC.Rows[r].Cells[4].Value.ToString();
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            DataTable dtTim;
            dtTim = dbNhaCungCap.TimNCC(txtTimNCC.Text);
            DvgNCC.DataSource = dtTim;
        }
    }
}

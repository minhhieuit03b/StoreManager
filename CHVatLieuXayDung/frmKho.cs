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
    public partial class frmKho : Form
    {
        BLKho dbKho;
        BLChiNhanh dbChiNhanh;
        bool them;
        DataTable dtKho = null;
        public frmKho()
        {
            dbKho = new BLKho(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbChiNhanh = new BLChiNhanh(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                DvgKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DvgKho.Enabled = true;
                //
                dtKho = new DataTable();
                dtKho.Clear();
                //
                dtKho = dbKho.LayBangKho();
                DvgKho.DataSource = dtKho;
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
                this.txtDiaChi.Enabled = false;
                this.txtTenKho.Enabled = false;
                this.txtMaKho.Enabled = false;
                //
                this.txtMaCN.Enabled = false;
                //
                DvgKho_CellClick(null, null);
                this.txtMaKho.Focus();
                //
                LoadMaKho(cbMaKho);
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi Rồi! Không Load Được Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadMaCN(TextBox t)
        {
            DataTable dt;
            dt = new DataTable();
            dt = dbChiNhanh.LayBangChiNhanh();
            txtMaCN.Text = dt.Rows[0][0].ToString();
        }
        void LoadMaKho(ComboBox cb)
        {
            cbMaKho.DataSource = dbKho.LayBangKho();
            cbMaKho.ValueMember = "MaKho";
            cbMaKho.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //
            this.txtDiaChi.ResetText();
            this.txtTenKho.ResetText();
            this.txtMaKho.ResetText();
            //
            this.txtDiaChi.Enabled = true;
            this.txtTenKho.Enabled = true;
            this.txtMaKho.Enabled = true;
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
            LoadMaCN(txtMaCN);
            //
            this.txtMaKho.Focus();
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
            this.txtMaKho.Enabled = false;
            this.txtTenKho.Enabled = true;
            this.txtDiaChi.Enabled = true;
            //
            this.txtMaKho.Focus();
            //
            LoadMaCN(txtMaCN);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbKho.XoaKho(this.txtMaKho.Text) == true)
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
                if (dbKho.KiemTraMaKho(txtMaKho.Text) == 0)
                {
                    if (dbKho.ThemKho(this.txtMaKho.Text, this.txtTenKho.Text, this.txtDiaChi.Text, this.txtMaCN.Text) == true)
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
                    MessageBox.Show("Trùng Mã Kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbKho.CapNhatKho(this.txtMaKho.Text, this.txtTenKho.Text, this.txtDiaChi.Text, this.txtMaCN.Text) == true)
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

        private void FrmKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DvgKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = DvgKho.CurrentCell.RowIndex;
            txtMaKho.Text = DvgKho.Rows[r].Cells[0].Value.ToString();
            txtTenKho.Text = DvgKho.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text = DvgKho.Rows[r].Cells[2].Value.ToString();
            txtMaCN.Text = DvgKho.Rows[r].Cells[3].Value.ToString();
        }
        private void BtnTim_Click(object sender, EventArgs e)
        {
            DataTable dtt;
            dtt = new DataTable();
            dtt.Clear();
            dtt = dbKho.ThongKeHangHoaTheoKho(cbMaKho.Text);
            DvgKho.DataSource = dtt;
            txtDiaChi.Text = "";
            txtMaCN.Text = "";
            txtMaKho.Text = "";
            txtTenKho.Text = "";
            DvgKho.Enabled = false;
            DvgKho.Rows[0].Selected = false;
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = true;
            this.btnXoa.Enabled = false;
        }
    }
}

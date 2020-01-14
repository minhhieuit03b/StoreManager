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
    public partial class frmHangHoa : Form
    {
        BLHangHoa dbHangHoa;
        BLKho dbKho;
        BLNhaCungCap dbNhaCungCap;
        bool them;
        DataTable dtHangHoa = null;
        public frmHangHoa()
        {
            dbHangHoa = new BLHangHoa(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbKho = new BLKho(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhaCungCap = new BLNhaCungCap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dvgTableHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dvgTableHangHoa.Enabled = true;
                //
                dtHangHoa = new DataTable();
                dtHangHoa.Clear();
                //
                dtHangHoa = dbHangHoa.LayBangHangHoa();
                dvgTableHangHoa.DataSource = dtHangHoa;
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
                this.txtTimHH.Enabled = true;
                this.btnTim.Enabled = true;
                this.txtTimHH.ResetText();
                //
                this.txtGia.Enabled = false;
                this.cbKho.Enabled = false;
                this.txtMaHH.Enabled = false;
                this.cbMaNCC.Enabled = false;
                this.txtSLTonKho.Enabled = false;
                this.txtTenHH.Enabled = false;
                this.rtbGhiChu.Enabled = false;
                //
                DvgTableHangHoa_CellClick(null, null);
                this.txtMaHH.Focus();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Rồi! Không Load Được Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadMaNCC(ComboBox cb)
        {
            cbMaNCC.DataSource = dbNhaCungCap.LayBangNhaCungCap();
            cbMaNCC.ValueMember = "MaNCC";
            cbMaNCC.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadMaKho(ComboBox cb)
        {
            cbKho.DataSource = dbKho.LayBangKho();
            cbKho.ValueMember = "MaKho";
            cbKho.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //
            this.rtbGhiChu.ResetText();
            this.txtGia.ResetText();
            this.cbKho.ResetText();
            this.txtMaHH.ResetText();
            this.cbMaNCC.ResetText();
            this.txtSLTonKho.ResetText();
            this.txtTenHH.ResetText();
            //
            this.txtGia.Enabled = true;
            this.cbMaNCC.Enabled = true;
            this.txtMaHH.Enabled = true;
            this.cbKho.Enabled = true;
            this.txtSLTonKho.Enabled = true;
            this.txtTenHH.Enabled = true;
            this.rtbGhiChu.Enabled = true;
            //
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //
            this.txtTimHH.Enabled = false;
            this.btnTim.Enabled = false;
            this.txtTimHH.ResetText();
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            //
            radioButtonBang0.Checked = false;
            radioButtonDuoi10000.Checked = false;
            radioButtonTren10000.Checked = false;
            //
            this.txtMaHH.Focus();
            //
            LoadMaKho(cbKho);
            LoadMaNCC(cbMaNCC);
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
            this.txtGia.Enabled = true;
            this.cbMaNCC.Enabled = true;
            this.txtMaHH.Enabled = false;
            this.cbKho.Enabled = true;
            this.txtSLTonKho.Enabled = true;
            this.txtTenHH.Enabled = true;
            this.rtbGhiChu.Enabled = true;
            //
            this.txtTimHH.Enabled = false;
            this.btnTim.Enabled = false;
            //
            LoadMaKho(cbKho);
            LoadMaNCC(cbMaNCC);
            //
            this.txtMaHH.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            radioButtonBang0.Checked = false;
            radioButtonDuoi10000.Checked = false;
            radioButtonTren10000.Checked = false;
            radioButtonBang0.Enabled = true;
            radioButtonDuoi10000.Enabled = true;
            radioButtonTren10000.Enabled = true;
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbHangHoa.XoaHangHoa(this.txtMaHH.Text) == true)
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
            int SoLuong = int.Parse(txtSLTonKho.Text);
            int Gia = int.Parse(txtGia.Text);
            radioButtonBang0.Checked = false;
            radioButtonDuoi10000.Checked = false;
            radioButtonTren10000.Checked = false;
            radioButtonBang0.Enabled = true;
            radioButtonDuoi10000.Enabled = true;
            radioButtonTren10000.Enabled = true;
            if (them == true)
            {
                if (dbHangHoa.KiemTraMaHH(txtMaHH.Text) == 0)
                {
                    if (dbHangHoa.ThemHangHoa(this.txtMaHH.Text, this.txtTenHH.Text, SoLuong, Gia, this.cbMaNCC.Text, this.cbKho.Text, this.rtbGhiChu.Text) == true)
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
                    MessageBox.Show("Trùng Mã Hàng Hóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbHangHoa.CapNhatHangHoa(this.txtMaHH.Text, this.txtTenHH.Text, SoLuong, Gia, this.cbMaNCC.Text, this.cbKho.Text, this.rtbGhiChu.Text) == true)
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

            radioButtonBang0.Enabled = true;
            radioButtonDuoi10000.Enabled = true;
            radioButtonTren10000.Enabled = true;
            LoadData();
            radioButtonBang0.Checked = false;
            radioButtonDuoi10000.Checked = false;
            radioButtonTren10000.Checked = false;
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadData();
            radioButtonBang0.Checked = false;
            radioButtonDuoi10000.Checked = false;
            radioButtonTren10000.Checked = false;
            radioButtonBang0.Enabled = true;
            radioButtonDuoi10000.Enabled = true;
            radioButtonTren10000.Enabled = true;
        }
        private void FrmHangHoa_Load(object sender, EventArgs e)
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

        private void DvgTableHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dvgTableHangHoa.CurrentCell.RowIndex;
            txtMaHH.Text = dvgTableHangHoa.Rows[r].Cells[0].Value.ToString();
            txtTenHH.Text = dvgTableHangHoa.Rows[r].Cells[1].Value.ToString();
            txtSLTonKho.Text = dvgTableHangHoa.Rows[r].Cells[2].Value.ToString();
            txtGia.Text = dvgTableHangHoa.Rows[r].Cells[3].Value.ToString();
            cbMaNCC.Text = dvgTableHangHoa.Rows[r].Cells[4].Value.ToString();
            cbKho.Text = dvgTableHangHoa.Rows[r].Cells[5].Value.ToString();
            rtbGhiChu.Text = dvgTableHangHoa.Rows[r].Cells[6].Value.ToString();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            DataTable dtTim;
            dtTim = dbHangHoa.TimHH(txtTimHH.Text);
            dvgTableHangHoa.DataSource = dtTim;
            this.btnSua.Enabled = true;
            this.btnTaiLai.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTim.Enabled = true;
            radioButtonBang0.Enabled = false;
            radioButtonDuoi10000.Enabled = false;
            radioButtonTren10000.Enabled = false;
        }
        void LoadKhiCheck()
        {
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTim.Enabled = false;
            txtTimHH.Enabled = false;
        }
        private void RadioButtonBang0_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonBang0.Checked == true)
            {
                LoadKhiCheck();
                dvgTableHangHoa.DataSource = dbHangHoa.LayHHSL0();
            }
            else
            {
                LoadData();
            }
        }

        private void RadioButtonDuoi10000_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDuoi10000.Checked == true)
            {
                LoadKhiCheck();
                dvgTableHangHoa.DataSource = dbHangHoa.LayHHSLDuoi10000();
            }
            else
            {
                LoadData();
            }
        }

        private void RadioButtonTren10000_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTren10000.Checked == true)
            {
                LoadKhiCheck();
                dvgTableHangHoa.DataSource = dbHangHoa.LayHHSLTren10000();
            }
            else
            {
                LoadData();
            }
        }
    }
}

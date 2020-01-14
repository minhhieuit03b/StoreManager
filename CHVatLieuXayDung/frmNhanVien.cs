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
    public partial class frmNhanVien : Form
    {
        BLNhanVien dbNhanVien;
        BLChiNhanh dbChiNhanh;
        bool them;
        DataTable dtNhanVien = null;
        DataTable dtgioitinh = null;
        public frmNhanVien()
        {
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbChiNhanh = new BLChiNhanh(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dvgNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dvgNV.Enabled = true;
                //
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                //
                dtgioitinh = new DataTable();
                dtgioitinh.Clear();
                //
                dtNhanVien = dbNhanVien.LayBangNhanVien();
                dvgNV.DataSource = dtNhanVien;
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
                checkBoxKhac.Enabled = true;
                checkBoxNam.Enabled = true;
                checkBoxNu.Enabled = true;
                //
                this.txtMaNV.Enabled = false;
                this.txtTenNV.Enabled = false;
                this.cbGioiTinh.Enabled = false;
                this.txtSDT.Enabled = false;
                this.txtDiaChi.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtMK.Enabled = false;
                this.cbQuyen.Enabled = false;
                //
                this.txtTimNV.Enabled = true;
                this.btnTim.Enabled = true;
                this.txtTimNV.ResetText();
                //
                this.txtCN.Enabled = false;
                //
                DvgNV_CellClick(null, null);
                this.txtMaNV.Focus();
                //
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Rồi! Không Load Được Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadMaCN(TextBox t)
        {
            DataTable dt;
            dt = new DataTable();
            dt = dbChiNhanh.LayBangChiNhanh();
            txtCN.Text = dt.Rows[0][0].ToString();
        }
        void LoadGioiTinh(ComboBox cb)
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.Items.Add("Khác");
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.SelectedIndex = cbGioiTinh.Items.Count - 1;
        }
        void LoadQuyen(ComboBox cb)
        {
            cbQuyen.Items.Clear();
            cbQuyen.Items.Add("QL");
            cbQuyen.Items.Add("NV");
            cbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuyen.SelectedIndex = cbQuyen.Items.Count - 2;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.cbGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtDiaChi.ResetText();
            this.txtEmail.ResetText();
            this.txtMK.ResetText();
            this.cbQuyen.ResetText();
            //
            this.txtMaNV.Enabled = true;
            this.txtTenNV.Enabled = true;
            this.cbGioiTinh.Enabled = true;
            this.txtSDT.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtMK.Enabled = true;
            this.cbQuyen.Enabled = true;
            //
            this.txtTimNV.Enabled = false;
            this.btnTim.Enabled = false;
            this.txtTimNV.ResetText();
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
            LoadMaCN(txtCN);
            LoadQuyen(cbQuyen);
            LoadGioiTinh(cbGioiTinh);
            //
            this.txtMaNV.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            them = false;
            //
            this.txtMaNV.Enabled = false;
            this.txtTenNV.Enabled = true;
            this.cbGioiTinh.Enabled = true;
            this.txtSDT.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtMK.Enabled = true;
            this.cbQuyen.Enabled = true;
            //
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            //
            this.txtTimNV.Enabled = false;
            this.btnTim.Enabled = false;
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            //
            LoadMaCN(txtCN);
            LoadQuyen(cbQuyen);
            LoadGioiTinh(cbGioiTinh);
            //
            this.txtMaNV.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbNhanVien.XoaNV(this.txtMaNV.Text) == true)
                    {
                        checkBoxNam.Checked = false;
                        checkBoxNu.Checked = false;
                        checkBoxKhac.Checked = false;
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
                    checkBoxNam.Checked = false;
                    checkBoxNu.Checked = false;
                    checkBoxKhac.Checked = false;
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
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            checkBoxKhac.Checked = false;
            if (them == true)
            {
                if (dbNhanVien.KiemTraMaNV(txtMaNV.Text) == 0)
                {
                    if (dbNhanVien.ThemNV(this.txtMaNV.Text, this.txtTenNV.Text, this.cbGioiTinh.Text, this.txtSDT.Text,this.txtDiaChi.Text, this.txtEmail.Text, this.txtMK.Text, this.cbQuyen.Text,this.txtCN.Text) == true)
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
                    MessageBox.Show("Trùng Mã Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbNhanVien.CapNhatNV(this.txtMaNV.Text, this.txtTenNV.Text, this.cbGioiTinh.Text, this.txtSDT.Text, this.txtDiaChi.Text, this.txtEmail.Text, this.txtMK.Text, this.cbQuyen.Text, this.txtCN.Text) == true)
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
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            checkBoxKhac.Checked = false;
            LoadData();
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            checkBoxNam.Checked = false;
            checkBoxNu.Checked = false;
            checkBoxKhac.Checked = false;
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

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DvgNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dvgNV.CurrentCell.RowIndex;
            txtMaNV.Text = dvgNV.Rows[r].Cells[0].Value.ToString();
            txtTenNV.Text = dvgNV.Rows[r].Cells[1].Value.ToString();
            cbGioiTinh.Text = dvgNV.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dvgNV.Rows[r].Cells[3].Value.ToString();
            txtDiaChi.Text = dvgNV.Rows[r].Cells[4].Value.ToString();
            txtEmail.Text = dvgNV.Rows[r].Cells[5].Value.ToString();
            txtMK.Text = dvgNV.Rows[r].Cells[6].Value.ToString();
            cbQuyen.Text = dvgNV.Rows[r].Cells[7].Value.ToString();
            txtCN.Text = dvgNV.Rows[r].Cells[8].Value.ToString();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            checkBoxKhac.Enabled = false;
            checkBoxNam.Enabled = false;
            checkBoxNu.Enabled = false;
            btnThem.Enabled = false;
            DataTable dtTim;
            dtTim = dbNhanVien.TimNV(txtTimNV.Text);
            dvgNV.DataSource = dtTim;
        }
        void LoadKhiCheck()
        {
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTim.Enabled = false;
            txtTimNV.Enabled = false;
        }
        private void CheckBoxNam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNam.Checked == true)
            {
                checkBoxNu.Checked = false;
                checkBoxKhac.Checked = false;
                dtgioitinh = dbNhanVien.LayNVtheoGT("Nam");
                dvgNV.DataSource = dtgioitinh;
                LoadKhiCheck();
            }
            else
            {
                LoadData();
            }
        }

        private void CheckBoxNu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNu.Checked == true)
            {
                checkBoxNam.Checked = false;
                checkBoxKhac.Checked = false;
                dtgioitinh = dbNhanVien.LayNVtheoGT("Nữ");
                dvgNV.DataSource = dtgioitinh;
                LoadKhiCheck();
            }
            else
            {
                LoadData();
            }
        }

        private void CheckBoxKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKhac.Checked == true)
            {
                checkBoxNu.Checked = false;
                checkBoxNam.Checked = false;
                dtgioitinh = dbNhanVien.LayNVtheoGT("Khác");
                dvgNV.DataSource = dtgioitinh;
                LoadKhiCheck();
            }
            else
            {
                LoadData();
            }
        }
    }
}

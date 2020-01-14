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
    public partial class frmPhieuXuatHang : Form
    {
        BLKhachHang dbKhachHang;
        BLNhanVien dbNhanVien;
        BLPhieuXuat dbPhieuXuat;
        BLHangHoa dbHangHoa;
        bool them;
        DataTable dtXuat = null;
        public frmPhieuXuatHang()
        {
            InitializeComponent();
            dbHangHoa = new BLHangHoa(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbKhachHang = new BLKhachHang(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbPhieuXuat = new BLPhieuXuat(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
        }
        void LoadData()
        {
            try
            {
                DvgPhieuXH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DvgPhieuXH.Enabled = true;
                //
                dtXuat = new DataTable();
                dtXuat.Clear();
                //
                dtXuat = dbPhieuXuat.LayBangPhieuXuat();
                DvgPhieuXH.DataSource = dtXuat;
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
                this.txtGia.Enabled = false;
                this.txtMaPX.Enabled = false;
                this.txtSoLuong.Enabled = false;
                this.cbMaKH.Enabled = false;
                this.cbMaHH.Enabled = false;
                this.cbMaNV.Enabled = false;
                this.cbXuLy.Enabled = false;
                this.rtxtGhiChu.Enabled = false;
                this.txtNgayXuat.Enabled = false;
                //
                cbNgay.Enabled = true;
                btnThongke.Enabled = true;
                LoadNgay(cbNgay);
                //
                DvgPhieuXH_CellClick(null, null);
                this.txtMaPX.Focus();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Rồi! Không Load Được Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadMaKH(ComboBox cb)
        {
            cbMaKH.DataSource = dbKhachHang.LayBangKhachHang();
            cbMaKH.ValueMember = "MaKH";
            cbMaKH.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadMaNV(ComboBox cb)
        {
            cbMaNV.DataSource = dbNhanVien.LayBangNhanVien();
            cbMaNV.ValueMember = "MaNV";
            cbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadMaHH(ComboBox cb)
        {
            cbMaHH.DataSource = dbHangHoa.LayMaHHSLTKkhac0();
            cbMaHH.ValueMember = "MaHH";
            cbMaHH.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadXuLy(ComboBox cb)
        {
            cbXuLy.Items.Clear();
            cbXuLy.Items.Add("Đã Giao");
            cbXuLy.Items.Add("Chưa Giao");
            cbXuLy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbXuLy.SelectedIndex = cbXuLy.Items.Count - 2;
        }
        void LoadNgay(ComboBox cb)
        {
            cbNgay.DataSource = dbPhieuXuat.LayNgayXuat();
            cbNgay.ValueMember = "NgayXuat";
            cbMaHH.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //
            cbNgay.Enabled = false;
            btnThongke.Enabled = false;
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
            this.txtGia.Enabled = false;
            this.txtMaPX.Enabled = true;
            this.txtSoLuong.Enabled = true;
            this.rtxtGhiChu.Enabled = true;
            this.txtNgayXuat.Enabled = true;
            this.cbXuLy.Enabled = true;
            this.cbMaNV.Enabled = true;
            this.cbMaKH.Enabled = true;
            this.cbMaHH.Enabled = true;
            //
            this.txtGia.ResetText();
            this.txtMaPX.ResetText();
            this.txtSoLuong.ResetText();
            this.cbMaKH.ResetText();
            this.cbMaHH.ResetText();
            this.cbMaNV.ResetText();
            this.cbXuLy.ResetText();
            this.rtxtGhiChu.ResetText();
            this.txtNgayXuat.ResetText();
            //
            this.txtMaPX.Focus();
            //
            LoadMaHH(cbMaHH);
            LoadMaKH(cbMaKH);
            LoadMaNV(cbMaNV);
            LoadXuLy(cbXuLy);
            CbMaHH_SelectedIndexChanged(null, null);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            them = false;
            //
            cbNgay.Enabled = false;
            btnThongke.Enabled = false;
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
            this.txtGia.Enabled = false;
            this.txtMaPX.Enabled = false;
            this.txtSoLuong.Enabled = true;
            this.rtxtGhiChu.Enabled = true;
            this.txtNgayXuat.Enabled = true;
            this.cbXuLy.Enabled = true;
            this.cbMaNV.Enabled = true;
            this.cbMaKH.Enabled = true;
            this.cbMaHH.Enabled = true;
            //
            LoadMaHH(cbMaHH);
            LoadMaKH(cbMaKH);
            LoadMaNV(cbMaNV);
            LoadXuLy(cbXuLy);
            CbMaHH_SelectedIndexChanged(null, null);
            ////
            this.txtMaPX.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbPhieuXuat.XoaPX(this.txtMaPX.Text) == true)
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
            int soluong = int.Parse(txtSoLuong.Text);
            int gia = int.Parse(txtGia.Text);
            if (them == true)
            {
                if (dbPhieuXuat.KiemTraMaPX(txtMaPX.Text) == 0)
                {
                    if (dbPhieuXuat.ThemPX(this.txtMaPX.Text, this.cbMaNV.Text, this.cbMaKH.Text,this.cbMaHH.Text, txtNgayXuat.Text, this.rtxtGhiChu.Text, this.cbXuLy.Text, soluong, gia) == true)
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
                    MessageBox.Show("Trùng Mã Phiếu Xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbPhieuXuat.CapNhatPX(this.txtMaPX.Text, this.cbMaNV.Text, this.cbMaKH.Text, this.cbMaHH.Text, txtNgayXuat.Text, this.rtxtGhiChu.Text, this.cbXuLy.Text, soluong, gia) == true)
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

        private void FrmPhieuXuatHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DvgPhieuXH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = DvgPhieuXH.CurrentCell.RowIndex;
            txtMaPX.Text = DvgPhieuXH.Rows[r].Cells[0].Value.ToString();
            cbMaNV.Text = DvgPhieuXH.Rows[r].Cells[1].Value.ToString();
            cbMaKH.Text = DvgPhieuXH.Rows[r].Cells[2].Value.ToString();
            cbMaHH.Text = DvgPhieuXH.Rows[r].Cells[3].Value.ToString();
            txtNgayXuat.Text = DvgPhieuXH.Rows[r].Cells[4].Value.ToString();
            rtxtGhiChu.Text = DvgPhieuXH.Rows[r].Cells[5].Value.ToString();
            cbXuLy.Text = DvgPhieuXH.Rows[r].Cells[6].Value.ToString();
            txtSoLuong.Text = DvgPhieuXH.Rows[r].Cells[7].Value.ToString();
            txtGia.Text = DvgPhieuXH.Rows[r].Cells[8].Value.ToString();
        }

        private void CbMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt =null;
            dt = new DataTable();
            dt.Clear();
            dt = dbHangHoa.LayGiaTheoMaHH(cbMaHH.Text);
            txtGia.Text = dt.Rows[0][0].ToString();
        }

        private void BtnThongke_Click(object sender, EventArgs e)
        {
            DvgPhieuXH.DataSource = dbPhieuXuat.ThongKeDoanhThuTheoNgay(cbNgay.Text);
            DvgPhieuXH.Rows[0].Selected = false;
            //
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            //
            this.btnSua.Enabled = false;
            this.btnTaiLai.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = true;
            this.btnXoa.Enabled = false;
        }
    }
}

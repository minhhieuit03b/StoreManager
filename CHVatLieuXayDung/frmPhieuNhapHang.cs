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
    public partial class frmPhieuNhapHang : Form
    {
        BLNhaCungCap dbNhaCungCap;
        BLNhanVien dbNhanVien;
        BLPhieuNhap dbPhieuNhap;
        BLHangHoa dbHangHoa;
        bool them;
        DataTable dtNhap = null;
        public frmPhieuNhapHang()
        {
            dbHangHoa = new BLHangHoa(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhaCungCap = new BLNhaCungCap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbPhieuNhap = new BLPhieuNhap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                DvgNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DvgNhap.Enabled = true;
                //
                dtNhap = new DataTable();
                dtNhap.Clear();
                //
                dtNhap = dbPhieuNhap.LayBangPhieuNhap();
                DvgNhap.DataSource = dtNhap;
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
                this.txtMaPN.Enabled = false;
                this.txtSoLuong.Enabled = false;
                this.cbMaNCC.Enabled = false;
                this.cbMaHH.Enabled = false;
                this.cbMaNV.Enabled = false;
                this.cbXuLy.Enabled = false;
                this.rtxtGhiChu.Enabled = false;
                this.txtNgayNhap.Enabled = false;
                //
                LoadNgay(cbNgay);
                //
                cbNgay.Enabled = true;
                btnThongke.Enabled = true;
                //
                DvgNhap_CellClick(null, null);
                this.txtMaPN.Focus();
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
        void LoadMaNV(ComboBox cb)
        {
            cbMaNV.DataSource = dbNhanVien.LayBangNhanVien();
            cbMaNV.ValueMember = "MaNV";
            cbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadMaHH(ComboBox cb)
        {
            cbMaHH.DataSource = dbHangHoa.LayBangHangHoa();
            cbMaHH.ValueMember = "MaHH";
            cbMaHH.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void LoadXuLy(ComboBox cb)
        {
            cbXuLy.Items.Add ("Đang Chờ Hàng");
            cbXuLy.Items.Add( "Đã Lấy Hàng");
            cbXuLy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbXuLy.SelectedIndex = cbXuLy.Items.Count - 2;
        }
        void LoadNgay(ComboBox cb)
        {
            cbNgay.DataSource = dbPhieuNhap.LayNgayNhap();
            cbNgay.ValueMember = "NgayNhap";
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
            this.txtMaPN.Enabled = true;
            this.txtSoLuong.Enabled = true;
            this.rtxtGhiChu.Enabled = true;
            this.txtNgayNhap.Enabled = true;
            this.cbXuLy.Enabled = true;
            this.cbMaNV.Enabled = true;
            this.cbMaNCC.Enabled = true;
            this.cbMaHH.Enabled = true;
            //
            this.txtGia.ResetText();
            this.txtMaPN.ResetText();
            this.txtSoLuong.ResetText();
            this.cbMaNCC.ResetText();
            this.cbMaHH.ResetText();
            this.cbMaNV.ResetText();
            this.cbXuLy.ResetText();
            this.rtxtGhiChu.ResetText();
            this.txtNgayNhap.ResetText();
            //
            this.txtMaPN.Focus();
            //
            LoadMaHH(cbMaHH);
            LoadMaNCC(cbMaNCC);
            LoadMaNV(cbMaNV);
            LoadXuLy(cbXuLy);
            CbMaHH_SelectedIndexChanged(null,null);
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
            this.txtMaPN.Enabled = false;
            this.txtSoLuong.Enabled = true;
            this.rtxtGhiChu.Enabled = true;
            this.txtNgayNhap.Enabled = true;
            this.cbXuLy.Enabled = true;
            this.cbMaNV.Enabled = true;
            this.cbMaNCC.Enabled = true;
            this.cbMaHH.Enabled = true;
            //
            LoadMaHH(cbMaHH);
            LoadMaNCC(cbMaNCC);
            LoadMaNV(cbMaNV);
            LoadXuLy(cbXuLy);
            CbMaHH_SelectedIndexChanged(null, null);
            ////
            this.txtMaPN.Focus();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (dbPhieuNhap.XoaPN(this.txtMaPN.Text) == true)
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadData();
                    }
                    else
                    {
                        LoadData();
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
            int soluong = int.Parse(txtSoLuong.Text);
            int gia = int.Parse(txtGia.Text);
            if (them == true)
            {
                if (dbPhieuNhap.KiemTraMaPN(txtMaPN.Text) == 0)
                {
                    if (dbPhieuNhap.ThemPN(this.txtMaPN.Text,this.cbMaNV.Text,this.cbMaHH.Text,this.cbMaNCC.Text,txtNgayNhap.Text,this.rtxtGhiChu.Text,this.cbXuLy.Text,soluong,gia) == true)
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
                    MessageBox.Show("Trùng Mã Phiếu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dbPhieuNhap.CapNhatPN(this.txtMaPN.Text, this.cbMaNV.Text, this.cbMaHH.Text, this.cbMaNCC.Text, this.txtNgayNhap.Text, this.rtxtGhiChu.Text, this.cbXuLy.Text, soluong, gia) == true)
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

        private void FrmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DvgNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = DvgNhap.CurrentCell.RowIndex;
            txtMaPN.Text = DvgNhap.Rows[r].Cells[0].Value.ToString();
            cbMaNV.Text = DvgNhap.Rows[r].Cells[1].Value.ToString();
            cbMaHH.Text = DvgNhap.Rows[r].Cells[2].Value.ToString();
            cbMaNCC.Text = DvgNhap.Rows[r].Cells[3].Value.ToString();
            txtNgayNhap.Text = DvgNhap.Rows[r].Cells[4].Value.ToString();
            rtxtGhiChu.Text = DvgNhap.Rows[r].Cells[5].Value.ToString();
            cbXuLy.Text = DvgNhap.Rows[r].Cells[6].Value.ToString();
            txtSoLuong.Text = DvgNhap.Rows[r].Cells[7].Value.ToString();
            txtGia.Text = DvgNhap.Rows[r].Cells[8].Value.ToString();
        }

        private void CbMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = null;
            dt = new DataTable();
            dt.Clear();
            dt = dbHangHoa.LayGiaTheoMaHH(cbMaHH.Text);
            txtGia.Text = dt.Rows[0][0].ToString();
        }

        private void BtnThongke_Click(object sender, EventArgs e)
        {
            DvgNhap.DataSource = dbPhieuNhap.ThongKeChiPhiMuaTheoNgay(cbNgay.Text);
            DvgNhap.Rows[0].Selected = false;
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

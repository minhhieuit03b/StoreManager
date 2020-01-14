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
    public partial class frmXem : Form
    {
        BLChiNhanh dbChiNhanh;
        BLHangHoa dbHangHoa;
        BLKhachHang dbKhachHang;
        BLKho dbKho;
        BLNhaCungCap dbNhaCungCap;
        BLNhanVien dbNhanVien;
        BLPhieuNhap dbPhieuNhap;
        BLPhieuXuat dbPhieuXuat;
        DataTable dt = null;
        public frmXem()
        {
            InitializeComponent();
            dbChiNhanh = new BLChiNhanh(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbHangHoa = new BLHangHoa(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbKhachHang = new BLKhachHang(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbKho = new BLKho(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhaCungCap = new BLNhaCungCap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbNhanVien = new BLNhanVien(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbPhieuNhap = new BLPhieuNhap(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            dbPhieuXuat = new BLPhieuXuat(DataProvider.dbsource, DataProvider.id, DataProvider.pass);
            LoadData();
            //dvgShowTable.AutoResizeColumns();
            cbTable.DataSource = dbChiNhanh.LayTenTable();
            cbTable.ValueMember = "TenTable";
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TL = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (TL == DialogResult.OK)
            {
                this.Close();
            }
        }
        void LoadData()
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnHT_Click(object sender, EventArgs e)
        {
            //LoadData();
            if (cbTable.SelectedValue.ToString() == "CHINHANH")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dt = dbChiNhanh.LayBangChiNhanh();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "NHANVIEN")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dt = dbNhanVien.LayBangNhanVien();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "PHIEUNHAPHANG")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dt = dbPhieuNhap.LayBangPhieuNhap();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "KHO")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dt = dbKho.LayBangKho();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "HANGHOA")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dt = dbHangHoa.LayBangHangHoa();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "NHACUNGCAP")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dt = dbNhaCungCap.LayBangNhaCungCap();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if (cbTable.SelectedValue.ToString() == "PHIEUXUATHANG")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dt = dbPhieuXuat.LayBangPhieuXuat();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else if(cbTable.SelectedValue.ToString() == "KHACHHANG")
            {
                LoadData();
                dvgShowTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dt = dbKhachHang.LayBangKhachHang();
                dvgShowTable.DataSource = dt;
                dvgShowTable.Rows[0].Selected = false;
            }
            else
            {
                MessageBox.Show("Chưa Chọn bảng ??");
            }
        }

        private void FrmXem_Load(object sender, EventArgs e)
        {

        }
    }
}

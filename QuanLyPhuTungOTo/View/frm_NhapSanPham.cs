using QuanLyPhuTungOTo.Model;
using System;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class frm_NhapSanPham : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public frm_NhapSanPham()
        {
            InitializeComponent();
        }

        private void frm_NhapSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            LoadLoaiSanPhamTonKho();
            LoadLoaiSanPham();
            LoadChiTietPhieuNhap();
            LoadNhanVienPhieuNhap();
            LoadNhaCCPhieuNhap();
            LoadcbbloaiSanPhamLPN();
        }
        public void LoadSanPham()
        {
            string sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=LoaiSanPham.MaLoai";
            dgvsanPhamTonKho.DataSource = lopchung.layDataTable(sql);
        }
        public void LoadLoaiSanPham()
        {
            string sql = " select MaLoai,TenLoai from LoaiSanPham";
            dgvloaiSPTonKho.DataSource = lopchung.layDataTable(sql);
        }

        public void LoadLoaiSanPhamTonKho()
        {
            string sql = "Select * from LoaiSanPham";
            cbbloaiSanPhamTonKho.DataSource = lopchung.layDataTable(sql);
            cbbloaiSanPhamTonKho.DisplayMember = "TenLoai";
            cbbloaiSanPhamTonKho.ValueMember = "MaLoai";
        }

        private void cbbtimTheoSanPhamTonKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 0)
                lbtimSanPham.Text = "Enter the Product Code";
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 1)
                lbtimSanPham.Text = "Enter the Product Name";
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 2)
                lbtimSanPham.Text = "Enter Product Type";
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 3)
                lbtimSanPham.Text = "Enter manufacturer";
        }

        private void btntimSanPham_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 0)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong,HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai= LoaiSanPham.MaLoai and MaSP = N'" + txttimSanPhamTonKho.Text + "'";
            }
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 1)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong,HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai= LoaiSanPham.MaLoai and TenSP like N'%" + txttimSanPhamTonKho.Text + "%'";
            }
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 2)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong,HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai= LoaiSanPham.MaLoai and LoaiSanPham.TenLoai like N'%" + txttimSanPhamTonKho.Text + "%'";
            }
            if (cbbtimTheoSanPhamTonKho.SelectedIndex == 3)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong,HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai= LoaiSanPham.MaLoai and HangSanXuat like N'%" + txttimSanPhamTonKho.Text + "%'";
            }
            dgvsanPhamTonKho.DataSource = lopchung.layDataTable(sql);
            if(dgvsanPhamTonKho.RowCount < 2)
            {
                MessageBox.Show("Product does not exist", "Notification", MessageBoxButtons.OK);
            }
        }

        private void dgvsanPhamTonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaSanphamTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["MaSP"].Value.ToString();
            txttenSanPhamTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["TenSP"].Value.ToString();
            txtgiaTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["GiaSP"].Value.ToString();
            cbbloaiSanPhamTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["TenLoai"].Value.ToString();
            txtdonViTinhTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txthangSanXuatTonKho.Text = dgvsanPhamTonKho.CurrentRow.Cells["HangSanXuat"].Value.ToString();
            txtsoLuongHienCo.Text = dgvsanPhamTonKho.CurrentRow.Cells["SoLuong"].Value.ToString();
        }

        private void btnchinhSua_Click(object sender, EventArgs e)
        {
            string sql = "update SanPham set MaLoai = N'" + cbbloaiSanPhamTonKho.SelectedValue + "'" +
                ",TenSP = N'" + txttenSanPhamTonKho.Text + "',DonViTinh = N'" + txtdonViTinhTonKho.Text + "'," +
                "GiaSP = N'" + txtgiaTonKho.Text + "',SoLuong = N'"+txtsoLuongHienCo.Text + "',HangSanXuat " +
                "= N'" + txthangSanXuatTonKho.Text + "' where MaSP = N'" + txtmaSanphamTonKho.Text + "'";
            int ketqua = lopchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful editing", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else MessageBox.Show("Editing failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSanPham();
        }

        private void btnthemLoaiSanPham_Click(object sender, EventArgs e)
        {
            string sql = "Insert into LoaiSanPham values(N'" + txtmaLoaiTonKho.Text + "',N'" + txttenLoaiSanPhamTonKho.Text + "')";
            int ketqua = lopchung.ExnonQuery(sql);
            if(ketqua >= 1)
            {
                MessageBox.Show("More successg !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Add failure !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadLoaiSanPhamTonKho();
            LoadLoaiSanPham();
        }

        private void btnchinhSuaLoaiSanPham_Click(object sender, EventArgs e)
        {
            string sql = "Update LoaiSanPham set TenLoai = N'" + txttenLoaiSanPhamTonKho.Text + "' where MaLoai = N'" + txtmaLoaiTonKho.Text + "'";
            int ketqua = lopchung.ExnonQuery(sql);
            if(ketqua >= 1)
            {
                MessageBox.Show("Editing is successful !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Editing failed !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadLoaiSanPhamTonKho();
            LoadLoaiSanPham();
        }

        private void btnxoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            string sql = "Delete LoaiSanPham where Maloai = N'" + txtmaLoaiTonKho.Text + "'";
            int ketqua = lopchung.ExnonQuery(sql);
            if(ketqua >= 1)
            {
                MessageBox.Show("Deleted successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Deletion failed !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadLoaiSanPhamTonKho();
            LoadLoaiSanPham();
        }

        private void dgvloaiSPTonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaLoaiTonKho.Text = dgvloaiSPTonKho.CurrentRow.Cells["MaLoai"].Value.ToString();
            txttenLoaiSanPhamTonKho.Text = dgvloaiSPTonKho.CurrentRow.Cells["TenLoai"].Value.ToString();
        }

        public void LoadChiTietPhieuNhap()
        {
            string sql = "Select ID,PhieuNhap.MaPhieuNhap,SanPham.MaSP,SanPham.SoLuong,GiaNhap,"
                +"Tong from ChiTietPN,PhieuNhap,SanPham where ChiTietPN.MaPhieuNhap = PhieuNhap.MaPhieuNhap and ChiTietPN.MaSP = SanPham.MaSP";
            dgvlapPhieuNhap.DataSource = lopchung.layDataTable(sql);
        }
        public void LoadNhanVienPhieuNhap()
        {
            string sql = "Select * from NhanVien";
            cbbnhanVienLap.DataSource = lopchung.layDataTable(sql);
            cbbnhanVienLap.DisplayMember = "TenNV";
            cbbnhanVienLap.ValueMember = "MaNV";
        }

        public void LoadcbbloaiSanPhamLPN()
        {
            string sql = "Select * from LoaiSanPham";
            cbbloaiSanPhamLPN.DataSource = lopchung.layDataTable(sql);
            cbbloaiSanPhamLPN.DisplayMember = "TenLoai";
            cbbloaiSanPhamLPN.ValueMember = "MaLoai";
        }

        public void LoadNhaCCPhieuNhap()
        {
            string sql = "Select * from NhaCungCap";
            cbbtenNCCLPN.DataSource = lopchung.layDataTable(sql);
            cbbtenNCCLPN.DisplayMember = "TenNCC";
            cbbtenNCCLPN.ValueMember = "MaNCC";
        }

        private void btnthemPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmaPhieuNhap.Text) || string.IsNullOrWhiteSpace(cbbnhanVienLap.Text) ||
                string.IsNullOrWhiteSpace(cbbtenNCCLPN.Text) || string.IsNullOrWhiteSpace(datngayLapPhieuNhap.Text) ||
                string.IsNullOrWhiteSpace(txtsoLuongNhapVaoLPN.Text) || string.IsNullOrWhiteSpace(txtgiaLPN.Text) ||
                string.IsNullOrWhiteSpace(txtmaSanPhamLPN.Text) || string.IsNullOrWhiteSpace(txtgiaLPN.Text))
            {
                MessageBox.Show("Please enter your full details !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            decimal soluong = Convert.ToDecimal(txtsoLuongNhapVaoLPN.Text);
            decimal gia = Convert.ToDecimal(txtgiaLPN.Text);
            decimal sum = soluong * gia;

            string sql = "Insert into PhieuNhap values(N'" + txtmaPhieuNhap.Text + "'" +
                ",N'" + cbbnhanVienLap.SelectedValue + "',N'" + cbbtenNCCLPN.SelectedValue + "'" +
                ",N'" + datngayLapPhieuNhap.Text + "'," + sum + ")";

            int ketqua = lopchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successfully added vendor !");
            }
            else
            {
                MessageBox.Show("Add vendor failure !");
            }

            LoadNhaCCPhieuNhap();
        }

        private void btninPhieuNhap_Click(object sender, EventArgs e)
        {
            ExportToCSV excel = new ExportToCSV();
            try
            {
                excel.ToCsV(dgvlapPhieuNhap);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

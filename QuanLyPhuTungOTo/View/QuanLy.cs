using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class frm_QuanLy : Form
    {
        LOPDUNGCHUNG dungchung = new LOPDUNGCHUNG();
        public frm_QuanLy()
        {
            InitializeComponent();
        }

        private void frm_QuanLy_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            LoadNhanVien();
            LoadLoaiChucVu();
            LoadSanPham();
            LoadLoaiSanPham();
            LoadKhachHang();
            LoadNhaCungCap();
            LoadPhieuNhap();
            LoadChiTietPN();
            LoadHoaDon();
            LoadChiTietHD();
            LoadPDH();
            LoadCTPDH();
        }

        #region NhanVien
        public void LoadNhanVien()
        {
            string sql = "select MaNV,TenNV,NgaySinh,GioiTinh,SDTNV,DiaChiNV," +
                "Email,ChucVu.TenCV from NhanVien inner " +
                "join ChucVu on NhanVien.MaCV = ChucVu.MaCV";
            DataTable dt = dungchung.layDataTable(sql);
            dgvnhanVien.DataSource = dt;
        }
        public void LoadLoaiChucVu()
        {
            string sql = "select * from ChucVu";
            DataTable dt = dungchung.layDataTable(sql);
            cbbchucVu.DataSource = dt;
            cbbchucVu.DisplayMember = "TenCV";
            cbbchucVu.ValueMember = "MaCV";
        }
        private void DangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            frm_DangKy dangky = new frm_DangKy();
            dangky.Show();
        }

        private void btnnhapMoiNhanVien_Click(object sender, EventArgs e)
        {
            txtmaNhanVien.Focus();
            txtmaNhanVien.Clear();
            txttenNhanVien.Clear();
            rdbnam.Checked = rdbnu.Checked = false;
            txtsoDienThoai.Clear();
            txtdiaChi.Clear();
            txtemail.Clear();
        }

        private void dgvnhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaNhanVien.Text = dgvnhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txttenNhanVien.Text = dgvnhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            datengaySinh.Text = dgvnhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            if (dgvnhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rdbnam.Checked = true;
                rdbnu.Checked = false;
            }
            else
            {
                rdbnam.Checked = false;
                rdbnu.Checked = true;
            }
            txtsoDienThoai.Text = dgvnhanVien.CurrentRow.Cells["SDTNV"].Value.ToString();
            txtdiaChi.Text = dgvnhanVien.CurrentRow.Cells["DiaChiNV"].Value.ToString();
            txtemail.Text = dgvnhanVien.CurrentRow.Cells["Email"].Value.ToString();
            cbbchucVu.Text = dgvnhanVien.CurrentRow.Cells["TenCV"].Value.ToString();
        }

        private void btnthemNhanVien_Click(object sender, EventArgs e)
        {
            string sql;
            if (rdbnam.Checked == true)
            {
                sql = "insert into NhanVien values (N'" + txtmaNhanVien.Text + "'," +
                   "N'" + txttenNhanVien.Text + "',N'" + datengaySinh.Text + "','Nam'," +
                   "N'" + txtsoDienThoai.Text + "',N'" + txtdiaChi.Text + "'," +
                   "N'" + txtemail.Text + "',N'" + cbbchucVu.SelectedValue + "')";
            }
            else
            {
                sql = "insert into NhanVien values (N'" + txtmaNhanVien.Text + "'," +
                   "N'" + txttenNhanVien.Text + "',N'" + datengaySinh.Text + "',N'Nữ'," +
                   "N'" + txtsoDienThoai.Text + "',N'" + txtdiaChi.Text + "'," +
                   "N'" + txtemail.Text + "',N'" + cbbchucVu.SelectedValue + "')";
            }
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("More success !");
            }
            else MessageBox.Show("More Failure !");
            LoadNhanVien();
        }

        private void btnchinhSuaNhanVien_Click(object sender, EventArgs e)
        {
            string sql;
            if (rdbnam.Checked == true)
            {
                sql = "update NhanVien set TenNV = N'" + txttenNhanVien.Text + "'," +
                    "NgaySinh = N'" + datengaySinh.Text + "',GioiTinh = N'Nam'," +
                    "SDTNV = N'" + txtsoDienThoai.Text + "',DiaChiNV = N'" + txtdiaChi.Text + "'," +
                    "Email = N'" + txtemail.Text + "',MaCV = N'" + cbbchucVu.SelectedValue + "'" +
                    " where MaNV = N'" + txtmaNhanVien.Text + "'";
            }
            else
            {
                sql = "update NhanVien set TenNV = N'" + txttenNhanVien.Text + "'," +
                    "NgaySinh = N'" + datengaySinh.Text + "',GioiTinh = N'Nữ'," +
                    "SDTNV = N'" + txtsoDienThoai.Text + "',DiaChiNV = N'" + txtdiaChi.Text + "'," +
                    "Email = N'" + txtemail.Text + "',MaCV = N'" + cbbchucVu.SelectedValue + "'" +
                    " where MaNV = N'" + txtmaNhanVien.Text + "'";
            }
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful Editing !");
            }
            else MessageBox.Show("Edit failed !");
            LoadNhanVien();
        }

        private void btnxoaNhanVien_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "delete NhanVien where MaNV = N'" + txtmaNhanVien.Text + "'";
                int ketqua = dungchung.ExnonQuery(sql);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadNhanVien();
            }

        }

        private void cbbtimNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtimNhanVien.SelectedIndex == 0)
            {
                label76.Text = "Employee Full Name cannot be left blank !";
            }
            if (cbbtimNhanVien.SelectedIndex == 1)
            {
                label76.Text = "Employee ID cannot be left blank !";
            }
            if (cbbtimNhanVien.SelectedIndex == 2)
            {
                label76.Text = "Employee position cannot be left blank !";
            }
        }

        private void btntraCuuNhanVien_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimNhanVien.SelectedIndex == 0)
            {
                sql = "select MaNV,TenNV,NgaySinh,GioiTinh,SDTNV,DiaChiNV," +
               "Email,ChucVu.TenCV from NhanVien,ChucVu " +
               "where NhanVien.MaCV = ChucVu.MaCV and TenNV like N'%" + txttimNhanVien.Text + "%'";
            }
            else if (cbbtimNhanVien.SelectedIndex == 1)
            {
                sql = "select MaNV,TenNV,NgaySinh,GioiTinh,SDTNV,DiaChiNV," +
                "Email,ChucVu.TenCV from NhanVien,ChucVu " +
                "where NhanVien.MaCV = ChucVu.MaCV and MaNV = N'" + txttimNhanVien.Text + "'";
            }
            else if (cbbtimNhanVien.SelectedIndex == 2)
            {
                sql = "select MaNV,TenNV,NgaySinh,GioiTinh,SDTNV,DiaChiNV," +
                "Email,ChucVu.TenCV from NhanVien,ChucVu " +
                "where NhanVien.MaCV = ChucVu.MaCV and ChucVu.TenCV = N'" + txttimNhanVien.Text + "'";
            }

            dgvnhanVien.DataSource = dungchung.layDataTable(sql);
            if (dgvnhanVien.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region SanPham
        public void LoadSanPham()
        {
            string sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=LoaiSanPham.MaLoai";
            dgvsanPham.DataSource = dungchung.layDataTable(sql);
        }
        public void LoadLoaiSanPham()
        {
            string sql = "select * from LoaiSanPham";
            cbbloaiSanPham.DataSource = dungchung.layDataTable(sql);
            cbbloaiSanPham.DisplayMember = "TenLoai";
            cbbloaiSanPham.ValueMember = "MaLoai";
        }


        private void dgvsanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbbloaiSanPham.Text = dgvsanPham.CurrentRow.Cells["TenLoai"].Value.ToString();
            txttenSanPham.Text = dgvsanPham.CurrentRow.Cells["TenSP"].Value.ToString();
            txtdonViTinh.Text = dgvsanPham.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtgia.Text = dgvsanPham.CurrentRow.Cells["GiaSP"].Value.ToString();
            txtsoLuong.Text = dgvsanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
            txthangSanXuat.Text = dgvsanPham.CurrentRow.Cells["HangSanXuat"].Value.ToString();
            txtmaSanPham.Text = dgvsanPham.CurrentRow.Cells["MaSP"].Value.ToString();
        }

        private void btnnhapMoiSanPham_Click(object sender, EventArgs e)
        {
            txtmaSanPham.Focus();
            txtmaSanPham.Clear();
            txttenSanPham.Clear();
            txtdonViTinh.Clear();
            txtgia.Clear();
            txtsoLuong.Clear();
            txthangSanXuat.Clear();
        }

        private void btnthemSanPham_Click(object sender, EventArgs e)
        {
            string sql = "insert into SanPham values(N'" + txtmaSanPham.Text + "'," +
                "N'" + cbbloaiSanPham.SelectedValue + "',N'" + txttenSanPham.Text + "'," +
                "N'" + txtdonViTinh.Text + "',N'" + txtgia.Text + "',N'" + txtsoLuong.Text + "'," +
                "N'" + txthangSanXuat.Text + "')";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("More success !");
            }
            else MessageBox.Show("Add failure !");
            LoadSanPham();
        }

        private void btnchinhSuaSanPham_Click(object sender, EventArgs e)
        {
            string sql = "update SanPham set MaLoai = N'" + cbbloaiSanPham.SelectedValue + "'" +
                ",TenSP = N'" + txttenSanPham.Text + "',DonViTinh = N'" + txtdonViTinh.Text + "'," +
                "GiaSP = N'" + txtgia.Text + "',SoLuong = N'" + txtsoLuong.Text + "',HangSanXuat " +
                "= N'" + txthangSanXuat.Text + "' where MaSP = N'" + txtmaSanPham.Text + "'";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful editing !");
            }
            else MessageBox.Show("Failed to edit !");
            LoadSanPham();
        }

        private void btnxoaSanPham_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "delete SanPham where MaSP = N'" + txtmaSanPham.Text + "'";
                int ketqua = dungchung.ExnonQuery(sql);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadSanPham();
            }
        }

        private void cbbtimSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtimSanPham.SelectedIndex == 0)
                lbtimSanPham.Text = "Enter the product code !";
            if (cbbtimSanPham.SelectedIndex == 1)
                lbtimSanPham.Text = "Enter product type !";
            if (cbbtimSanPham.SelectedIndex == 2)
                lbtimSanPham.Text = "Enter the product name !";
            if (cbbtimSanPham.SelectedIndex == 3)
                lbtimSanPham.Text = "Enter manufacturer !";
        }

        private void btntimSanPham_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimSanPham.SelectedIndex == 0)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=" +
                "LoaiSanPham.MaLoai and MaSP = '" + txttimSanPham.Text + "'";
            }
            else if (cbbtimSanPham.SelectedIndex == 1)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=" +
                "LoaiSanPham.MaLoai and LoaiSanPham.TenLoai like N'%" + txttimSanPham.Text + "%'";
            }
            else if (cbbtimSanPham.SelectedIndex == 2)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=" +
                "LoaiSanPham.MaLoai and TenSP like N'%" + txttimSanPham.Text + "%'";
            }
            else if (cbbtimSanPham.SelectedIndex == 3)
            {
                sql = "select MaSP,LoaiSanPham.TenLoai,TenSP,DonViTinh,GiaSP,SoLuong," +
                "HangSanXuat from SanPham,LoaiSanPham where SanPham.MaLoai=" +
                "LoaiSanPham.MaLoai and HangSanXuat like N'%" + txttimSanPham.Text + "%'";
            }
            dgvsanPham.DataSource = dungchung.layDataTable(sql);
            if (dgvsanPham.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK);
            }
        }

        private void btnthemLoaiSanPham_Click(object sender, EventArgs e)
        {
            string sql = "insert into LoaiSanPham values(N'" + txtmaLoai.Text + "',N'" + txttenLoaiSanPham.Text + "')";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("More success !");
            }
            else MessageBox.Show("Add failure !");
            LoadLoaiSanPham();
        }


        private void btnchinhSuaLoaiSanPham_Click(object sender, EventArgs e)
        {
            string sql = "update LoaiSanPham set TenLoai = N'" + txttenLoaiSanPham.Text + "' " +
                "where MaLoai = N'" + txtmaLoai.Text + "'";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful editing !");
            }
            else MessageBox.Show("Failed to edit !");
            LoadLoaiSanPham();
        }

        private void btnxoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "delete LoaiSanPham where MaLoai = N'" + txtmaLoai.Text + "'";
                int ketqua = dungchung.ExnonQuery(sql);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadLoaiSanPham();
            }
        }
        #endregion

        #region KhachHang
        public void LoadKhachHang()
        {
            string sql = "select * from KhachHang";
            dgvkhachHang.DataSource = dungchung.layDataTable(sql);
        }


        private void dgvkhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaKhachHang.Text = dgvkhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenKhachHang.Text = dgvkhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiaChiKH.Text = dgvkhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsoDienThoaiKH.Text = dgvkhachHang.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btnthemKH_Click(object sender, EventArgs e)
        {
            string sql = "insert into KhachHang values(N'" + txtmaKhachHang.Text + "'," +
                "N'" + txttenKhachHang.Text + "',N'" + txtdiaChiKH.Text + "',N'" + txtsoDienThoaiKH.Text + "')";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("More success !");
            }
            else MessageBox.Show("Add failure !");
            LoadKhachHang();
        }

        private void btnchinhSuaKhachHang_Click(object sender, EventArgs e)
        {
            string sql = "update KhachHang set TenKH = N'" + txttenKhachHang.Text + "'," +
                "DiaChi = N'" + txtdiaChiKH.Text + "',SDT = N'" + txtsoDienThoaiKH.Text + "' " +
                "where MaKH = N'" + txtmaKhachHang.Text + "'";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful Editing !");
            }
            else MessageBox.Show("Edit failed !");
            LoadKhachHang();
        }

        private void btnxoaKH_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "delete KhachHang where MaKH = N'" + txtmaKhachHang.Text + "'";
                int ketqua = dungchung.ExnonQuery(sql);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadKhachHang();
            }
        }

        private void btnnhapMoiKH_Click(object sender, EventArgs e)
        {
            txtmaKhachHang.Focus();
            txtmaKhachHang.Clear();
            txttenKhachHang.Clear();
            txtdiaChiKH.Clear();
            txtsoDienThoaiKH.Clear();
        }

        private void cbbtimKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtimKH.SelectedIndex == 0)
                lbtimKH.Text = "Customer code cannot be left blank";
            if (cbbtimKH.SelectedIndex == 1)
                lbtimKH.Text = "Customer name cannot be left blank";
        }

        private void btntimKH_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimKH.SelectedIndex == 0)
            {
                sql = "select * from KhachHang where MaKH = N'" + txttimKH.Text + "'";
            }
            else if (cbbtimKH.SelectedIndex == 1)
            {
                sql = "select * from KhachHang where TenKH like N'%" + txttimKH.Text + "%'";
            }
            dgvkhachHang.DataSource = dungchung.layDataTable(sql);
            if (dgvkhachHang.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region NhaCungCap
        public void LoadNhaCungCap()
        {
            string sql = "select * from NhaCungCap";
            dgvNCC.DataSource = dungchung.layDataTable(sql);

        }


        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaNCC.Text = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
            txttenNCC.Text = dgvNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtsDTNCC.Text = dgvNCC.CurrentRow.Cells["SDTNCC"].Value.ToString();
            txtemailNCC.Text = dgvNCC.CurrentRow.Cells["EmailNCC"].Value.ToString();
        }

        private void cbbtimNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtimNCC.SelectedIndex == 0)
            {
                lbtimNCC.Text = "Supplier code cannot be left blank";
            }
            if (cbbtimNCC.SelectedIndex == 1)
            {
                lbtimNCC.Text = "Provider name cannot be left blank";
            }
        }

        private void btnnhapMoiNCC_Click(object sender, EventArgs e)
        {
            txtmaNCC.Clear();
            txttenNCC.Clear();
            txtsDTNCC.Clear();
            txtemailNCC.Clear();
            txtmaNCC.Focus();
        }

        private void btnchinhSuaNCC_Click(object sender, EventArgs e)
        {
            string sql = "update NhaCungCap set TenNCC = N'" + txttenNCC.Text + "'," +
                "SDT = N'" + txtsDTNCC.Text + "',Email = N'" + txtemailNCC.Text + "' " +
                "where MaNCC = N'" + txtmaNCC.Text + "'";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Successful Editing !");
            }
            else MessageBox.Show("Edit failed !");
            LoadNhaCungCap();
        }

        private void btnthemNCC_Click(object sender, EventArgs e)
        {
            string sql = "insert into NhaCungCap values(N'" + txtmaNCC.Text + "'," +
                "N'" + txttenNCC.Text + "',N'" + txtsDTNCC.Text + "',N'" + txtemailNCC.Text + "')";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("More success !");
            }
            else MessageBox.Show("Add failure !");
            LoadNhaCungCap();
        }

        private void btnxoaNCC_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "delete NhaCungCap where MaNCC = N'" + txtmaNCC.Text + "'";
                int ketqua = dungchung.ExnonQuery(sql);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadNhaCungCap();
            }
        }

        private void btntimNCC_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimNCC.SelectedIndex == 0)
            {
                sql = "select * from NhaCungCap where MaNCC = N'" + txttimNCC.Text + "'";
            }
            else if (cbbtimNCC.SelectedIndex == 1)
            {
                sql = "select * from NhaCungCap where TenNCC like N'%" + txttimNCC.Text + "%'";
            }
            dgvNCC.DataSource = dungchung.layDataTable(sql);
            if (dgvNCC.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region PhieuNhap
        public void LoadPhieuNhap()
        {
            string sql = "select MaPhieuNhap,NV.TenNV,NCC.TenNCC,NgayLapPN,TongTien from PhieuNhap as PN, NhanVien as NV, NhaCungCap as NCC where PN.MaNV=NV.MaNV and PN.MaNCC=NCC.MaNCC";
            dgvPhieuNhap.DataSource = dungchung.layDataTable(sql);
        }
        public void LoadChiTietPN()
        {
            string sql = "select ID,CTPN.MaPhieuNhap,SP.MaSP,SP.TenSP,CTPN.SoLuong,GiaNhap,Tong from ChiTietPN as CTPN,PhieuNhap as PN, SanPham as SP where CTPN.MaPhieuNhap = PN.MaPhieuNhap and CTPN.MaSP = SP.MaSP";
            dgvChitietPN.DataSource = dungchung.layDataTable(sql);
        }


        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaPhieuNhap = txtmaPhieuNhap.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            txtnVLapPhieuNhap.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            txtnhaCungCap.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            datengayLapPhieuNhap.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            string sql = "select ID,CTPN.MaPhieuNhap,SP.MaSP,SP.TenSP,CTPN.SoLuong,GiaNhap,Tong from ChiTietPN as CTPN,PhieuNhap as PN, SanPham as SP where CTPN.MaPhieuNhap = PN.MaPhieuNhap and CTPN.MaSP = SP.MaSP and CTPN.MaPhieuNhap  = N'" + MaPhieuNhap + "'";
            dgvChitietPN.DataSource = dungchung.layDataTable(sql);
        }

        private void btnluuPhieuNhap_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvChitietPN.CurrentRow.Cells[0].Value.ToString());
            string maPhieuNhap = dgvChitietPN.CurrentRow.Cells[1].Value.ToString();
            string maSP = dgvChitietPN.CurrentRow.Cells[2].Value.ToString();
            long giaNhap = long.Parse(dgvChitietPN.CurrentRow.Cells[5].Value.ToString());
            int soLuong = int.Parse(dgvChitietPN.CurrentRow.Cells[4].Value.ToString());
            double tong = giaNhap * soLuong;
            string sumCTPN = string.Format("Select SUM(Tong) from ChiTietPN where MaPhieuNhap = N'" + maPhieuNhap + "'");
            double tongTien = dungchung.Sum(sumCTPN);
            string suaCTPN = "update ChiTietPN set MaSP = N'" + maSP + "',SoLuong = N'" + soLuong + "',GiaNhap = '" + giaNhap + "',Tong = '" + tong + "' where ID = N'" + id + "'";
            dungchung.ExnonQuery(suaCTPN);
            LoadChiTietPN();
            string suaPN = "update PhieuNhap set TongTien = '" + tongTien + "' where MaPhieuNhap = N'" + maPhieuNhap + "'";
            dungchung.ExnonQuery(suaPN);
            LoadPhieuNhap();
        }

        private void txtxoaPhieuNhap_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string maPhieuNhap = dgvChitietPN.CurrentRow.Cells[1].Value.ToString();
                string xoaMaPhieuNhap = "delete from ChiTietPN where MaPhieuNhap = N'" + maPhieuNhap + "';delete PhieuNhap where MaPhieuNhap = N'" + maPhieuNhap + "'";
                int ketqua = dungchung.ExnonQuery(xoaMaPhieuNhap);
                if (ketqua >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadData();
            }
        }

        private void cbbtimPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            datetimPhieuNhap.Visible = false;
            txttimPN.Visible = true;
            if (cbbtimPhieuNhap.SelectedIndex == 0)
            {
                lbtimPN.Text = "The entry ticket code cannot be left blank";
            }
            if (cbbtimPhieuNhap.SelectedIndex == 1)
            {
                lbtimPN.Text = "Employee's name cannot be left blank";
            }
            if (cbbtimPhieuNhap.SelectedIndex == 2)
            {
                lbtimPN.Text = "The entry form cannot be left blank";
                datetimPhieuNhap.Visible = true;
                txttimPN.Visible = false;
            }
            if (cbbtimPhieuNhap.SelectedIndex == 3)
            {
                lbtimPN.Text = "Supplier cannot be left blank";
            }
        }

        private void btntimPhieuNhap_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimPhieuNhap.SelectedIndex == 0)
            {
                sql = "select MaPhieuNhap,NV.TenNV,NCC.TenNCC,NgayLapPN,TongTien from PhieuNhap as PN, NhanVien as NV, NhaCungCap as NCC where PN.MaNV=NV.MaNV and PN.MaNCC=NCC.MaNCC and PN.MaPhieuNhap = N'" + txttimPN.Text + "'";
            }
            else if (cbbtimPhieuNhap.SelectedIndex == 1)
            {
                sql = "select MaPhieuNhap,NV.TenNV,NCC.TenNCC,NgayLapPN,TongTien from PhieuNhap as PN, NhanVien as NV, NhaCungCap as NCC where PN.MaNV=NV.MaNV and PN.MaNCC=NCC.MaNCC and NV.TenNV like N'%" + txttimPN.Text + "%'";
            }
            else if (cbbtimPhieuNhap.SelectedIndex == 2)
            {
                sql = "select MaPhieuNhap,NV.TenNV,NCC.TenNCC,NgayLapPN,TongTien from PhieuNhap as PN, NhanVien as NV, NhaCungCap as NCC where PN.MaNV=NV.MaNV and PN.MaNCC=NCC.MaNCC and NgayLap = N'" + datetimPhieuNhap.Text + "'";
            }
            else if (cbbtimPhieuNhap.SelectedIndex == 3)
            {
                sql = "select MaPhieuNhap,NV.TenNV,NCC.TenNCC,NgayLapPN,TongTien from PhieuNhap as PN, NhanVien as NV, NhaCungCap as NCC where PN.MaNV=NV.MaNV and PN.MaNCC=NCC.MaNCC and NCC.TenNCC like N'%" + txttimPN.Text + "%'";
            }
            dgvPhieuNhap.DataSource = dungchung.layDataTable(sql);
            if (dgvPhieuNhap.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region HoaDon
        public void LoadHoaDon()
        {
            string sql = "select MaHD,NV.TenNV,KH.TenKH,NgayLap,DaThanhToan,ConLai,TongGiaTri,ThanhToan from HoaDon as HD, NhanVien as NV, KhachHang as KH where HD.MaNV = NV.MaNV and HD.MaKH = KH.MaKH";
            dgvDSHD.DataSource = dungchung.layDataTable(sql);
        }
        public void LoadChiTietHD()
        {
            string sql = "select ID,MaHD,SP.MaSP,SP.TenSP,CTHD.SoLuong,SP.GiaSP,ThanhTien from ChiTietHD as CTHD, SanPham as SP where CTHD.MaSP = SP.MaSP";
            dgvCTHD.DataSource = dungchung.layDataTable(sql);
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maHD = txtmaHoaDon.Text = dgvDSHD.CurrentRow.Cells[0].Value.ToString();
            txtkHHoaDon.Text = dgvDSHD.CurrentRow.Cells[1].Value.ToString();
            txtnVLapHoaDon.Text = dgvDSHD.CurrentRow.Cells[2].Value.ToString();
            datengayLapHoaDon.Text = dgvDSHD.CurrentRow.Cells[3].Value.ToString();
            txtdaThanhToan.Text = dgvDSHD.CurrentRow.Cells[4].Value.ToString();
            txtconLai.Text = dgvDSHD.CurrentRow.Cells[5].Value.ToString();
            txttongTienHoaDon.Text = dgvDSHD.CurrentRow.Cells[6].Value.ToString();

            if (dgvDSHD.CurrentRow.Cells[7].Value.ToString() == "1")
            {
                rdbdaThanhToan.Checked = true;
                rdbchuaThanhToan.Checked = false;
            }
            else
            {
                rdbdaThanhToan.Checked = false;
                rdbchuaThanhToan.Checked = true;
            }
            string sql = "select ID,MaHD,SP.MaSP,SP.TenSP,CTHD.SoLuong,SP.GiaSP,ThanhTien from ChiTietHD as CTHD, SanPham as SP where CTHD.MaSP = SP.MaSP and CTHD.MaHD = N'" + maHD + "'";
            dgvCTHD.DataSource = dungchung.layDataTable(sql);
        }

        private void cbbtimHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            datetimHoaDon.Visible = false;
            txttimHD.Visible = true;
            if (cbbtimHoaDon.SelectedIndex == 0)
            {
                lbtimHD.Text = "Invoice codes cannot be left blank";
            }
            if (cbbtimHoaDon.SelectedIndex == 1)
            {
                lbtimHD.Text = "Employee's name cannot be left blank";
            }
            if (cbbtimHoaDon.SelectedIndex == 2)
            {
                lbtimHD.Text = "An invoice date cannot be left blank";
                datetimHoaDon.Visible = true;
                txttimHD.Visible = false;
            }
            if (cbbtimHoaDon.SelectedIndex == 3)
            {
                lbtimHD.Text = "Customers cannot leave it blank";
            }
        }

        private void btnluuHoaDon_Click(object sender, EventArgs e)
        {
            int iD = int.Parse(dgvCTHD.CurrentRow.Cells[0].Value.ToString());
            string maHD = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
            string maSP = dgvCTHD.CurrentRow.Cells[2].Value.ToString();
            double daThanhToan = double.Parse(dgvDSHD.CurrentRow.Cells[4].Value.ToString());
            int soLuong = int.Parse(dgvCTHD.CurrentRow.Cells[4].Value.ToString());
            double thanhTien = soLuong * double.Parse(dgvCTHD.CurrentRow.Cells[5].Value.ToString());
            string suaCTHD = "update ChiTietHD set MaSP = N'" + maSP + "',SoLuong = N'" + soLuong + "' where MaHD = N'" + maHD + "' and ID = N'" + iD + "';" +
                "update ChiTietHD set ThanhTien = N'" + thanhTien + "' where ID = N'" + iD + "'";
            dungchung.ExnonQuery(suaCTHD);
            string sumHD = string.Format("select SUM(ThanhTien) from ChiTietHD where MaHD = N'" + maHD + "'");
            double tongGiaTri = dungchung.Sum(sumHD);
            double conLai = tongGiaTri - daThanhToan;
            string suaGia = "update HoaDon set TongGiaTri = N'" + tongGiaTri + "', ConLai = N'" + conLai + "' where MaHD = N'" + maHD + "'";
            dungchung.ExnonQuery(suaGia);
            LoadData();
        }

        private void btnxoaHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure you want to delete ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string maHD = dgvDSHD.CurrentRow.Cells[0].Value.ToString();
                string xoaMaHD = "delete ChiTietHD where MaHD = N'" + maHD + "';delete HoaDon where MaHD = '" + maHD + "'";
                int kq = dungchung.ExnonQuery(xoaMaHD);
                if (kq >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadData();
            }
        }

        private void btntimHoaDon_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimHoaDon.SelectedIndex == 0)
            {
                sql = "select MaHD,NV.TenNV,KH.TenKH,NgayLap,DaThanhToan,ConLai,TongGiaTri,ThanhToan from HoaDon as HD, NhanVien as NV, KhachHang as KH where HD.MaNV = NV.MaNV and HD.MaKH = KH.MaKH and MaHD = N'" + txttimHD.Text + "'";
            }
            else if (cbbtimHoaDon.SelectedIndex == 1)
            {
                sql = "select MaHD,NV.TenNV,KH.TenKH,NgayLap,DaThanhToan,ConLai,TongGiaTri,ThanhToan from HoaDon as HD, NhanVien as NV, KhachHang as KH where HD.MaNV = NV.MaNV and HD.MaKH = KH.MaKH and NV.TenNV like N'%" + txttimHD.Text + "%'";
            }
            else if (cbbtimHoaDon.SelectedIndex == 2)
            {
                sql = "select MaHD,NV.TenNV,KH.TenKH,NgayLap,DaThanhToan,ConLai,TongGiaTri,ThanhToan from HoaDon as HD, NhanVien as NV, KhachHang as KH where HD.MaNV = NV.MaNV and HD.MaKH = KH.MaKH and NgayLap = N'" + datetimHoaDon.Text + "'";
            }
            else if (cbbtimHoaDon.SelectedIndex == 3)
            {
                sql = "select MaHD,NV.TenNV,KH.TenKH,NgayLap,DaThanhToan,ConLai,TongGiaTri,ThanhToan from HoaDon as HD, NhanVien as NV, KhachHang as KH where HD.MaNV = NV.MaNV and HD.MaKH = KH.MaKH and KH.TenKH like N'%" + txttimHD.Text + "%'";
            }
            dgvDSHD.DataSource = dungchung.layDataTable(sql);
            if (dgvDSHD.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region PhieuDatHang
        public void LoadPDH()
        {
            string sql = "select MaPDH,NV.TenNV,KH.TenKH,NgayLap,TongGiaTri from PhieuDatHang as PDH, NhanVien as NV, KhachHang as KH where PDH.MaNV = NV.MaNV and PDH.MaKH = KH.MaKH";
            dgvDSPDH.DataSource = dungchung.layDataTable(sql);
        }
        public void LoadCTPDH()
        {
            string sql = "select ID,MaPDH,CTPDH.MaSP,SP.TenSP,CTPDH.SoLuong,SP.GiaSP,ThanhTien from ChiTietPDH as CTPDH, SanPham as SP where CTPDH.MaSP = SP.MaSP";
            dgvCTPDH.DataSource = dungchung.layDataTable(sql);
        }

        private void cbbtimPDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            datetimPDH.Visible = false;
            txttimPDH.Visible = true;
            if (cbbtimPDH.SelectedIndex == 0)
            {
                lbtimPDH.Text = "Order number cannot be left blank";
            }
            if (cbbtimPDH.SelectedIndex == 1)
            {
                lbtimPDH.Text = "Employee names cannot be left blank";
            }
            if (cbbtimPDH.SelectedIndex == 2)
            {
                lbtimPDH.Text = "The date cannot be left blank";
                datetimPDH.Visible = true;
                txttimPDH.Visible = false;
            }
            if (cbbtimPDH.SelectedIndex == 3)
            {
                lbtimPDH.Text = "Customers cannot leave it blank";
            }
        }

        private void dgvDSPDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaPhieuDatHang.Text = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
            txtnVLapPDH.Text = dgvDSPDH.CurrentRow.Cells[1].Value.ToString();
            txtkHPDH.Text = dgvDSPDH.CurrentRow.Cells[2].Value.ToString();
            datengayLapPDH.Text = dgvDSPDH.CurrentRow.Cells[3].Value.ToString();
            txttongTienPDH.Text = dgvDSPDH.CurrentRow.Cells[4].Value.ToString();
            string maPDH = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
            string sql = "select ID,MaPDH,CTPDH.MaSP,SP.TenSP,CTPDH.SoLuong,SP.GiaSP,ThanhTien from ChiTietPDH as CTPDH, SanPham as SP where CTPDH.MaSP = SP.MaSP and CTPDH.MaPDH = N'" + maPDH + "'";
            dgvCTPDH.DataSource = dungchung.layDataTable(sql);
        }

        private void btnluuPDH_Click(object sender, EventArgs e)
        {
            int iD = int.Parse(dgvCTPDH.CurrentRow.Cells[0].Value.ToString());
            string maPDH = dgvCTPDH.CurrentRow.Cells[1].Value.ToString();
            string maSP = dgvCTPDH.CurrentRow.Cells[2].Value.ToString();
            int soLuong = int.Parse(dgvCTPDH.CurrentRow.Cells[4].Value.ToString());
            double thanhTien = soLuong * double.Parse(dgvCTPDH.CurrentRow.Cells[5].Value.ToString());
            string suaCTPDH = "update ChiTietPDH set MaSP = N'" + maSP + "',SoLuong = N'" + soLuong + "' where MaPDH = N'" + maPDH + "' and ID = N'" + iD + "';" +
                "update ChiTietPDH set ThanhTien = N'" + thanhTien + "' where ID = N'" + iD + "'";
            dungchung.ExnonQuery(suaCTPDH);
            string sumPDH = string.Format("select SUM(ThanhTien) from ChiTietPDH where MaPDH = N'" + maPDH + "'");
            double tongGiaTri = dungchung.Sum(sumPDH);
            string suaGia = "update PhieuDatHang set TongGiaTri = N'" + tongGiaTri + "' where MaPDH = N'" + maPDH + "'";
            dungchung.ExnonQuery(suaGia);
            LoadData();
        }

        private void btnxoaPDH_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string maPDH = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
                string xoaMaPDH = "delete ChiTietPDH where MaPDH = N'" + maPDH + "';delete PhieuDatHang where MaPDH = '" + maPDH + "'";
                int kq = dungchung.ExnonQuery(xoaMaPDH);
                if (kq >= 1)
                {
                    MessageBox.Show("Deleted successfully !");
                }
                else MessageBox.Show("Deletion failed !");
                LoadData();
            }
        }

        private void btntimPDH_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbbtimPDH.SelectedIndex == 0)
            {
                sql = "select MaPDH,NV.TenNV,KH.TenKH,NgayLap,TongGiaTri from PhieuDatHang as PDH, NhanVien as NV, KhachHang as KH where PDH.MaNV = NV.MaNV and PDH.MaKH = KH.MaKH and MaPDH = N'" + txttimPDH.Text + "'";
            }
            else if (cbbtimPDH.SelectedIndex == 1)
            {
                sql = "select MaPDH,NV.TenNV,KH.TenKH,NgayLap,TongGiaTri from PhieuDatHang as PDH, NhanVien as NV, KhachHang as KH where PDH.MaNV = NV.MaNV and PDH.MaKH = KH.MaKH and NV.TenNV like N'%" + txttimPDH.Text + "%'";
            }
            else if (cbbtimPDH.SelectedIndex == 2)
            {
                sql = "select MaPDH,NV.TenNV,KH.TenKH,NgayLap,TongGiaTri from PhieuDatHang as PDH, NhanVien as NV, KhachHang as KH where PDH.MaNV = NV.MaNV and PDH.MaKH = KH.MaKH and NgayLap = N'" + datengayLapPDH.Text + "'";
            }
            else if (cbbtimPDH.SelectedIndex == 3)
            {
                sql = "select MaPDH,NV.TenNV,KH.TenKH,NgayLap,TongGiaTri from PhieuDatHang as PDH, NhanVien as NV, KhachHang as KH where PDH.MaNV = NV.MaNV and PDH.MaKH = KH.MaKH and KH.TenKH like N'%" + txttimPDH.Text + "%'";
            }
            dgvDSPDH.DataSource = dungchung.layDataTable(sql);
            if (dgvDSPDH.RowCount < 2)
            {
                MessageBox.Show("There is no data you are looking for", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}

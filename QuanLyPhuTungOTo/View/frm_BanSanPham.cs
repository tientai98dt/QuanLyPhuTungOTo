using QuanLyPhuTungOTo.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class frm_BanSanPham : Form
    {
        LOPDUNGCHUNG dungchung = new LOPDUNGCHUNG();
        frm_BanSanPhamModel frm_BanSanPhamModel = new frm_BanSanPhamModel();

        public frm_BanSanPham()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load All List product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_BanSanPham_Load(object sender, EventArgs e)
        {
            LoadBangSP();
            LoadBangKH();
            LoadBangPDH();
            LoadCTHD();
            LayLoaiSanPham();
        }

        #region Load Data
        public void LoadBangSP()
        {
            DataTable dt = frm_BanSanPhamModel.LoadBangSP();
            dgvDMSanPham_PDH.DataSource = dt;
            dgvDanhMucSP_HD.DataSource = dt;
        }

        public void LoadBangKH()
        {
            DataTable dt = frm_BanSanPhamModel.LoadBangKH();
            DgvKhachHang.DataSource = dt;
        }

        public void LoadBangPDH()
        {
            DataTable dt = frm_BanSanPhamModel.LoadBangPDH();
            dgvCTPDH.DataSource = dt;
        }

        public void LoadCTHD()
        {
            DataTable dt = frm_BanSanPhamModel.LoadCTHD();
            dgvCTHD.DataSource = dt;
        }

        public void LayLoaiSanPham()
        {
            string sql = "Select * from LoaiSanPham";
            DataTable dt = dungchung.layDataTable(sql);
            cbxloaiSanPham.DataSource = dt;
            cbxloaiSanPham.DisplayMember = "TenLoai";
            cbxloaiSanPham.ValueMember = "MaLoai";
        }

        private void DgvDMSanPham_PDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaSanPham.Text = dgvDMSanPham_PDH.CurrentRow.Cells["MaSP"].Value.ToString();
            cbxloaiSanPham.SelectedValue = dgvDMSanPham_PDH.CurrentRow.Cells["MaLoai"].Value.ToString();
            txttenSanPham.Text = dgvDMSanPham_PDH.CurrentRow.Cells["TenSP"].Value.ToString();
            txtdonViTinhPDH.Text = dgvDMSanPham_PDH.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtdonGiaPDH.Text = dgvDMSanPham_PDH.CurrentRow.Cells["GiaSP"].Value.ToString();
            txtsoLuong.Text = dgvDMSanPham_PDH.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtHSXPDH.Text = dgvDMSanPham_PDH.CurrentRow.Cells["HangSanXuat"].Value.ToString();
        }

        private void DgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaKhachHang.Text = DgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenKhachHang.Text = DgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiaChiKH.Text = DgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsoDTKH.Text = DgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void dgvCTPDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaSanPham.Text = dgvCTPDH.CurrentRow.Cells["MaSP"].Value.ToString();
            cbxloaiSanPham.SelectedValue = dgvCTPDH.CurrentRow.Cells["MaLoai"].Value.ToString();
            txttenSanPham.Text = dgvCTPDH.CurrentRow.Cells["TenSP"].Value.ToString();
            txtdonViTinhPDH.Text = dgvCTPDH.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtdonGiaPDH.Text = dgvCTPDH.CurrentRow.Cells["GiaSP"].Value.ToString();
            txtsoLuong.Text = dgvCTPDH.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtHSXPDH.Text = dgvCTPDH.CurrentRow.Cells["HangSanXuat"].Value.ToString();
        }
        #endregion

        #region Use

        /// <summary>
        /// Search for products by product code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTimTheoMaSPPDH_Click(object sender, EventArgs e)
        {
            string sql = null;
            sql = "select * from SanPham where MaSP like '%" + txttimtheomaSPPDH.Text + "%'";
            dgvDMSanPham_PDH.DataSource = dungchung.layDataTable(sql);
            if (dgvDMSanPham_PDH.RowCount < 2)
            {
                MessageBox.Show("Product does not exist", "Notification", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Search for products by product code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtntimtheomaSPHD_Click(object sender, EventArgs e)
        {
            string sql = null;
            sql = "select * from SanPham where MaSP like '%" + txttimtheomaSPHD.Text + "%'";
            dgvDanhMucSP_HD.DataSource = dungchung.layDataTable(sql);
            if (dgvDanhMucSP_HD.RowCount < 2)
            {
                MessageBox.Show("Product does not exist", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnthemKH_Click(object sender, EventArgs e)
        {
            string sql = "Insert into KhachHang values(N'" + txtmaKhachHang.Text + "',N'" + txttenKhachHang.Text + "',N'" + txtdiaChiKH.Text + "',N'" + txtsoDTKH.Text + "')";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Add product successfully");
            }
            else
            {
                MessageBox.Show("Add Product failed");
            }
            LoadBangKH();
        }

        private void BtnsuaKH_Click(object sender, EventArgs e)
        {
            string sql = "Update KhachHang set TenKH=N'" + txttenKhachHang.Text + "',DiaChi=N'" + txtdiaChiKH.Text + "',SDT=N'" + txtsoDTKH.Text + "'where MaKH=N'" + txtmaKhachHang.Text + "'";
            int ketqua = dungchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Update product successfully");
            }
            else
            {
                MessageBox.Show("Update Product failed");
            }
            LoadBangKH();
        }

        /// <summary>
        /// Search for customers by customer code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbbtimKH_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (cbxtimKhachHang.SelectedIndex == 0)
            {
                sql = "select * from SanPham where MaSP like '%" + txttimKhachHang.Text + "%'";
            }
            if (cbxtimKhachHang.SelectedIndex == 1)
            {
                sql = "select * from KhachHang where TenKH like N'%" + txttimKhachHang.Text + "%'";
            }
            DgvKhachHang.DataSource = dungchung.layDataTable(sql);
            if (DgvKhachHang.RowCount < 2)
            {
                MessageBox.Show("Khách hàng không tồn tại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnthemSanPham_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to add this product ?"
                , "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtmaSanPham.Text == "") MessageBox.Show("The Product Code cannot be left blank");
                else
                {
                    int index = frm_BanSanPhamModel.DALThem(txtmaSanPham.Text, txttenSanPham.Text, Convert.ToInt32(txtsoLuong.Text),
                        cbxloaiSanPham.SelectedValue.ToString(), txtdonViTinhPDH.Text, Convert.ToDouble(txtdonGiaPDH.Text), txtHSXPDH.Text);
                    if (index == 1)
                    {
                        MessageBox.Show("You have added the product successfully");
                    }
                    else MessageBox.Show("You have failed to add the product");
                }
            }
        }

        private void btnxoaSPPDH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this product ?"
                , "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int index = frm_BanSanPhamModel.DALXoa(txtmaSanPham.Text);
                if (index == 1)
                {
                    MessageBox.Show("You have successfully deleted the product");
                }
                else MessageBox.Show("You have failed to delete the product");
            }
        }

        private void btninPDH_Click(object sender, EventArgs e)
        {
            ExportToCSV excel = new ExportToCSV();
            try
            {
                excel.ToCsV(dgvCTPDH);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void UpdateSanPham_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you update this product information ?"
                , "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtmaSanPham.Text == "") MessageBox.Show("The Product Code cannot be left blank");
                else
                {
                    int index = frm_BanSanPhamModel.DALThem(txtmaSanPham.Text, txttenSanPham.Text, Convert.ToInt32(txtsoLuong.Text),
                        cbxloaiSanPham.SelectedValue.ToString(), txtdonViTinhPDH.Text, Convert.ToDouble(txtdonGiaPDH.Text), txtHSXPDH.Text);
                    if (index == 1)
                    {
                        MessageBox.Show("You have successfully updated the product");
                    }
                    else MessageBox.Show("You have failed to update the product");
                }
            }
        }

        private void ClearContentKH_Click(object sender, EventArgs e)
        {
            txtmaKhachHang.Text = string.Empty;
            txttenKhachHang.Text = string.Empty;
            txtdiaChiKH.Text = string.Empty;
            txtsoDTKH.Text = string.Empty;
            txtmaKhachHang.Focus();
        }
        #endregion
    }
}

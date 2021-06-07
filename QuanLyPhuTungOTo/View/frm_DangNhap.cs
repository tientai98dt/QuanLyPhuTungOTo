using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class frm_DangNhap : Form
    {
        LOPDUNGCHUNG dungchung = new LOPDUNGCHUNG();

        public KeyEventHandler DefaultButton { get; private set; }

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndangNhap_Click(object sender, EventArgs e)
        {
            string use = txtusername.Text;
            string pass = txtpassword.Text;
            string sql = "";
            if (string.IsNullOrWhiteSpace(use))
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập hoặc mật khẩu", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sql = "select * from TaiKhoan where ID = '" + use + "' and Pass = '" + pass + "'";
                DataTable dt = dungchung.layDataTable(sql);

                // Kiểm tra phân quyền đăng nhập
                if (dt.Rows.Count > 0)
                {
                    LoadJob(use);
                    this.Hide();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Decentralize user rights for Form Main
        /// </summary>
        private void LoadJob(string use)
        {
            FormChinh main = new FormChinh();
            string quyen = "";
            string sql = "Select MaCV from TaiKhoan where ID = '" + use + "'";
            DataTable dt = dungchung.layDataTable(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    quyen = dr["MaCV"].ToString();
                }
            }
            if (quyen == "QL")
            {
                main.Show();
            }
            else if (quyen == "BH")
            {
                main.BanSanPham.Enabled = true;
                main.QuanLy.Enabled = false;
                main.nhapSanPham.Enabled = false;
                main.DangKyTaiKhoan.Enabled = false;
                main.Show();
            }
            else if (quyen == "NH")
            {
                main.BanSanPham.Enabled = false;
                main.QuanLy.Enabled = false;
                main.nhapSanPham.Enabled = true;
                main.DangKyTaiKhoan.Enabled = false;
                main.Show();
            }

            MessageBox.Show("Xin chào "+ txtusername.Text + " đến với hệ thống !", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exit the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnthoatDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs==DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool IsOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "frm_DangKy")
                {
                    IsOpen = true;
                    item.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm_DangKy frm_dangKy = new frm_DangKy();
                frm_dangKy.Show();
            }
        }
    }
}

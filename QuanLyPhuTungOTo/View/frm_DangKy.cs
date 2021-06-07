using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class frm_DangKy : Form
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        Model.DangKyModel dangky = new Model.DangKyModel();
        public frm_DangKy()
        {
            InitializeComponent();
            dangky.LoadLoaiChucVu(cbxcongViec);
        }

        /// <summary>
        /// Exit the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "Message"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// New account registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangky_Click(object sender, EventArgs e)
        {
            // Check Null
            if (string.IsNullOrWhiteSpace(txtuserName.Text) ||
               string.IsNullOrWhiteSpace(txtpassDangKy.Text) ||
               string.IsNullOrWhiteSpace(cbxcongViec.Text) ||
               string.IsNullOrWhiteSpace(txtconfirm.Text))
            {
                MessageBox.Show("Please ! Please Enter Full Information", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtconfirm.Text != txtpassDangKy.Text)
            {
                MessageBox.Show("The password must be the same again", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsUsername(txtuserName.Text) == true && IsPassWork(txtpassDangKy.Text) == true)
            {
                dangky.DangKyTaiKhoan(txtuserName.Text, txtpassDangKy.Text, cbxcongViec.SelectedValue.ToString());
                dangky.ReloadContent(txtuserName, txtpassDangKy, txtconfirm);
            }
        }

        /// <summary>
        /// Check Username Success use Regex
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUsername(string username)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,10}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(username))
            {
                MessageBox.Show("Username should contain At least one lower case letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasUpperChar.IsMatch(username))
            {
                MessageBox.Show("Username should contain At least one upper case letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(username))
            {
                MessageBox.Show("Username should not be less than or greater than 12 characters", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasNumber.IsMatch(username))
            {
                MessageBox.Show("Username should contain At least one numeric value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check PassWord Success use Regex
        /// </summary>
        /// <param name="passWork"></param>
        /// <returns></returns>
        private bool IsPassWork(string passWork)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,10}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(passWork))
            {
                MessageBox.Show("Password should contain At least one lower case letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasUpperChar.IsMatch(passWork))
            {
                MessageBox.Show("Password should contain At least one upper case letter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(passWork))
            {
                MessageBox.Show("Password should not be less than or greater than 12 characters", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!hasNumber.IsMatch(passWork))
            {
                MessageBox.Show("Password should contain At least one numeric value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

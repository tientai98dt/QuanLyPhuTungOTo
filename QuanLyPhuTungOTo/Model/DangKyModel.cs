using System.Data;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo.Model
{
    class DangKyModel
    {
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public void LoadLoaiChucVu(ComboBox cv)
        {
            string sql = "select * from ChucVu";
            DataTable dt = lopchung.layDataTable(sql);
            cv.DataSource = dt;
            cv.DisplayMember = "TenCV";
            cv.ValueMember = "MaCV";
        }
        public void DangKyTaiKhoan(string useName,string pass,string congviec)
        {
            string sql = "Insert into TaiKhoan values(N'" + useName + "',N'" + pass + "',N'" + congviec + "')";
            int ketqua = lopchung.ExnonQuery(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã thêm tài khoản thành công !!!");
            }
            else
            {
                MessageBox.Show("Bạn đã thêm tài khoản thất bại !!!");
            }
        }

        public void ReloadContent(TextBox useName, TextBox pass, TextBox passcf)
        {
            useName.Clear();
            pass.Clear();
            passcf.Clear();
        }
    }
}

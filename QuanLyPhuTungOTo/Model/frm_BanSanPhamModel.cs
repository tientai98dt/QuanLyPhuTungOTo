using System.Data;

namespace QuanLyPhuTungOTo.Model
{
    class frm_BanSanPhamModel
    {
        LOPDUNGCHUNG lopdungchung = new LOPDUNGCHUNG();
        public DataTable LoadBangSP()
        {
            string select = "SELECT MaSP,TenSP,lsp.TenLoai,DonViTinh,GiaSP,SoLuong,HangSanXuat " +
                "FROM SanPham as sp INNER JOIN LoaiSanPham as lsp ON lsp.MaLoai = sp.MaLoai";
            return lopdungchung.layDataTable(select);
        }

        public DataTable LoadBangKH()
        {
            string select = "Select * from KhachHang";
            return lopdungchung.layDataTable(select);
        }

        public DataTable LoadBangPDH()
        {
            string select = "select ct.ID,pdh.MaNV,pdh.NgayLap,pdh.TongGiaTri,ct.MaPDH,sp.MaSP,sp.TenSP,sp.MaLoai,sp.HangSanXuat,ct.SoLuong,sp.GiaSP" +
                ",ct.ThanhTien from ChiTietPDH as ct " +
                "INNER JOIN PhieuDatHang as pdh ON ct.MaPDH = pdh.MaPDH " +
                "INNER JOIN SanPham as sp ON sp.MaSP = ct.MaSP";
            return lopdungchung.layDataTable(select);
        }

        public DataTable LoadCTHD()
        {
            string select = "SELECT ct.MaHD,sp.MaSP,sp.TenSP,ct.SoLuong,sp.GiaSP,ct.ThanhTien " +
                "FROM ChiTietHD as ct INNER JOIN SanPham as sp ON ct.MaSP = sp.MaSP";
            return lopdungchung.layDataTable(select);
        }

        public int DALThem(string maSP, string tenSP, int soLuong,
                    string maLoai, string donViTinh, double giaSP, string hangSanXuat)
        {
            string insert = "INSERT INTO SanPham (MaSP, MaLoai, TenSP, DonViTinh, GiaSP, SoLuong, HangSanXuat)" +
                "VALUES("+ maSP + ", " + maLoai + ", " + tenSP + ", " + donViTinh + ", " + giaSP + ", " + soLuong + ", " + hangSanXuat + ")";
            return lopdungchung.ExnonQuery(insert);
        }
        public int DALXoa(string maSP)
        {
            string Xoa = "delete SanPham where MaSP = '" + maSP + "'";
            return lopdungchung.ExnonQuery(Xoa);
        }
        public int DALSua(string SoCM, string HinhAnh, string MaNV)
        {
            string insert = "update KHACHHANG set HinhAnh = '" + HinhAnh + "', MaNV = '" + MaNV + "' where SoCM = '" + SoCM + "'";
            return lopdungchung.ExnonQuery(insert);
        }
    }
}

using QuanLyPhuTungOTo.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show Form Dang Ky Tai Khoan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DangKyTaiKhoan_Click(object sender, EventArgs e)
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
                frm_dangKy.MdiParent = this;
                frm_dangKy.Show();
            }
        }

        /// <summary>
        /// Show Form Quan Ly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuanLy_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "frm_QuanLy")
                {
                    IsOpen = true;
                    item.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm_QuanLy frm_quanLy = new frm_QuanLy();
                frm_quanLy.MdiParent = this;
                frm_quanLy.Show();
            }
        }

        /// <summary>
        /// Show Form Nhap San Pham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NhapSanPham_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "frm_NhapSanPham")
                {
                    IsOpen = true;
                    item.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm_NhapSanPham frm_nhapSanPham = new frm_NhapSanPham();
                frm_nhapSanPham.MdiParent = this;
                frm_nhapSanPham.Show();
            }
        }

        /// <summary>
        /// LogOut The Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program?", "Message"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Show Form Ban San Pham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BanSanPham_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "frm_BanSanPham")
                {
                    IsOpen = true;
                    item.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm_BanSanPham frm_BanSanPham = new frm_BanSanPham();
                frm_BanSanPham.MdiParent = this;
                frm_BanSanPham.Show();
            }
        }

        private void tinTứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Text == "frm_Tintuc")
                {
                    IsOpen = true;
                    item.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                frm_Tintuc tintuc = new frm_Tintuc();
                tintuc.MdiParent = this;
                tintuc.Show();
            }
        }
    }
}

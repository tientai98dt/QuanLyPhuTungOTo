using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo.View
{
    public partial class frm_Tintuc : Form
    {
        WebBrowser wb = new WebBrowser();

        public frm_Tintuc()
        {
            InitializeComponent();
        }

        public void LoadTinTuc()
        {
            string link = txtlink.Text;
            wb.Navigate(link);
        }
    }
}

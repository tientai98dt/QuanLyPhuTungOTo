using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhuTungOTo
{
    class LOPDUNGCHUNG
    {
        string chuoiketnoi = @"Data Source=DESKTOP-5VB4EH8;Initial Catalog=F:\DOAN_TICH_HOP\DATABASE\QUANLYPHUTUNGOTO.MDF;Integrated Security=True";
        SqlConnection conn;
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection(chuoiketnoi);
        }
        public void Mo()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        public void Dong()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        public DataTable layDataTable(string select)
        {
            SqlDataAdapter da = new SqlDataAdapter(select, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int ExnonQuery(string sql)
        {
            try
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                Mo();
                int i = (int)comm.ExecuteNonQuery();
                Dong();
                return i;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("PRIMARY"))
                {
                    MessageBox.Show("This Code Exist Please Enter Again !");

                }
                else
                {
                    if (ex.Message.Contains("binary"))
                    {
                        MessageBox.Show("You Have Entered Over The Required Number of Characters !");

                    }
                    else
                    {
                        if (ex.Message.Contains("REFERENCE"))
                        {
                            MessageBox.Show("Contains Links, Cannot delete !");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }

                return -1;
            }

        }
        public double Sum(string str)
        {

            SqlCommand cmd = new SqlCommand(str, conn);
            Mo();
            if (cmd.ExecuteScalar().ToString() == "")
            {

                return 0;
            }

            return double.Parse(cmd.ExecuteScalar().ToString());

        }
    }
}

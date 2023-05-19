using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BTL
{
    public partial class F_xemtour : Form
    {
        public F_xemtour()
        {
            InitializeComponent();
            Hienthi_DGV();
        }

        private void DGV_Xem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Hienthi_DGV()
        {
            string strcon = @"Data Source=DESKTOP-O72ICE8\SQLEXPRESS;Initial Catalog=QLDL;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Khachhang.*, Tour.thanhtien FROM Khachhang JOIN Tour ON Khachhang.matour = Tour.matour", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGV_Xem.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string strcon = @"Data Source=DESKTOP-O72ICE8\SQLEXPRESS;Initial Catalog=QLDL;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);//khởi tạo
            if (txtkey.Text == "")
            {
                Hienthi_DGV();
            }
            else
            {
                conn = new SqlConnection(strcon);
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Khachhang where makh like N'%"
                        + txtkey.Text + "%'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGV_Xem.DataSource = dt;
                    txtkey.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }
    }
}

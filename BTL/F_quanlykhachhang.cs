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
    public partial class F_quanlykhachhang : Form
    {
        private string strcon = @"Data Source=DESKTOP-O72ICE8\SQLEXPRESS;Initial Catalog=QLDL;Integrated Security=True";
        private SqlConnection conn;//khởi tạo
        private SqlCommand cmd;
        public F_quanlykhachhang()
        {
            InitializeComponent();
            conn = new SqlConnection(strcon);
            Hienthi_DGV();
            ht();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            

            if(txtmakh.Text == "" || cbbmatour.Text == "")
            {
                MessageBox.Show("Chưa nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string strdup = "select count(makh) from Khachhang where makh = '" + txtmakh.Text + "'";
                    cmd = new SqlCommand(strdup, conn);
                    var dup = Convert.ToInt32(cmd.ExecuteScalar());
                    if (dup > 0)
                    {
                        MessageBox.Show("Mã" + txtmakh.Text + "đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string sql_insert = "insert into Khachhang values (N'" + txtmakh.Text + "',N'" + txttenkh.Text + "','" + txtns.Text + "', N'" + cbbgt.Text + "', N'" + txtdiachi.Text + "',N'" + txtsdt.Text + "',N'" + cbbmatour.Text+"')";
                        cmd = new SqlCommand(sql_insert, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Clear_form();
                        thanhtien();
                        Hienthi_DGV();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            conn.Close();
        }

        public void Clear_form()
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtns.Clear();
            cbbgt.Items.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            cbbmatour.Items.Clear();
        }
        public void Hienthi_DGV()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Khachhang", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGV_KH.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex,  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        public void ht()
        {
            conn.Open();
            string sql_select = "select matour from Tour";

            cmd = new SqlCommand(sql_select, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string maTour = reader["matour"].ToString();
                cbbmatour.Items.Add(maTour);
            }
            conn.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
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
                    DGV_KH.DataSource = dt;
                    txtkey.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void DGV_KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakh.Text = DGV_KH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttenkh.Text = DGV_KH.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtns.Text = DGV_KH.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbbgt.Text = DGV_KH.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdiachi.Text = DGV_KH.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsdt.Text = DGV_KH.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbbmatour.Text = DGV_KH.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sql_update = "update Khachhang set makh = '" + txtmakh.Text + "', tenkh = N'" + txttenkh.Text + "', namsinh = '" + txtns.Text + "', gioitinh = N'" + cbbgt.Text + "', diachi = N'" + txtdiachi.Text + "', sdt = '" + txtsdt.Text + "', matour = '" + cbbmatour.Text + "' where makh = '" + txtmakh.Text + "'";
                    cmd = new SqlCommand(sql_update, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hienthi_DGV();
                    Clear_form();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            conn.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from Khachhang where makh = '" + txtmakh.Text + "'", conn);
                    DialogResult msg = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi_DGV();
                        Clear_form();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        public void thanhtien()
        {
            string sql_select = "select thanhtien from Tour where matour = '" + cbbmatour.Text + "'";
            cmd = new SqlCommand(sql_select, conn);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Hiển thị dữ liệu lên DataGridView
            DGV_KH.DataSource = dt;
        }
    }
}

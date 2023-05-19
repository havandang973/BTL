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
    public partial class F_quanlytour : Form
    {

        private string strcon = @"Data Source=DESKTOP-O72ICE8\SQLEXPRESS;Initial Catalog=QLDL;Integrated Security=True";
        private SqlConnection conn;//khởi tạo
        private SqlCommand cmd;
        public F_quanlytour()
        {
            InitializeComponent();
            conn = new SqlConnection(strcon);
            Hienthi_DGV();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmatour.Text == "")
            {
                MessageBox.Show("Chưa nhập mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string strdup = "select count(matour) from Tour where matour = '" + txtmatour.Text + "'";
                    cmd = new SqlCommand(strdup, conn);
                    var dup = Convert.ToInt32(cmd.ExecuteScalar());
                    if (dup > 0)
                    {
                        MessageBox.Show("Mã'" + txtmatour.Text + "'đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string sql_insert = "Insert into Tour (matour, tentour, giatour, soluong, ngaybatdau, ngayketthuc, phuongtien, thanhtien) values (N'" + txtmatour.Text + "', N'" + txttentour.Text + "','" + txtgiatour.Text + "','" + txtsoluong.Text + "','"+ txtngaybatdau.Text + "','" + txtngayketthuc.Text + "', N'" + txtphuongtien.Text + "', '0')";
                        cmd = new SqlCommand(sql_insert, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void Hienthi_DGV()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Tour", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGV_Tour.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        
        public void thanhtien()
        {
            int soLuong = int.Parse(txtsoluong.Text);
            float donGia = float.Parse(txtgiatour.Text);
            // Tính thành tiền
            float thanhTien = soLuong * donGia;

            string sql_update = "UPDATE Tour SET thanhtien = '" + thanhTien + "' WHERE matour = '" + txtmatour.Text + "'";
            cmd = new SqlCommand(sql_update, conn);
            cmd.ExecuteNonQuery();
        }

        private void DGV_Tour_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtmatour.Text = DGV_Tour.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttentour.Text = DGV_Tour.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgiatour.Text = DGV_Tour.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsoluong.Text = DGV_Tour.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtngaybatdau.Text = DGV_Tour.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtngayketthuc.Text = DGV_Tour.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtphuongtien.Text = DGV_Tour.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        public void Clear_form()
        {
            txtmatour.Clear();
            txttentour.Clear();
            txtgiatour.Clear();
            txtsoluong.Clear();
            txtngaybatdau.Clear();
            txtngayketthuc.Clear();
            txtphuongtien.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmatour.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sql_update = "update Tour set matour = '" + txtmatour.Text + "', tentour = N'" + txttentour.Text + "', giatour = '" + txtgiatour.Text + "', soluong = N'" + txtsoluong.Text + "', ngaybatdau = N'" + txtngaybatdau.Text + "', ngayketthuc = '" + txtngayketthuc.Text + "', phuongtien = N'" + txtphuongtien.Text + "' where matour = '" + txtmatour.Text + "'";
                    cmd = new SqlCommand(sql_update, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    thanhtien();
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
            if (txtmatour.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from Tour where matour = '" + txtmatour.Text + "'", conn);
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
                    SqlDataAdapter da = new SqlDataAdapter("select * from Tour where matour like N'%"
                        + txtkey.Text + "%'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGV_Tour.DataSource = dt;
                    txtkey.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

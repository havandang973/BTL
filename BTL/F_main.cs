using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class F_main : Form
    {
        public F_main()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_dangnhap dn = new F_dangnhap();
            dn.Show();
        }

        private void quảnLýTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_quanlytour qlt = new F_quanlytour();
            qlt.Show();
        }

        private void qUảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_quanlynhanvien qlnv = new F_quanlynhanvien();
            qlnv.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_quanlykhachhang qlkh = new F_quanlykhachhang();
            qlkh.Show();
        }

        private void xemTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_xemtour xt = new F_xemtour();
            xt.Show();
        }
    }
}

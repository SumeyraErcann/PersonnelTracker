using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTracker
{
    public partial class FrmVacationList : Form
    {
        public FrmVacationList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //harf yazamıyoruz sadece rakam
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmVacationInfo frm = new FrmVacationInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmVacationInfo frm = new FrmVacationInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}

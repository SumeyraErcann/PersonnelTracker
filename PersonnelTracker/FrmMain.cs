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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpr_Click(object sender, EventArgs e)
        {
            FrmJobList frm = new FrmJobList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnelList frm = new FrmPersonnelList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            FrmSalaryList frm = new FrmSalaryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

        }

        private void btnVacation_Click(object sender, EventArgs e)
        {
            FrmVacationList frm = new FrmVacationList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            FrmDeptList frm = new FrmDeptList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FrmPositionList frm = new FrmPositionList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

using BLL;
using DAL;
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
    public partial class FrmDeptList : Form
    {
        public FrmDeptList()
        {
            InitializeComponent();
        }
        List<Departman> list = new List<Departman>();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDepartments frm = new FrmDepartments();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            list = DepartmentBLL.GetAll();
            dgDepartments.DataSource = list;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmDepartments frm = new FrmDepartments();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
        private void FrmDeptList_Load(object sender, EventArgs e)
        {
            list = DepartmentBLL.GetAll();
            dgDepartments.DataSource = list;
            dgDepartments.Columns[0].HeaderText = "Departman ID";
            dgDepartments.Columns[0].Visible = false;
            dgDepartments.Columns[1].HeaderText = "Departman ADI";

        }
    }
}

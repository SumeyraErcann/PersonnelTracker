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
    public partial class FrmDepartments : Form
    {
        public FrmDepartments()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartment.Text=="")
            {
                MessageBox.Show("Lütfen Departman Adını yazınız");
            }
            else
            {
               Departman dpt = new Departman();
               dpt.DepartmanAd = txtDepartment.Text.Trim();
               DepartmentBLL.AddDepartment(dpt);
               MessageBox.Show("Departman Eklendi");
                txtDepartment.Clear();
            }
            
        }
    }
}

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
    public partial class FrmPositions : Form
    {
        public FrmPositions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<Departman> departments = new List<Departman>();

        private void FrmPositions_Load(object sender, EventArgs e)
        {
            departments = DAL.DAO.DepartmentDAO.GetAll();
            cbDepartments.DataSource = departments;
            cbDepartments.DisplayMember = "DepartmanAd";
            cbDepartments.ValueMember = "ID";
            cbDepartments.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPositionName.Text.Trim()=="")
            {
                MessageBox.Show("Lütfen Pozisyon Adını yazınız.");
            }
            else if (cbDepartments.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen departman seçiniz.");
            }
            else
            {
                Pozisyon pozisyon = new Pozisyon();
                pozisyon.PozisyonAd = txtPositionName.Text.Trim();
                pozisyon.DepartmanId = Convert.ToInt32(cbDepartments.SelectedValue);
                PositionBLL.AddPosition(pozisyon);
                MessageBox.Show("Pozisyon Eklendi");
                txtPositionName.Clear();
                cbDepartments.SelectedIndex = -1;
            }
        }
    }
}

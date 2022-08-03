using BLL;
using DAL;
using DAL.DTO;
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
    public partial class FrmSalaryInfo : Form
    {
        public FrmSalaryInfo()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SalaryDTO dto = new SalaryDTO();
        bool comboFull = false;
        private void FrmSalaryInfo_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
            dgPersonnals.DataSource = dto.Personnals;

            //dgPersonnals.Columns[0].Visible = false;
            dgPersonnals.Columns[1].HeaderText = "User No";
            dgPersonnals.Columns[2].HeaderText = "Ad";
            dgPersonnals.Columns[3].HeaderText = "Soyad";
            dgPersonnals.Columns[4].Visible = false; ;
            dgPersonnals.Columns[5].Visible = false;
            dgPersonnals.Columns[6].Visible = false; ;
            dgPersonnals.Columns[7].Visible = false;
            dgPersonnals.Columns[8].Visible = false; ;
            dgPersonnals.Columns[9].Visible = false;
            dgPersonnals.Columns[10].Visible = false;
            dgPersonnals.Columns[11].Visible = false;
            dgPersonnals.Columns[12].Visible = false; ;
            dgPersonnals.Columns[13].Visible = false; ;

            cbDepartments.DataSource = dto.Departments;
            cbDepartments.DisplayMember = "DepartmanAd";
            cbDepartments.ValueMember = "ID";
            cbDepartments.SelectedIndex = -1;

            if (dto.Departments.Count > 0)
                comboFull = true;

            cbPositions.DataSource = dto.Positions;
            cbPositions.DisplayMember = "PozisyonAd";
            cbPositions.ValueMember = "ID";
            cbPositions.SelectedIndex = -1;

            cbMonth.DataSource = dto.Months;
            cbMonth.DisplayMember = "Ay";
            cbMonth.ValueMember = "ID";
            cbMonth.SelectedIndex = -1;

            txtYear.Text = DateTime.Now.Year.ToString();
        }
        private void cbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmentId = Convert.ToInt32(cbDepartments.SelectedValue);
                cbPositions.DataSource = dto.Positions.Where(x => x.DepartmanId == departmentId).ToList();
            }
        }
        Maaş salary;
        private void dgPersonnals_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            salary = new Maaş();
            salary.PersonelId = Convert.ToInt32(dgPersonnals.Rows[e.RowIndex].Cells[0].Value);
            txtUserNo.Text = dgPersonnals.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgPersonnals.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dgPersonnals.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSalary.Text = dgPersonnals.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (salary.PersonelId == 0)
            {
                MessageBox.Show("Personel Seçiniz:");
            }
            else if (txtSalary.Text == "")
            {
                MessageBox.Show("Maaşı yazınız.");
            }
            else if (txtYear.Text == "")
            {
                MessageBox.Show("Yılı yazınız.");
            }
            else if (cbMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Ay seçiniz.");
            }
            else
            {
                salary.Miktar = Convert.ToInt32(txtSalary.Text);
                salary.Yıl = Convert.ToInt32(txtYear.Text);                
                salary.AyId = 1;
                
                //SalaryBLL.AddSalary(salary);
                MessageBox.Show("Maaş eklendi");
                txtSalary.Clear();
                txtYear.Clear();
                cbMonth.SelectedIndex = -1;
            }
        }
    }
}

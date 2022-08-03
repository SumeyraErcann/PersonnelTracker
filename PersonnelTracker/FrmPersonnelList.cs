using BLL;
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
    public partial class FrmPersonnelList : Form
    {
        public FrmPersonnelList()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            FrmPersonnelInfo frm = new FrmPersonnelInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmPersonnelInfo frm = new FrmPersonnelInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
        PersonnalDTO dto = new PersonnalDTO();
        bool comboFull = false;
        private void FrmPersonnelList_Load(object sender, EventArgs e)
        {
            dto = PersonnalBLL.GetAll();
            dgPersonnelList.DataSource = dto.Personnals;

            dgPersonnelList.Columns[0].Visible = false;
            dgPersonnelList.Columns[1].HeaderText = "User No";
            dgPersonnelList.Columns[2].HeaderText = "Ad";
            dgPersonnelList.Columns[3].HeaderText = "Soyad";
            dgPersonnelList.Columns[4].HeaderText = "Departman";
            dgPersonnelList.Columns[5].Visible = false;
            dgPersonnelList.Columns[6].HeaderText = "Pozisyon";
            dgPersonnelList.Columns[7].Visible = false;
            dgPersonnelList.Columns[8].HeaderText = "Maaş";
            dgPersonnelList.Columns[9].Visible = false;
            dgPersonnelList.Columns[10].Visible = false;
            dgPersonnelList.Columns[11].Visible = false;
            dgPersonnelList.Columns[12].HeaderText = "Adres";
            dgPersonnelList.Columns[13].HeaderText = "Doğum Tarihi";            

            cbDepartments.DisplayMember = "DepartmanAd";
            cbDepartments.ValueMember = "ID";
            cbDepartments.SelectedIndex = -1;
            if (dto.Departments.Count > 0)
               comboFull = true;            
            cbPositions.DataSource = dto.Positions;
            cbPositions.DisplayMember = "PozisyonAd";
            cbPositions.ValueMember = "ID";
            cbPositions.SelectedIndex = -1;
        }
        private void cbPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmentId = Convert.ToInt32(cbDepartments.SelectedValue);
                cbPositions.DataSource = dto.Positions.Where(x => x.DepartmanId == departmentId).ToList();
            }
        }
        List<PersonnalDetailDTO> listPerDto = new List<PersonnalDetailDTO>();
        private void btnFind_Click(object sender, EventArgs e)
        {
            listPerDto = dto.Personnals;
            if (txtUserNo.Text.Trim() != "")
                listPerDto = listPerDto.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();

            if (txtName.Text.Trim() != "")
                listPerDto = listPerDto.Where(x => x.Name.Contains(txtName.Text)).ToList(); 

            if (txtSurname.Text.Trim() != "")
                listPerDto = listPerDto.Where(x => x.Surname.Contains(txtSurname.Text)).ToList(); 

            if (cbDepartments.Text.Trim() != "")
                listPerDto = listPerDto.Where(x => x.DepartmentId == Convert.ToInt32(cbDepartments.SelectedValue)).ToList(); 

            if (cbPositions.Text.Trim() != "")
                listPerDto = listPerDto.Where(x => x.PositionId == Convert.ToInt32(cbPositions.SelectedValue)).ToList();
            
            dgPersonnelList.DataSource = listPerDto;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtUserNo.Clear();
            cbDepartments.SelectedIndex = -1;
            cbPositions.DataSource = dto.Positions;
            cbPositions.SelectedIndex = -1;
            dgPersonnelList.DataSource = dto.Personnals;
        }
    }
}

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
    public partial class FrmJobList : Form
    {
        public FrmJobList()
        {
            InitializeComponent();
        }
        JobDTO dto = new JobDTO();
        bool comboFull =false;
        private void FrmJobList_Load(object sender, EventArgs e)
        {
            FillGrid();
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
            FrmJobInfo frm = new FrmJobInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
            Clear(); 
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmJobInfo frm = new FrmJobInfo();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
            Clear();
        }
        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmentId = Convert.ToInt32(cbDepartments.SelectedValue);
                cbPositions.DataSource = dto.Positions.Where(x => x.DepartmanId == departmentId).ToList();
            }
        }
        List<JobDetail> list = new List<JobDetail>();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            list = dto.Jobs;
            if (txtUserNo.Text.Trim() != "")
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();

            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();

            if (txtSurname.Text.Trim() != "")
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();

            if (cbDepartments.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentId == Convert.ToInt32(cbDepartments.SelectedValue)).ToList();

            if (cbPositions.SelectedIndex != -1)
                list = list.Where(x => x.PositionId == Convert.ToInt32(cbPositions.SelectedValue)).ToList();

            if (cbJobSituation.SelectedIndex != -1)
                list = list.Where(x => x.JobSituationId == Convert.ToInt32(cbPositions.SelectedValue)).ToList();
            if (rbStart.Checked)
            {
                list = list.Where(x => x.JobStartDate >= Convert.ToDateTime(dtStart.Value) && x.JobFinishDate <=Convert.ToDateTime(dtFinish.Value)).ToList();
            }
            if (rbStart.Checked)
            {
                list = list.Where(x => x.JobFinishDate >= Convert.ToDateTime(dtStart.Value) && x.JobFinishDate <= Convert.ToDateTime(dtFinish.Value)).ToList();
            }
            dtgJobs.DataSource = list;
        }
        void FillGrid()
        {
            dto = JobBLL.GetAll();
            dtgJobs.DataSource = dto.Jobs;

            dtgJobs.Columns[0].HeaderText = "Başlık";
            dtgJobs.Columns[1].HeaderText = "User No";
            dtgJobs.Columns[2].HeaderText = "Ad";
            dtgJobs.Columns[3].HeaderText = "Soyad";
            dtgJobs.Columns[4].HeaderText = "Departman";
            dtgJobs.Columns[5].Visible = false;
            dtgJobs.Columns[6].HeaderText = "Pozisyon";
            dtgJobs.Columns[7].Visible = false;
            dtgJobs.Columns[8].Visible = false;
            dtgJobs.Columns[9].HeaderText = "İçerik";
            dtgJobs.Columns[10].HeaderText = "Durum";
            dtgJobs.Columns[11].HeaderText = "Baş. trh";
            dtgJobs.Columns[12].HeaderText = "Bit trh";
            dtgJobs.Columns[13].Visible = false;

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

            cbJobSituation.DataSource = dto.JobSituations;
            cbJobSituation.DisplayMember = "İşDurumAd";
            cbJobSituation.ValueMember = "ID";
            cbJobSituation.SelectedIndex = -1;
        }
        void Clear()
        {   
            txtName.Clear();
            txtSurname.Clear();
            txtUserNo.Clear();
            cbDepartments.SelectedIndex = -1;
            cbPositions.DataSource = dto.Positions;
            cbPositions.SelectedIndex = -1;
            cbJobSituation.SelectedIndex = -1;
            dtStart.Value = dtFinish.Value = DateTime.Today;
            dtgJobs.DataSource = dto.Jobs;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void dtgJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

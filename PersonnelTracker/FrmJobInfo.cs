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
    public partial class FrmJobInfo : Form
    {
        public FrmJobInfo()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        JobDTO dto = new JobDTO();
        bool comboFull = false;
        private void FrmJobInfo_Load(object sender, EventArgs e)
        {
            label9.Visible = cbJobSituation.Visible = false;
            dto = JobBLL.GetAll();
            dgPersonnals.DataSource = dto.Personnals;

            dgPersonnals.Columns[0].Visible = false;
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
        }
        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmentId = Convert.ToInt32(cbDepartments.SelectedValue);
                cbPositions.DataSource = dto.Positions.Where(x => x.DepartmanId == departmentId).ToList();
            }
        } 
        İş job;
        private void dgPersonnals_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            job = new İş();
            job.PersonelId = Convert.ToInt32(dgPersonnals.Rows[e.RowIndex].Cells[0].Value);
            txtUserNo.Text = dgPersonnals.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgPersonnals.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dgPersonnals.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (job.PersonelId == 0)
            {
                MessageBox.Show("Personel Seçiniz:");
            }
            else if (txtTitle.Text == "")
            {
                MessageBox.Show("Başlığı yazınız.");
            }
            else if (txtContent.Text == "")
            {
                MessageBox.Show("İçeriği yazınız.");
            }
            else
            {
                job.Başlık = txtTitle.Text;
                job.İçerik = txtContent.Text;
                job.İşDurumId = 1;
                job.İşBaşlamaTarihi = DateTime.Today;
                JobBLL.AddJob(job);
                MessageBox.Show("İş eklendi");
                txtTitle.Clear();
                txtContent.Clear();
            }

        }
    }
}

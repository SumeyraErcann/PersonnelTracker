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
    public partial class FrmPositionList : Form
    {
        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPositions frm = new FrmPositions();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            list = PositionBLL.GetAll();
            dgPositions.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmPositions frm = new FrmPositions();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        List<PositionDTO> list = new List<PositionDTO>();

        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            list = PositionBLL.GetAll();
            dgPositions.DataSource = list;
            dgPositions.Columns["ID"].Visible = false;
            dgPositions.Columns["PozisyonAd"].HeaderText = "Pozisyon Adı";
            dgPositions.Columns["DepartmanId"].Visible = false;
            dgPositions.Columns["DepartmentName"].HeaderText = "Departman Adı";
           
        }
    }
}

using BLL;
using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTracker
{
    public partial class FrmPersonnelInfo : Form
    {
        public FrmPersonnelInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; //harf yazamıyoruz sadece rakam
            }
        }

        private void chkisAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
        PersonnalDTO dto = new PersonnalDTO();
        private void FrmPersonnelInfo_Load(object sender, EventArgs e)
        {
            dto = PersonnalBLL.GetAll();
            cbDepartments.DataSource = dto.Departments;
            cbDepartments.DisplayMember = "DepartmanAd";
            cbDepartments.ValueMember = "ID";
            cbDepartments.SelectedIndex = -1;
            cbPositions.DataSource = dto.Positions;
            cbPositions.DisplayMember = "PozisyonAd";
            cbPositions.ValueMember = "ID";
            cbPositions.SelectedIndex = -1;
            if (dto.Departments.Count > 0)
                cbFull = true;
            
        }
        bool cbFull = false;
        string picName = "";
        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFull)
            {
                int departmentId = Convert.ToInt32(cbDepartments.SelectedValue);
                cbPositions.DataSource = dto.Positions.Where(x=> x.DepartmanId == departmentId).ToList();
            }
           
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pbImage.Load(ofd.FileName);
                txtPicture.Text = ofd.FileName;
                picName = Guid.NewGuid().ToString(); //uniq identifiter yani adlandırma yapacak
                picName += ofd.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {   MessageBox.Show("User NO");
                /*return*/;
            }
            else if (PersonnalBLL.IsUnique(Convert.ToInt32(txtUserNo.Text)))
            {
                MessageBox.Show("Lütfen Başka Bir User No seçiniz. Bu User No kullanılmaktadır...");
            }            
            if (txtName.Text.Trim() == "")
            {   MessageBox.Show("Ad");
                /*return*/;
            }
            if (txtSurname.Text.Trim() == "")
            {   MessageBox.Show("Soyad");
                /*return*/;
            }
            if (txtSalary.Text.Trim() == "")
            {   MessageBox.Show("Maaş");
                /*return*/;
            }
            if (txtPassword.Text.Trim() == "")
            {   MessageBox.Show("Şifre");
                /*return*/;
            }
            if (txtPicture.Text.Trim() == "")
            {   MessageBox.Show("Resim");
                /*return*/;
            }
            if (cbDepartments.SelectedIndex == -1)
            {   MessageBox.Show("Departman");
                /*return*/;
            }
            if (cbPositions.SelectedIndex == -1)
            {   MessageBox.Show("Pozisyon");
                /*return*/;
            }
            else
            {
                Personel p = new Personel();
                p.Ad = txtName.Text;
                p.Adres = txtAddress.Text;
                p.DepartmanId = Convert.ToInt32(cbDepartments.SelectedValue);
                p.DoğumTarihi = dtpBirthday.Value;
                p.İşAdmin = chkisAdmin.Checked;
                p.Maaş = Convert.ToInt32(txtSalary.Text);
                p.Password = txtPassword.Text;
                p.PozisyonId = Convert.ToInt32(cbPositions.SelectedValue);
                p.Resim = picName;
                p.Soyad = txtSurname.Text;
                p.UserNo = Convert.ToInt32(txtUserNo.Text);

                PersonnalBLL.AddPersonnal(p);
                File.Copy(txtPicture.Text, @"pictures\\" + picName);
                MessageBox.Show("Personel Eklendi...");

                txtAddress.Clear();
                txtName.Clear();
                txtPassword.Clear();
                pbImage.Image = null;
                txtPicture.Clear();
                chkisAdmin.Checked = false;
                cbDepartments.SelectedIndex = -1;
                cbPositions.DataSource = dto.Positions;
                cbPositions.SelectedIndex = -1;
                dtpBirthday.Value = DateTime.Now;
                txtSalary.Clear();
                txtSurname.Clear();
                txtUserNo.Clear();
                picName = "";
            }
            
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text =="")
            {
                MessageBox.Show("Lütfen User No belirtiniz");
            }
            else if (PersonnalBLL.IsUnique(Convert.ToInt32(txtUserNo.Text)))
            {
                MessageBox.Show("Lütfen Başka Bir User No seçiniz. Bu User No kullanılmaktadır...");
                return;
            }
            else
            {
                MessageBox.Show("Bu User No Kullanılabilir.");
            }

        }
    }
}

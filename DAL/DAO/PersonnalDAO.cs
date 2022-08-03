using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PersonnalDAO : PersonnalDataContext
    {
        public static void AddPersonnal(Personel p)
        {
            try
            {
               db.Personels.InsertOnSubmit(p);
               db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<PersonnalDetailDTO> GetAll()
        {
            List<PersonnalDetailDTO> list = new List<PersonnalDetailDTO>();
            var liste = (from p in db.Personels 
                         join d in db.Departmans on p.DepartmanId equals d.ID
                         join pz in db.Pozisyons on p.PozisyonId equals pz.ID
                         select new
                         {
                             personnalId = p.ID,
                             name = p.Ad,
                             surname = p.Soyad,
                             password = p.Password,
                             department = d.DepartmanAd,
                             departmentId = d.ID,
                             position = pz.PozisyonAd,
                             positionId = pz.ID,
                             isAdmin = p.İşAdmin,
                             salary = p.Maaş,
                             picture = p.Resim,
                             birthday = p.DoğumTarihi,
                             address = p.Adres,
                             userNo = p.UserNo,
                         }).OrderBy(x=> x.personnalId).ToList();
            foreach (var item in liste)
            {
                PersonnalDetailDTO dto = new PersonnalDetailDTO
                {
                   Address = item.address,
                   Birthday = Convert.ToDateTime( item.birthday),
                   DepartmentId = item.departmentId,
                   DepartmentName = item.department,
                   IsAdmin = item.isAdmin,
                   Name = item.name,
                   Password = item.password,
                   PersonnalId = item.personnalId,
                   Picture = item.picture,
                   PositionId = item.positionId,
                   PositionName = item.position,
                   Salary = item.salary,
                   Surname = item.surname,
                   UserNo = item.userNo
                };
                list.Add(dto);
            }
                return list;
        }

        public static List<Personel> Get(int userNo)
        {
            try
            {
                return db.Personels.Where(x => x.UserNo == userNo).ToList();
            }
            catch 
            {
                return new List<Personel>();
            }
        }
    }
}

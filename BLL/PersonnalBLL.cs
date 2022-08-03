using DAL;
using DAL.DAO;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonnalBLL
    {
        public static PersonnalDTO GetAll()
        {
            PersonnalDTO dto = new PersonnalDTO();
            dto.Departments = DepartmentDAO.GetAll();
            dto.Positions = PositionDAO.GetAll();
            dto.Personnals = PersonnalDAO.GetAll();
            return dto;
        }

        public static void AddPersonnal(Personel p)
        {
            PersonnalDAO.AddPersonnal(p);
        }

        public static bool IsUnique(int userNo)
        {
            List<Personel> personals = PersonnalDAO.Get(userNo);
            if (personals.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
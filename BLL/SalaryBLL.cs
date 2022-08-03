using DAL.DAO;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalaryBLL
    {
        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Departments = DepartmentDAO.GetAll();
            dto.Positions = PositionDAO.GetAll();
            dto.Personnals = PersonnalDAO.GetAll();
            dto.Months = SalaryDAO.GetMonths();
            return dto;
        }
    }
}

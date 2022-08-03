using DAL;
using DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentBLL
    {
        public static void AddDepartment(Departman dpt)
        {
            DepartmentDAO.AddDepartment(dpt);            
        }
        public static List<Departman> GetAll()
        {
            return DepartmentDAO.GetAll();
        }
    }
}

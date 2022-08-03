using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DepartmentDAO : PersonnalDataContext
    {
        public static void AddDepartment(Departman dpt)
        {
            try
            {
                db.Departmans.InsertOnSubmit(dpt);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public static List<Departman> GetAll()
        {
            try
            {
                return db.Departmans.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

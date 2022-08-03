using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SalaryDAO : PersonnalDataContext
    {
        public static List<Aylar> GetMonths()
        {
            return db.Aylars.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SalaryDetailDTO
    {
        public int PersonnalId { get; set; }
        public int UserNo { get; set; }        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string PositionName { get; set; }        
        public int PositionId { get; set; }
        public int SalaryYear { get; set; }
        public int SalaryMonth { get; set; }
        public int Salary { get; set; }
        public int SalaryId { get; set; }
    }
}

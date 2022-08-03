using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SalaryDTO
    {
        public List<Departman> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<PersonnalDetailDTO> Personnals { get; set; }        
        public List<SalaryDetailDTO> Salaries { get; set; }
        public List<Aylar> Months { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class JobDTO
    {
        public List<Departman> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<PersonnalDetailDTO> Personnals { get; set; }
        public List<İşDurumu> JobSituations { get; set; }
        public List<JobDetail> Jobs { get; set; }


    }
}

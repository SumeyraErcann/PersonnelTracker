using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class JobDetail
    { 
        public string Title { get; set; }
        public int UserNo { get; set; }        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int PersonnalId { get; set; }
        public string Content { get; set; }
        public string JobSituationName { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime? JobFinishDate { get; set; }
        public int JobId { get; set; }
        public int JobSituationId { get; set; }


    }
}

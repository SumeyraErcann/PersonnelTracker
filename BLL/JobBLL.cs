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
    public class JobBLL
    {
        public static JobDTO GetAll()
        {
            JobDTO dto = new JobDTO();
            dto.Departments = DepartmentDAO.GetAll();
            dto.Positions = PositionDAO.GetAll();
            dto.Personnals = PersonnalDAO.GetAll();
            dto.JobSituations = JobDAO.GetJobSituations();
            dto.Jobs = JobDAO.GetAll();
            return dto;

        }

        public static void AddJob(İş job)
        {
            JobDAO.AddJob(job);
        }
    }
}

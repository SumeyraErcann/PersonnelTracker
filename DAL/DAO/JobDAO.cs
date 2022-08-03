using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class JobDAO : PersonnalDataContext
    {
        public static List<İşDurumu> GetJobSituations()
        {
            return db.İşDurumus.ToList();
        }
        public static void AddJob(İş job)
        {
            try
            {
                db.İşs.InsertOnSubmit(job);
                db.SubmitChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<JobDetail> GetAll()
        {
            List<JobDetail>  liste = new List<JobDetail>();
            var list = (from j in db.İşs
                        join p in db.Personels on j.PersonelId equals p.ID
                        join d in db.Departmans on p.DepartmanId equals d.ID
                        join pz in db.Pozisyons on p.PozisyonId equals pz.ID
                        join sit in db.İşDurumus on j.İşDurumId equals sit.ID
                        select new 
                        { 
                            JobId = j.ID,
                            title = j.Başlık,
                            content = j.İçerik,
                            startdate = j.İşBaşlamaTarihi,
                            finishdate = j.İşBitişTarihi,
                            userno = p.UserNo,
                            name = p.Ad,
                            surname = p.Soyad,
                            department = d.DepartmanAd,
                            departmentId = d.ID,
                            position = pz.PozisyonAd,
                            positionId = pz.ID,
                            jobsituation = sit.İşDurumAd,
                            jobsituationId = sit.ID                            
                        }).OrderBy(x=> x.startdate).ToList();

            foreach (var item in list)
            {
                JobDetail job = new JobDetail()
                {
                    Content = item.content,
                    DepartmentId = item.departmentId,
                    DepartmentName = item.department,
                    JobFinishDate = item.finishdate,
                    JobId = item.JobId,
                    JobSituationName = item.jobsituation,
                    JobSituationId = item.jobsituationId,
                    JobStartDate = item.startdate,
                    Name = item.name,
                    PositionId = item.positionId,
                    PositionName = item.position,
                    Surname = item.surname,
                    Title = item.title,
                    UserNo = item.userno

                };
                liste.Add(job);
            }
            return liste;
        }
    }
}

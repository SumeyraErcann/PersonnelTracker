using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PositionDAO : PersonnalDataContext
    {
        public static void AddPosition(Pozisyon pozisyon)
        {
            try
            {
                db.Pozisyons.InsertOnSubmit(pozisyon);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<PositionDTO> GetAll()
        {
            try
            {
                var list = (from p in db.Pozisyons join d in db.Departmans on p.DepartmanId equals d.ID 
                            select new { 
                                         PositionId = p.ID,
                                         PositionName = p.PozisyonAd,
                                         DepartmentId = d.ID,
                                         DepartmentName = d.DepartmanAd
                                        }
                            ).OrderBy(x=>x.PositionId).ToList();

                List<PositionDTO> listDTO = new List<PositionDTO>();

                foreach (var item in list)
                {
                    PositionDTO position = new PositionDTO();
                    position.ID = item.PositionId;
                    position.PozisyonAd = item.PositionName;
                    position.DepartmanId = item.DepartmentId;
                    position.DepartmentName = item.DepartmentName;
                    listDTO.Add(position);
                }
                return listDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

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
    public class PositionBLL
    {
        public static void AddPosition(Pozisyon pozisyon)
        {
            PositionDAO.AddPosition(pozisyon);
        }

        public static List<PositionDTO> GetAll()
        {
            return PositionDAO.GetAll();
        }
    }
}

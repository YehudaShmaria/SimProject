using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace DalSim
{
    public class DalOnlySim
    {
        //שימוש במחלקת EF
        private SimEntities entities = new SimEntities();

        //קבל כל נתוני הסימים
        public List<OnlySim> GetSims()
        {
            List<OnlySim> onlySims = entities.OnlySims.ToList();
            return onlySims;
        }

        //קבל נתון סים קונקרהטי
        public OnlySim GetOnlySim(int id)
        {
           OnlySim onlySim = GetSims().FindAll(s => s.SId == id).Single();
           return onlySim;
        }

        //בצע חיפוש לסים מסויים
        public List<OnlySim> SearceSim(string Filter)
        {
            List<OnlySim> s = GetSims().FindAll(i => i.ImeiSim == Filter || i.PunNumber == Filter).ToList();
            return s;
        }
    }
}

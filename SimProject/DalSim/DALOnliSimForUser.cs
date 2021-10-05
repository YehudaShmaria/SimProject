using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSim
{
    public class DALOnliSimForUser
    {
        //שימוש במחלקת EF
        private SimEntities entities = new SimEntities();

        private List<int> GetAllData(string username)
        {
            List<Sim> sims = entities.Sims.ToList().FindAll(i => i.Unitname == username);
            List<int> IdNumbres = (from s in sims
                                  select s.SId).ToList();
            return IdNumbres;
        }

        //קבל כל נתוני הסימים
        public List<OnlySim> GetSims(string userName)
        {
            List<int> Numbers = GetAllData(userName);
            List<OnlySim> onlySims = entities.OnlySims.Where(m => Numbers.Contains(m.SId)).ToList();
            return onlySims;
        }

        //קבל נתון סים קונקרהטי
        public OnlySim GetOnlySim(int id, string username)
        {
            OnlySim onlySim = GetSims(username).FindAll(s => s.SId == id).Single();
            return onlySim;
        }

        //בצע חיפוש לסים מסויים
        public List<OnlySim> SearceSim(string username, string Filter)
        {
            List<OnlySim> s = GetSims(username).FindAll(i => i.ImeiSim == Filter || i.PunNumber == Filter).ToList();
            return s;
        }
    }
}

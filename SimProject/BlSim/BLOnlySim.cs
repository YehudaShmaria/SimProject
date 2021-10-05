using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalSim;

namespace BlSim
{
    public class BLOnlySim
    {
        //שימוש במחלקת DAL
        DalOnlySim dalOnlySim = new DalOnlySim();

        //קבל כל נתוני הסימים
        public List<OnlySim> GetSims()
        {
            List<OnlySim> onlySims = dalOnlySim.GetSims();
            return onlySims;
        }

        //הבא סים קונקרהטי
        public OnlySim GetOnlySim(int id)
        {
           OnlySim sim = dalOnlySim.GetOnlySim(id);
            return sim;
        }

        // עדכן נתוני סים והמרתם לבסיס כל הנתונים
        public void UpdateOnlySim(int id, OnlySim Newsim)
        {
            DalAllData d = new DalAllData();
            Sim s = d.GetOneData(id);
            s.Company_Name = Newsim.Company_Name;
            s.Apn = Newsim.Apn;
            s.ImeiSim = Newsim.ImeiSim;
            s.Ip = Newsim.Ip;
            s.Packageplan = Newsim.Packageplan;
            s.PunNumber = Newsim.PunNumber;
            s.StartDate = Newsim.StartDate;
            d.UpdateAllData(id, s);
        }

        //חפש סים מסויים
        public List<OnlySim> SearceSim(string Filter)
        {
            List<OnlySim> s = dalOnlySim.SearceSim(Filter);
            return s;
        }
    }
}

using DalSim;
using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlSim
{
    public class BLAllData
    {
        //DAL שימוש במחלקת 
        private DalAllData allData = new DalAllData();

        //הבא את כל נתוני הסימים
        public List<Sim> GetAllData()
        {
            List<Sim> sims = allData.GetAllData();
            return sims;
        }

        //צור סים חדש
        public void CreateAllData(Sim Data)
        {
            allData.CreateAllData(Data);
        }

        //הבא סים קונקרהטי
        public Sim GetOneData(int id)
        {
            Sim s =  allData.GetOneData(id);
            return s;
        }

        //עדכן נתוני סים
        public void UpdateAllData(int id, Sim sim)
        {
            allData.UpdateAllData(id, sim);
        }

        //מחק סים מסויים
        public void DeleteAllData(int id, Sim sim)
        {
            allData.DeleteAllData(id, sim);
        }

        //חפש לפי מספר הפלאפון של הסים
        public List<Sim> SearceSim(string Filter)
        {
            List<Sim> s = allData.SearceSim(Filter);
            return s;
        }
    }
}

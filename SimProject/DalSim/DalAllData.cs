using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace DalSim
{
    public class DalAllData
    {
        //שימוש במחקת EF
       private SimEntities entities = new SimEntities();

        //קבל את כל הנתונים
        public List<Sim> GetAllData()
        {
            List<Sim> sims = entities.Sims.ToList();
            return sims;
        }

        //צור סים חדש
        public void CreateAllData(Sim Data)
        {
            using (entities)
            {
                entities.Sims.Add(Data);
                entities.SaveChanges();
            }
        }

        //קבל סים אחד קונקרהטי
        public Sim GetOneData(int id)
        {
            Sim sim = GetAllData().FindAll(s => s.SId == id).Single();
            return sim;
        }

        //עדכן נתוני סים
        public void UpdateAllData(int id, Sim Newsim)
        {
            Sim s = GetOneData(id);
            using (entities)
            { 
                s.Company_Name = Newsim.Company_Name;
                s.PunNumber = Newsim.PunNumber;
                s.Packageplan = Newsim.Packageplan;
                s.ImeiSim = Newsim.ImeiSim;
                s.Ip = Newsim.Ip;
                s.Apn = Newsim.Apn;
                s.StartDate = Newsim.StartDate;
                s.Unitname = Newsim.Unitname;
                s.Contact = Newsim.Contact;
                s.DeviceName = Newsim.DeviceName;
                s.ImeiDevice = Newsim.ImeiDevice;
                s.Note = Newsim.Note;
                entities.SaveChanges();
            }
        }

        //מחק את כל הנתונים של סים
        public void DeleteAllData(int id, Sim sim)
        {
            Sim s = GetOneData(id);
            using (entities)
            {
                entities.Sims.Remove(s);
                entities.SaveChanges();
            }
        }

        //קבל סים מסויים ע"י חיפוש
        public List<Sim> SearceSim(string Filter)
        {
            List<Sim> s = GetAllData().FindAll(i => i.ImeiSim == Filter || i.PunNumber == Filter || i.ImeiDevice == Filter).ToList();
            return s;
        }

    }
}

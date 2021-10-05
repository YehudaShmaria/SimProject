using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalSim
{
    public class DalOnlyDeviceForUser
    {
        //שימוש במחלקת EF
        private SimEntities entities = new SimEntities();

        //קבלת כל הנתונים בשביל לעשות עליהם סינון נתונים
        private List<int> GetAllData(string username)
        {
            List<Sim> sims = entities.Sims.ToList().FindAll(i => i.Unitname == username);
            List<int> IdNumbres = (from s in sims
                                   select s.SId).ToList();
            return IdNumbres;
        }
        
        //קבלת כל כל המכשירים ללקוח מסויים
        public List<OnlyDevice> GetDevices(string username)
        {
            List<int> Numbers = GetAllData(username);
            List<OnlyDevice> devices = entities.OnlyDevices.Where(m => Numbers.Contains(m.SId)).ToList();
            return devices;

        }

        //קבלת מכשיר ספציפי ללקוח מסויים
        public OnlyDevice GetOnlyDevice(int id, string username)
        {
            OnlyDevice onlyDevice = GetDevices(username).FindAll(s => s.SId == id).Single();
            return onlyDevice;
        }

        //חיפוש מכשיר מסויים ללקוח מסויים
        public List<OnlyDevice> SearceDevice(string username, string Filter)
        {
            List<OnlyDevice> s = GetDevices(username).FindAll(i => i.DeviceName == Filter || i.ImeiDevice == Filter).ToList();
            return s;
        }
    }
}

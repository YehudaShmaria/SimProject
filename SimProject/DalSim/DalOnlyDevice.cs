using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace DalSim
{
    public class DalOnlyDevice
    {
        //שימוש במחלקת EF
        private SimEntities entities = new SimEntities();

        //קבל כל נתוני מכשירים
        public List<OnlyDevice> GetDevices()
        {
            List<OnlyDevice> devices = entities.OnlyDevices.ToList();
            return devices;
        }

        //קבל נתוני מכשיר קונקרהטי
        public OnlyDevice GetOnlyDevice(int id)
        {
            OnlyDevice device = GetDevices().FindAll(d => (d.SId == id)).Single();
            return device;
        }

        //מצא מכשיר מסויים
        public List<OnlyDevice> SearchDevice(string Filter)
        {
            List<OnlyDevice> devices = GetDevices().FindAll(i => i.ImeiDevice == Filter||i.DeviceName.Contains(Filter)).ToList();
            return devices;
        }
    }
}

using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalSim;

namespace BlSim
{
    public class BLOnlyDevice
    { 
        //DAL שימוש במחלקת 
        private DalOnlyDevice dalOnlyDevice = new DalOnlyDevice();

        //הבא את כל נתוני המכשירים בלבד
        public List<OnlyDevice> GetDevices()
        {
            List<OnlyDevice> devices = dalOnlyDevice.GetDevices();
            return devices;
        }

        //הבא נתון מכשיר קונקרהטי
        public OnlyDevice GetOnlyDevice(int id)
        {
            OnlyDevice device = dalOnlyDevice.GetOnlyDevice(id);
            return device;
        }

        // עדכן נתוני מכשיר והמרתם לבסיס כל הנתונים
        public void UpDateDevice(int id, OnlyDevice device)
        {
            DalAllData allData = new DalAllData();
            Sim s = allData.GetOneData(id);
            s.DeviceName = device.DeviceName;
            s.ImeiDevice = device.ImeiDevice;
            allData.UpdateAllData(id, s);
        }

        //חפש מכשיר מסויים
        public List<OnlyDevice> SearchDevice(string Filter)
        {
            List<OnlyDevice> devices = dalOnlyDevice.SearchDevice(Filter);
            return devices;
        }
    }
}

using DalSim;
using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlSim
{
    public class BlOnlyDeviceForUser
    {
        //שימוש במחלקת BL
        DalSim.DalOnlyDeviceForUser forUser = new DalSim.DalOnlyDeviceForUser();

        //קבלת כל המכשירים ללקוח מסויים
        public List<OnlyDevice> GetDevices(string userName)
        {

            List<OnlyDevice> onlyDevices = forUser.GetDevices(userName);
            return onlyDevices;
        }

        //קבלת מכשיר ספציפי ללקוח מסויים
        public OnlyDevice GetOnlyDevice(int id, string username)
        {
            OnlyDevice onlyDevice = forUser.GetOnlyDevice(id, username);
            return onlyDevice;
        }

        //עדכון של לקוח למכשיר מסויים
        public void UpDateDevice(int id, OnlyDevice device)
        {
            DalAllData allData = new DalAllData();
            Sim s = allData.GetOneData(id);
            s.DeviceName = device.DeviceName;
            s.ImeiDevice = device.ImeiDevice;
            allData.UpdateAllData(id, s);
        }

        //חיפוש של לקוח למכשיר מסויים
        public List<OnlyDevice> SearceOnlyDevice(string username, string Filter)
        {
            List<OnlyDevice> onlyDevices = forUser.SearceDevice(username, Filter);
            return onlyDevices;
        }
    }
}

using DalSim;
using ProtocolSim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SimProject.Models
{
    public class OnlyDemoUser
    {
        [DisplayName("שם יחידה/ לקוח")]
        public string NameUnit { get; set; }
        [DisplayName("מספר הסימים")]
        public int NumOfSim { get; set; }

        //קבל את רשימת הלקוחות וצמצם אותם לפי רשימת סימים
        public List<OnlyDemoUser> GetDemoUsers()
        {
            BlSim.BLOnlyUser BLOnlyUser = new BlSim.BLOnlyUser();
            List<OnlyUser> users = BLOnlyUser.GetUsers();
            List<OnlyDemoUser> Demousers = users.GroupBy(n => n.Unitname)
               .Select(n => new OnlyDemoUser
               {
                   NameUnit = n.Key,
                   NumOfSim = n.Count()
               }
               )
               .OrderBy(n => n.NameUnit).ToList();
            return Demousers;
        }

        //החזר את רשימת הסימים של יחידה מסויימת
        public List<Sim> GetOnlySimsUsers(string Filter)
        {
            BlSim.BLAllData bLAllData = new BlSim.BLAllData();
            List<Sim> sims = bLAllData.GetAllData().FindAll(i => i.Unitname == Filter).ToList();
            return sims;
        }

        //חפש לקוח ספציפי
        public List<OnlyDemoUser> ShrchUser(string Filter)
        {
            List<OnlyDemoUser> demoUsers = GetDemoUsers().FindAll(i => i.NameUnit.Contains(Filter)).ToList();
            return demoUsers;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;
using DalSim;

namespace BlSim
{
    public class BLOnlyUser
    {
        //שימוש במחלקת DAL
        private DalOnlyUser dalonlyUser = new DalOnlyUser();

        // קבל כל נתוני המשתמשים/ יחידות
        public List<OnlyUser> GetUsers()
        {
            List<OnlyUser> users = dalonlyUser.GetUsers();
            return users;
        }

        //קבל לקוח/ יחידה קונקרהטי
       public OnlyUser GetOnlyUser(int id)
        {
            OnlyUser user = dalonlyUser.GetOnlyUser(id);
            return user;
        }

        // עדכן לקוח מסויים והמרתו לבסיס כל הנתונים
        public void UpDateUser(int id, OnlyUser user)
        {
            DalAllData allData = new DalAllData();
            Sim s = allData.GetOneData(id);
            s.Unitname = user.Unitname;
            allData.UpdateAllData(id, s);
        }

        //חפש לקוח/ יחידה מסויימת
        public List<OnlyUser> SearchUser(string Filter)
        {
            List<OnlyUser> user = dalonlyUser.SearchUser(Filter);
            return user;
        }
    }
}

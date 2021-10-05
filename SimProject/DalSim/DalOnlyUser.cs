using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace DalSim
{
    public class DalOnlyUser
    {
        //שימוש במחלקת EF
        private SimEntities entities = new SimEntities();

        //קבל רשימת כל הלקוחות/ יחידות
        public List<OnlyUser> GetUsers()
        {
            List<OnlyUser> users = entities.OnlyUsers.ToList();
            return users;
        }

        // קבל לקוח/ יחידה
        public OnlyUser GetOnlyUser(int id)
        {
            OnlyUser user = GetUsers().FindAll(u => u.Sid == id).Single();
            return user;
        }

        //חפש לקוח/ יחידה מסויימת
        public List<OnlyUser> SearchUser(string Filter)
        {
            List<OnlyUser> user = GetUsers().FindAll(i => i.Unitname.Contains(Filter)).ToList();
            return user;
        }
    }
}

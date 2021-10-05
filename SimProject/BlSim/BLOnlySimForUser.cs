using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlSim
{
    public class BLOnlySimForUser
    {
        //שימוש במחלקת EF
        private DalSim.DALOnliSimForUser forUser = new DalSim.DALOnliSimForUser();

        //קבל כל רשמית הסימים ללקוח מסויים
        public List<OnlySim> GetSims(string userName)
        {

            List<OnlySim> onlySims = forUser.GetSims(userName);
            return onlySims;
        }

        //קבל נתון סים ללקוח קונקרהטי
        public OnlySim GetOnlySim(int id, string username)
        {
            OnlySim onlySim = forUser.GetOnlySim(id, username);
            return onlySim;
        }

        //בצע חיפוש לסים ללקוח מסויים
        public List<OnlySim> SearceSim(string username, string Filter)
        {
            List<OnlySim> s = forUser.SearceSim(username, Filter);
            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace BlSim
{
    public class BlViewUser
    {
        //שימוש במחלקת DAL
        private DalSim.DalViewUser viewUser = new DalSim.DalViewUser();

        //קבלת כל חוקי המשתמשים באתר
        public string[] GetRoleForUser(string userName)
        {
            string[] roles = viewUser.GetRoleForUser(userName);
            return roles;
        }

        //בדיקה חוקי משתמש
        public bool IsInRole(string name,string role)
        {
            return viewUser.IsInRole(name, role);
        }

        //קבלת כל המשתמשים באתר
        public List<Login> GetLogins()
        {
            List<Login> logins = viewUser.GetLogins();
            return logins;
        }

        //בדיקה כניסה לאתר
        public bool IsValid(string username,string password)
        {
            return viewUser.IsValid(username, password);
        }

        //קבלת משתשמש ספציפי
        public Login GetLogin(int id)
        {
            Login login = viewUser.GetLogin(id);
            return login;
        }

        //יצירת משתמש באתר
        public void CreateLogin(Login login)
        {
            viewUser.CreateLogin(login);
        }

        //עדכון פרטי משתמש באתר
        public void UpdateLogin(int id, Login login)
        {
            viewUser.UpdateLogin(id, login);
        }

        //מחיקת משתמש
        public void DeleteLogin(int id, Login login)
        {
            viewUser.DeleteLogin(id, login);
        }

        //חיפוש משתמש מסויים
        public List<Login> SharchLogin(string filter)
        {
            List<Login> logins = viewUser.SharchLogin(filter);
            return logins;

        }
    }
}

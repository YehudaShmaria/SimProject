using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolSim;

namespace DalSim
{
    public class DalViewUser
    {
        //קבלת כל חוקי המשתמשים של האתר
        public string[] GetRoleForUser(string userName)
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                string[] roles = (from i in entities.Logins
                                  where i.UserName == userName
                                  select i.RoleName).ToArray();

                return roles;
            }
        }

        //בדיקה באיזה חוק נמצא המשתמש
        public bool IsInRole(string name, string role)
        {
            using (SimEntities entities = new SimEntities())
            {
                return entities.Logins.Any(i => i.UserName == name && i.RoleName == role);
            }
        }

        //קבלת כל המשתמשים של האתר
        public List<Login> GetLogins()
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                List<Login> logins = entities.Logins.ToList();
                return logins;
            }
        }

        //בדיקת כניסה לאתר
        public bool IsValid(string username, string password)
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                return entities.Users.Any(i => i.UserName == username && i.Password == password);
            }       
        }

        //קבלת משתמש ספציפי
        public Login GetLogin(int id)
        {
            Login login = GetLogins().Find(i => i.Id == id);
            return login;
        }

        //יצירת משתמש חדש
        public void CreateLogin(Login login)
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                Role role = entities.Roles.FirstOrDefault(i => i.RoleName == login.RoleName);
                entities.Users.Add(new User { UserName = login.UserName, Password = login.Password, Role = role });
                entities.SaveChanges();
                     
            }
        }

        //חיפוש משתמש ספציפי
        public List<Login> SharchLogin(string filter)
        {
            List <Login> logins = GetLogins().FindAll(i => i.UserName == filter).ToList();
            return logins; 
        }

        //מחיקת משתמש ספציפי
        public void DeleteLogin(int id, Login login)
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                User u = entities.Users.FirstOrDefault(i => i.Id == id);
                entities.Users.Remove(u);
                entities.SaveChanges();
            }
        }

        //עדכון פרטי משתמש
        public void UpdateLogin(int id, Login login)
        {
            using (ProtocolSim.SimEntities entities = new SimEntities())
            {
                Role role = entities.Roles.FirstOrDefault(i => i.RoleName == login.RoleName);
                User u = entities.Users.FirstOrDefault(i => i.Id == id);
                User user = new User { Id = id, UserName = login.UserName, Password = login.Password, RoleId = role.RoleId};
                entities.Entry<User>(u).CurrentValues.SetValues(user);
                entities.SaveChanges();
            }
        }
    }
}

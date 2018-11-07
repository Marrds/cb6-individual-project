using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectRev3
{
    class LoggerManager
    {
        //  klasi logger  gia logging sto db
      
        public void LogUser(string Username)
        {
            Logger log = new Logger() {LoggedUser=Username,LoggerTime=DateTime.Now };
            using (AppContext db = new AppContext())
            {
                db.Logger.Add(log);
                 
                db.SaveChanges();
            }
            
        }
    }
}

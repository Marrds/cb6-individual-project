using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    class UserMatchup
    {
        private List<User> users = new List<User>();
        // mia klasi pou na koitaei an to username yparxei sthn db
        public bool UsernameMatch(string Username)
        {   
            //perno tous users apo to db kai tous vazo se mia lista 
            using (var db = new AppContext())
            {
                users=db.User.ToList();
            }

            foreach (var user in users)
            {
                if (user.UserName==Username)
                {
                   
                    return true;
                }
            }
            return false;
        
        }
        // mia klasi pou na koitaei an to password yparxei sthn db
        public bool PasswordMatch(string Username,string Password)
        {


            using (var db = new AppContext())
            {
                users = db.User.ToList();
            }

            foreach (var user in users)
            {
                if (user.UserName == Username&& user.Password==Password)
                {
                    StaticProperties.LoggedUserId = user.Id;
                    StaticProperties.LoggedUserName = user.UserName;
                    Console.WriteLine(user.Id + " " + user.UserName);
                    return true;
                }
            }
            return false;

            
        }




    }
}

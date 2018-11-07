using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
   public class UserManager
    {
        private List<User> users = new List<User>();
        //prostheei sto db ena neo user
        public User CreateUser(string Username, string Password)
        {
            User user = new User() { Password = Password, UserName = Username,LevelOfAccess=0 };
            using (AppContext db = new AppContext())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
            return user;
        }
        //epistrefei ena list me olous tous users
        public List<User> GetAllUsers()
        {
            List<User> users;
            using (var db = new AppContext())
            {
                users = db.User.ToList();
            }
            return users;



        }
        // tha epistrefei ena user name simfona me to id
        public string FindUsernameByUserId(int userId)
        {
            List<User> messages = new List<User>();
            string Name=null;
            User mes = new User();
            using (AppContext db = new AppContext())
            {
                messages = db.User.Where(p => p.Id == userId).ToList();

            }
       
            foreach (var item in messages)
            {
                if (item.Id==userId)
                {
                     Name = item.UserName.ToString();
                }
            }
            return Name;
        }
        //deletes a user by userId
        public void DeleteAUserByUserId(int UserId)
        {
            using (AppContext db = new AppContext())
            {

                var k = db.User.Find(UserId);
                if (k != null)
                {
                    db.Entry(k).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }

        }

        //edo allazo level off acces gia kapoion
        public void UpdateAUserLevelOfAccessByUserId(int UserId,int NewLevelOfAccess)
        {
            using (AppContext db = new AppContext())
            {
               

                var k = db.User.Find(UserId);
                if (k != null)
                {
                    k.LevelOfAccess = NewLevelOfAccess;
                    db.SaveChanges();
                }
            }

        }

        //edo chekarei to lvl off access kai epistrefei se int tin timi tou
        public int CheckLvLOffAccess(string Username)
        {
            int AccessLevel=0;
            //perno tous users apo to db kai tous vazo se mia lista 
            using (var db = new AppContext())
            {
                users = db.User.ToList();
            }

            foreach (var user in users)
            {
                if (user.UserName == Username)
                {

                    return user.LevelOfAccess;
                }
            }

            return AccessLevel;


        }


    }
}

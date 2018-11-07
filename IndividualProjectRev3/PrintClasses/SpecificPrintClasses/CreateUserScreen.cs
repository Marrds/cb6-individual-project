using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IndividualProjectRev3
{
    public class Createuser
    {



        public void TakeUsers(List<User> User)
        {
            List<User> _list = new List<User>();
            User user = new User();
            UserManager u = new UserManager();
            _list = u.GetAllUsers();
            Console.Write("Give me a Username: ");
            string NewUser = Console.ReadLine();
            //tsekaro an to username einai keno i ligotero apo 3 xaraktires
            while (true)
            {


                if (NewUser != null && NewUser.Count() < 4)
                {
                    MessageBox.Show("Username must not be null or less than three charachters");
                    Console.Write("Give me a Username: ");
                    NewUser = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            var exsusr = false;
            // string exist = _list.Where(p => p.UserName == NewUser).ToString();
            while (true)
            {
                exsusr = _list.Exists(p => p.UserName == NewUser);

                if (exsusr == false)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This username allready exists");
                    NewUser = Console.ReadLine();
                }
            }


            Console.Write("Give me a Password: ");
            user.UserName = NewUser;
            user.Password = Console.ReadLine();
            //  pernaei to username kai to password sto db
            UserManager userNew = new UserManager();
            userNew.CreateUser(user.UserName, user.Password);
            _list = userNew.GetAllUsers();
            //foreach (var item in _list)
            //{
            //    Console.WriteLine(item.Id+" "+item.UserName);
            //}


            User = _list;


        }
    }
}

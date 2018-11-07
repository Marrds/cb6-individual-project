using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectRev3
{
    class UsePassScreen
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public void UsePass(List<User> User)
        {
            
           // Users user = new Users();

            Console.WriteLine("Username: ");
             Username= Console.ReadLine();           
            //Console.WriteLine("Password: ");
            //Password = Console.ReadLine();

            // TODO: Create a class user match
            UserMatchup match = new UserMatchup();
           bool UserMatchOk= match.UsernameMatch(Username);
            //an to password den iparxei
            if (!UserMatchOk)
            {
                Console.WriteLine("Not valid username");
            }
            else if(UserMatchOk)
            {
                Console.WriteLine(Username);
                Console.Write("Password: ");
                Password = Console.ReadLine();
                bool PassMatchOk = match.PasswordMatch(Username, Password);
                //lathos kodikos
                if (!PassMatchOk)
                {
                    Console.WriteLine("The password is wrong ");

                }
                else if(PassMatchOk)
                {
                    Console.WriteLine("The password is right ");
                    //TODO: kane klasi logger  gia logging sto db
                    //TODO:  loggare tin torini ora kai to username 
                   //TODO: ftiakse tin klasi UserFirstSCreen4


                }

            }
            




        }

    }
}

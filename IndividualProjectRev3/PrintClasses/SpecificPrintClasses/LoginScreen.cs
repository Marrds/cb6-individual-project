using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    public class LoginScreen
    {

        public void GotoLoginScreen()
        {
            Console.Write("Username:");
            string user = Console.ReadLine();
            
            //ftiakse mia klasi gia to pass kai mia gia to user matchup
            UserMatchup userMatchup = new UserMatchup();
            bool usermatch=userMatchup.UsernameMatch(user);
            Console.WriteLine(" username is "+ usermatch);
          
            
            if (!usermatch)
            {
                Console.WriteLine("Not valid username");
            }
            else if (usermatch)
            {
                Console.WriteLine(user);
                Console.Write("Password: ");
               string pass = Console.ReadLine();
                bool passmatch = userMatchup.PasswordMatch(user, pass);
                Console.WriteLine("password is " + passmatch);
               
                if (!passmatch) //lathos kodikos
                {
                    Console.WriteLine("The password is wrong ");            //TODO: asterakia sto pass

                }
                else if (passmatch) //sostos kodikos
                {
                    Console.WriteLine("The password is right ");
                    
                    // loggaro tin torini ora kai to username 
                    LoggerManager log = new LoggerManager();
                    
                    log.LogUser(user);
                    

                    //List<User> users = new List<User>();
                    UserManager userManager = new UserManager();
                    //users= userManager.GetAllUsers();
                    int AccesLvL=userManager.CheckLvLOffAccess(user);
                    //kai na kaleso tin parakato klasi edo

                    if (AccesLvL == 0)//simple user
                    {

                        UserFirstScreen s = new UserFirstScreen();
                        s.PrintFirstScreen();
                    }
                    else if (AccesLvL == 1)
                    {
                        UserWithAccessLvL1.PrintAdminLvL1FirstScreen();

                    }
                    else if (AccesLvL == 2)
                    {
                        UserWithAccessLvL2.PrintAdminLvL2FirstScreen();
                    }
                    else if (AccesLvL == 3)
                    {
                        UserWithAccessLvL3.PrintAdminLvL3FirstScreen();
                    }
                    else if (AccesLvL==4)//Admin
                    {
                        AdminScreen.PrintAdminFirstScreen();
                        
                      

                    }
                  




                   
                  


                }
               

            }

        }
    }
}

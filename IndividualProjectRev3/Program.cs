using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
            {
                int Menuchoice;
                List<User> Users = new List<User>();
                UserManager Manager = new UserManager();
                //edo perno apo to db olous tous users se mia lista 
                Users = Manager.GetAllUsers();
                //Console.WriteLine("1.Login");
                //Console.WriteLine("2.Create new user");
                //Console.WriteLine("3.Exit");
                //Menuchoice = Convert.ToInt32(Console.ReadLine());
                List<string> MenuList = new List<string>() {"Login","Create new user","Exit"};
                PrintsForMenuScreen s = new PrintsForMenuScreen(MenuList);
                Menuchoice=s.ArrowsForFirstScreen(MenuList);
             
                if (Menuchoice == 1)
                {
                    
                    LoginScreen Login = new LoginScreen();
                    Login.GotoLoginScreen();

                }
                else if (Menuchoice == 2)
                {
                    Createuser user = new Createuser();
                    user.TakeUsers(Users);
                    //foreach (var User in Users)
                    //{
                    //    Console.WriteLine(User.UserName + " " + User.Password);
                    //}
                    
                    //edo emfanizo olous tous users apo to db
                    
                    //foreach (var userobject in Users)
                    //{
                    //    Console.WriteLine(userobject.Id+" "+ userobject.UserName);
                    //}

                }
                else if (Menuchoice == 3)
                {
                    Environment.Exit(0);
                }
            }
            

        }
    }
}

//TODO:ftiakse kati me email
//using System.Net.Mail;

//...

//MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
//SmtpClient client = new SmtpClient();
//client.Port = 25;
//client.DeliveryMethod = SmtpDeliveryMethod.Network;
//client.UseDefaultCredentials = false;
//client.Host = "smtp.gmail.com";
//mail.Subject = "this is a test email.";
//mail.Body = "this is my test email body";
//client.Send(mail);
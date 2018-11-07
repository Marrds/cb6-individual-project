using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    public class UserFirstScreen
    {

        public void PrintFirstScreen()
        {
            int MenuChoice=0;
            while (MenuChoice!=4)
            {


                List<User> _users = new List<User>();
                List<Message> MyMessageList = new List<Message>();
                UserManager _listOfAllUsers = new UserManager();
               // Console.Clear();
                //Console.WriteLine("1.View all users");
                //Console.WriteLine("2.Read messages");
                //Console.WriteLine("3.Send message");
                //Console.WriteLine("4.Logout");
                //MenuChoice = Convert.ToInt32(Console.ReadLine());
                List<string> MenuList = new List<string>() { "View all users", "Read messages", "Send message", "Logout" };
                PrintsForMenuScreen l = new PrintsForMenuScreen(MenuList);
                MenuChoice  = l.ArrowsForFirstScreen(MenuList);
                switch (MenuChoice)
                {
                    case 1:
                        //Console.Clear();
                        //PrintLogo.MessagemyWord();
                        _users = _listOfAllUsers.GetAllUsers();
                        
                       // List<string> UsersList = new List<string>() { "View all users", "Read messages", "Send message", "Logout" };
                        PrintsForMenuScreen k = new PrintsForMenuScreen(_users);
                        k.ArrowsForFirstScreen(_users);
                        //foreach (var user in _users)
                        //{
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.WriteLine(user.Id + "." + user.UserName);
                        //}
                        break;
                    case 2:
                        //Read messages
                        //Console.Clear();
                        //PrintLogo.MessagemyWord();
                        
                        MessageManager mes = new MessageManager();
                        MyMessageList= mes.FindMessagesByUserId(StaticProperties.LoggedUserId).ToList();
                        if (MyMessageList.Count()==0)
                        {
                            MessageBox.Show("You dont have any messages");
                            Console.WriteLine("You dont have any messages");                     
                        }
                        else
                        {
                            //Console.WriteLine("You have"+MyMessageList.Count()+" messages");
                            
                            PrintsForMenuScreen o = new PrintsForMenuScreen(MyMessageList);
                            o.ArrowsForFirstScreen(MyMessageList);
                            //foreach (var mess in MyMessageList)
                            //{
                            //   Console.WriteLine(mess.Sender);
                            //   Console.WriteLine(mess.Text);
                            //}

                        }

                        //prepei na do an exo minimata pou na aforoun to diko pou id (foreing key gia tin lista me ta minimata) kai na emfaniso mia lista apo auta 
                        break;
                    case 3:
                        Console.Clear();
                        PrintLogo.MessagemyWord();
                        Console.Clear();
                        UserManager Receiveuser = new UserManager();

                        List<User> listofusers = new List<User>(Receiveuser.GetAllUsers());
                
                        PrintsForMenuScreen m = new PrintsForMenuScreen(listofusers);
                        int ReceiverId= m.ArrowsForFirstScreen(listofusers);   
                        //foreach (var user in listofusers)                            
                        //{
                        //    Console.WriteLine(user.Id + " " + user.UserName);
                        //}
                        
                        //Console.WriteLine("Please select the id of the user you want to send the messsage");
                       // int ReceiverId=Convert.ToInt32( Console.ReadLine());
                        Console.WriteLine("Type your message and press enter");
                        string text = Console.ReadLine();
                        MessageManager message = new MessageManager();
                        message.MessageToDb(listofusers[ReceiverId-1].Id, text, StaticProperties.LoggedUserId);

                        MessageFileLogger log = new MessageFileLogger();
                        log.LogAMessage(StaticProperties.LoggedUserName, listofusers[ReceiverId - 1].UserName, DateTime.Now, text);
                        // kano add stin lista ena minima pros ton xrhsth me id tade
                        break;
                   


                }
            }
        }


    }
}

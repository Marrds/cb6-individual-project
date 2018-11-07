using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
  
	public static class UserWithAccessLvL2
    {
    
        public static void PrintAdminLvL2FirstScreen()
        {
      

            int MenuChoice = 0;
            while (MenuChoice != 6)
            {
                List<User> _users = new List<User>();
                List<Message> MyMessageList = new List<Message>();
                UserManager _listOfAllUsers = new UserManager();
                List<string> MenuList = new List<string>() { "View all users", "Read messages", "Send message", "Read all messages", "Edit a massage", "Logout" };
                PrintsForMenuScreen l = new PrintsForMenuScreen(MenuList);
                MenuChoice = l.ArrowsForFirstScreen(MenuList);

                switch (MenuChoice)
                {
                    case 1:
                        _users = _listOfAllUsers.GetAllUsers();
                        PrintsForMenuScreen k = new PrintsForMenuScreen(_users);
                        k.ArrowsForFirstScreen(_users);
                        break;
                    case 2:
                        MessageManager mes = new MessageManager();
                        MyMessageList = mes.FindMessagesByUserId(StaticProperties.LoggedUserId).ToList();
                        if (MyMessageList.Count() == 0)
                        {
                            MessageBox.Show("You dont have any messages");
                            Console.WriteLine("You dont have any messages");
                        }
                        else
                        {
                            PrintsForMenuScreen z = new PrintsForMenuScreen(MyMessageList);
                            z.ArrowsForFirstScreen(MyMessageList);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        PrintLogo.MessagemyWord();
                        Console.Clear();
                        UserManager Receiveuser = new UserManager();
                        List<User> listofusers = new List<User>(Receiveuser.GetAllUsers());
                        PrintsForMenuScreen m = new PrintsForMenuScreen(listofusers);
                        int ReceiverId = m.ArrowsForFirstScreen(listofusers);
                        Console.WriteLine("Type your message and press enter");
                        string text = Console.ReadLine();
                        MessageManager message = new MessageManager();
                        message.MessageToDb(listofusers[ReceiverId - 1].Id, text, StaticProperties.LoggedUserId);
                        MessageFileLogger log = new MessageFileLogger();
                        log.LogAMessage(StaticProperties.LoggedUserName, listofusers[ReceiverId - 1].UserName, DateTime.Now, text);
                        break;

                    case 4:
                        //read all messsages
                        Console.Clear();
                        PrintLogo.MessagemyWord();
                        Console.Clear();
                        MessageManager ReadAll = new MessageManager();
                        List<Message> listofmessages = new List<Message>();
                        listofmessages = ReadAll.GetAllMessages();
                        PrintsForMenuScreen AllMessages = new PrintsForMenuScreen(listofmessages);
                        AllMessages.ArrowsForFirstScreen(listofmessages);
                        break;
                    case 5:
                        //Edit a message
                        MessageManager ForEdit = new MessageManager();
                        List<Message> AllMessagesInaList = ForEdit.GetAllMessages();
                        PrintsForMenuScreen ChooseAMessage = new PrintsForMenuScreen(AllMessagesInaList);
                        int MessageIDForTextChange = ChooseAMessage.ArrowsForFirstScreen(AllMessagesInaList);
                        ForEdit.EditAMessageByMessageId(AllMessagesInaList[MessageIDForTextChange - 1].Id);
                        break;
          
                   
                }
            }
        }
    }
    
}

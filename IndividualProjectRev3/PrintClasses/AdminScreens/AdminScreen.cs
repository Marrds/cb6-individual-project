using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IndividualProjectRev3
{
    public static class AdminScreen
    {


        public static void PrintAdminFirstScreen()
        {


            int MenuChoice = 0;
            while (MenuChoice != 10)
            {
                List<User> _users = new List<User>();
                List<Message> MyMessageList = new List<Message>();
                UserManager _listOfAllUsers = new UserManager();
                List<string> MenuList = new List<string>() { "View all users", "Read messages", "Send message", "Read all messages", "Edit a message", "Delete a massage", "Set a new admin", "Update a user", "Delete a user", "Logout" };
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
                    case 6:
                        //Delete a massage
                        MessageManager ForDelete = new MessageManager();
                        List<Message> AllMessagesInAList = ForDelete.GetAllMessages();
                        PrintsForMenuScreen ChooseaMessage = new PrintsForMenuScreen(AllMessagesInAList);
                        int MessageIDForDelete = ChooseaMessage.ArrowsForFirstScreen(AllMessagesInAList);
                        ForDelete.DeleteAMessageByMessageId(AllMessagesInAList[MessageIDForDelete - 1].Id);
                        break;
                    case 7:
                        //Set Level of Access
                        UserManager userManager = new UserManager();
                        List<User> AllUsers = userManager.GetAllUsers();
                        PrintsForMenuScreen ChooseAUSer = new PrintsForMenuScreen(AllUsers);
                        int UserIDForAccessChange = ChooseAUSer.ArrowsForFirstScreen(AllUsers);
                        List<string> AccessLevels = new List<string>() { "0.SimpleUser Access", "1.Lvl 1 admin(Can view all messages)", "2.Lvl 2 admin(Can view and edit all messages)", "3.Lvl 3 admin(Can view , edit and delete all messages) ", "4" };
                        PrintsForMenuScreen ChooseAnAccessLvl = new PrintsForMenuScreen(AllUsers);
                        int AccessLvLForAccChange = ChooseAnAccessLvl.ArrowsForFirstScreen(AccessLevels);
                        _users = _listOfAllUsers.GetAllUsers();
                        userManager.UpdateAUserLevelOfAccessByUserId(_users[UserIDForAccessChange - 1].Id, AccessLvLForAccChange - 1);
                        break;
                    case 8:
                        //Update a user
                        PrintsForMenuScreen x = new PrintsForMenuScreen(_users);
                        int UserChoiceForUpdate = x.ArrowsForFirstScreen(_users);
                        UserManager forupd = new UserManager();
                        break;
                    case 9:
                         //Delete a user
                        _users = _listOfAllUsers.GetAllUsers();
                        PrintsForMenuScreen o = new PrintsForMenuScreen(_users);
                        int UserChoiceForDelete = o.ArrowsForFirstScreen(_users);
                        UserManager fordel = new UserManager();
                        if (StaticProperties.LoggedUserName==_users[UserChoiceForDelete-1].UserName)
                        {
                            MessageBox.Show("Vre xazouli pas na diagrapseis ton eauto sou");
                        }
                        else
                        {
                            fordel.DeleteAUserByUserId(_users[UserChoiceForDelete - 1].Id);
                        }                       
                        break;                    
                }
            }

        }
    }
}

using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    public class PrintsForMenuScreen
    {

        //  Sort list by name press 1 by age press 2 by phone press 3
        public int MaxMenuChoises;
        //string Already = "Order by Name ";
        //string SingUp = ("Order by Age");
        //string Exit = ("Order by Phone");
        List<string> mylistOfUsers = new List<string>();//this list has the menu properties that will saw up
        List<string> mylistOfMessages = new List<string>();

        public PrintsForMenuScreen(List<string> MenuList)
        {
            mylistOfUsers = MenuList;
        }

        public PrintsForMenuScreen(List<User> MenuList)
        {
            foreach (var item in MenuList)
            {
                mylistOfUsers.Add(item.Id +" "+ item.UserName);
            }
          // mylist = MenuList;
        }

        public PrintsForMenuScreen(List<Message> MenuList)
        {
            UserManager userManager = new UserManager();
            
            foreach (var item in MenuList)
            {
                mylistOfUsers.Add("Message from "+ item.SenderName  +" at " + item.DateAndTime+ " to "+ userManager.FindUsernameByUserId(item.ReceiverId).ToString() + "\n " + item.Text);
            }
            // mylist = MenuList;
        }

        public void PrintsFor(int Menuchoice)
        {
            // int setempNo = (int)ConsoleColor.Blue;
            int WhiteNo = 15;
            int BlueNo = 9;

            Console.BackgroundColor = (ConsoleColor)BlueNo;
            Console.Clear();
            PrintLogo.MessagemyWord();
            int ConsoleColor = BlueNo;
            for (int i = 0; i <= mylistOfUsers.Count()-1; i++)
            {
                if (i + 1 == Menuchoice)
                    ConsoleColor = WhiteNo;
                else
                    ConsoleColor = BlueNo;

                    Console.BackgroundColor = (ConsoleColor)ConsoleColor;
                    Console.Write(mylistOfUsers[i].DrawInConsoleBox());              
            }
        }

        public int ArrowsForFirstScreen(List<string> MenuList)
        {
            MaxMenuChoises = MenuList.Count();
            ConsoleKeyInfo keyinfo;
            PrintsForMenuScreen p = new PrintsForMenuScreen(MenuList);
            int MenuLevel = 1;
            p.PrintsFor(MenuLevel);

            do
            {
                // p.PrintsFor(MenuLevel);
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow && MenuLevel == MaxMenuChoises)
                {
                    MenuLevel = 1;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)//&& MenuLevel == 1
                {
                    MenuLevel++;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow && MenuLevel == 1)  // && mylist[2] != "0"
                {
                    MenuLevel = MaxMenuChoises;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)// && MenuLevel == 3
                {
                    MenuLevel--;
                    p.PrintsFor(MenuLevel);
                }
                p.PrintsFor(MenuLevel);              
            } while (keyinfo.Key != ConsoleKey.Enter);


            return MenuLevel;
        }

        public int ArrowsForFirstScreen(List<User> MenuList)
        {
            foreach (var item in MenuList)
            {
                mylistOfUsers.Add(item.Id + " " + item.UserName);
            }
            MaxMenuChoises = MenuList.Count();
            ConsoleKeyInfo keyinfo;
            PrintsForMenuScreen p = new PrintsForMenuScreen(MenuList);
            int MenuLevel = 1;
            p.PrintsFor(MenuLevel);

            do
            {
                // p.PrintsFor(MenuLevel);
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow && MenuLevel == MaxMenuChoises)
                {
                    MenuLevel = 1;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)//&& MenuLevel == 1
                {
                    MenuLevel++;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow && MenuLevel == 1)  // && mylist[2] != "0"
                {
                    MenuLevel = MaxMenuChoises;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)// && MenuLevel == 3
                {
                    MenuLevel--;
                    p.PrintsFor(MenuLevel);
                }
                p.PrintsFor(MenuLevel);
            } while (keyinfo.Key != ConsoleKey.Enter);


            return MenuLevel;
        }

        public int ArrowsForFirstScreen(List<Message> MenuList)
        {
            
            foreach (var item in MenuList)
            {
                
                mylistOfUsers.Add( item.Text + " "+item.SenderId);
            }
            MaxMenuChoises = MenuList.Count();
            ConsoleKeyInfo keyinfo;
            PrintsForMenuScreen p = new PrintsForMenuScreen(MenuList);
            int MenuLevel = 1;
            p.PrintsFor(MenuLevel);

            do
            {
                // p.PrintsFor(MenuLevel);
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow && MenuLevel == MaxMenuChoises)
                {
                    MenuLevel = 1;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)//&& MenuLevel == 1
                {
                    MenuLevel++;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow && MenuLevel == 1)  // && mylist[2] != "0"
                {
                    MenuLevel = MaxMenuChoises;
                    p.PrintsFor(MenuLevel);
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)// && MenuLevel == 3
                {
                    MenuLevel--;
                    p.PrintsFor(MenuLevel);
                }
                p.PrintsFor(MenuLevel);
            } while (keyinfo.Key != ConsoleKey.Enter);


            return MenuLevel;
        }

    }
}


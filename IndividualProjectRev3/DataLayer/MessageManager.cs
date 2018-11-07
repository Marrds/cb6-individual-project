using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    class MessageManager
    {
        // vriskei message simfona me to user id
        public List<Message> FindMessagesByUserId(int userId)
        {
            List<Message> messages = new List<Message>();

            Message mes = new Message();
            using (AppContext db = new AppContext())
            {
                messages = db.Messages.Where(p => p.userId == userId).ToList();

            }
            return messages;
        }
        //delete a message by message id
        public void DeleteAMessageByMessageId (int UserId)
        {
            using (AppContext db = new AppContext())
            {

                var k = db.Messages.Find(UserId);
                if (k != null)
                {
                    db.Entry(k).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }

        }

        //apothikeusei stin vasi ena message
        public void MessageToDb(int receiver, string text, int senderId)
        {
            Message message = new Message() { userId = receiver, Text = text, SenderId = receiver, DateAndTime = DateTime.Now, SenderName = StaticProperties.LoggedUserName, UnRead = true };
            using (AppContext db = new AppContext())
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
        }
        // epistrefei ola ta minimata se morfi listas
        public List<Message> GetAllMessages()
        {
            List<Message> Messages;
            using (var db = new AppContext())
            {
                Messages = db.Messages.ToList();
            }
            return Messages;

        }

        //edo kano edit ena opoiodipote message
        public void EditAMessageByMessageId(int MessageId)
        {
            using (AppContext db = new AppContext())
            {


                var k = db.Messages.Find(MessageId);
                if (k != null)
                {
                    Console.Clear();
                    Console.WriteLine("Old text:");
                    Console.WriteLine(k.Text);
                    Console.WriteLine("Please type above the message you want to get replaced: \n");
                    while (true)
                    {


                        k.Text = Console.ReadLine();
                        if (k.Text.Count() < 250)
                        {
                            break;
                        }
                        Console.WriteLine("Type a message with less than 250 characters");
                        k.Text = Console.ReadLine();
                    }
                    db.SaveChanges();
                }
            }

        }
    }
}

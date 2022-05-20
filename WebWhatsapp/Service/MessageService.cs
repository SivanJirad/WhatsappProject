
using WebWhatsappApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebWhatsappApi.Service
{

    public class MessagePost
    {
        public string Content { get; set; }
    }

    public class MessagesGet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        public Boolean Sent { get; set; }
    }

    public class MessageService
    {
        public List<MessagesGet> getAllMessages(string userId, string contactName)
        {


            using (var db = new WhatsappContext())
            {

                //var a = db.Contacts.FirstOrDefault(x => x.User.UserName == userId && x.ContactUserName == contactName);
                //var contactId = a.Id;
                //return db.Messages.Where(x => x.Contact.Id == contactId).ToList();

                var q = db.Contacts.
                    Where(x => x.User.UserName == userId && x.ContactUserName == contactName).
                    Select(u => u.Messages.
                        Select(v => new MessagesGet
                        {
                            Id = v.Id,
                            Content = v.Content,
                            Created = v.Time,
                            Sent = v.Sent
                        }).ToList()
                    );
                ;
                ;

                var items = q.ToList()[0];
                return items;
            }
        }


        public MessagesGet SpecificMessage(string userId, string contactName, int idMessage)
        {
            List<MessagesGet> list = getAllMessages(userId, contactName);
            MessagesGet m = list.Find(x => x.Id == idMessage);
            return m;
        }



        public void AddToDB(string userId, MessagePost message, string contactName)
        {
            using (var db = new WhatsappContext())
            {
                //var y = db.Users.FirstOrDefault(x => x.UserName == userId);
                //var d = db.Contacts.FirstOrDefault(x => x.ContactUserName == contactName);

                var a = db.Contacts.FirstOrDefault(x => x.User.UserName == userId && x.ContactUserName == contactName);
                Message newMessage = new Message();
                try
                {
                    newMessage.Id = db.Messages.Max(x => x.Id) + 1;

                }
                catch (Exception ex)
                {
                    newMessage.Id = 0;

                }
                newMessage.Time = DateTime.Now;
                newMessage.Sent = true;
                newMessage.Content = message.Content;
                newMessage.Contact = db.Contacts.FirstOrDefault(x => x.User.UserName == userId && x.ContactUserName == contactName);

                db.Messages.Add(newMessage);
                db.SaveChanges();
                
            }
        }



        public void DeleteMessage(int idMessage)
        {
            using (var db = new WhatsappContext())
            {

                Message massage = db.Messages.Find(idMessage);
                if (massage != null)
                {
                    db.Messages.Remove(massage);
                    db.SaveChanges();
                }

            }

        }









        /*
         using (var db = new ItemsContext())
            {
                Rating? item = db.Ratings.Find(ID);
                if (item != null)
                {
                    item.UserName = UserName;
                    item.Rate = rating.Rate;
                    item.Review=rating.Review;
                    item.Time = DateTime.Now;
                    db.SaveChanges();
                }

            }
*/


        public void UpdateMessage(int idMessage, MessagePost Updatemessage)
        {
            using (var db = new WhatsappContext())
            {

                Message? massage = db.Messages.Find(idMessage);
                if (massage != null)
                {
                    massage.Content = Updatemessage.Content;
                    db.SaveChanges();
                }

            }

        }


    }
}



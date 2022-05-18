
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
        public string Id { get; set; }
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        public Boolean Sent { get; set; }

    }

    public class MessageService
    {
        /*
        public List<MessagesGet> getAllMessages(string userId)
        {
            using (var db = new WhatsappContext())
            {
                var q = db.Users.
                    Where(u => u.UserName == userId).    // only if you don't want all elements of Table1 
                    Select(u => new
                    {
                        //UserName = u.UserName,
                        Contact = u.Contacts.
                        Select(v => new ContactsGet
                        {
                            Id = v.ContactUserName,
                            Name = v.ContactNickName,
                            Server = v.Server,
                            Last = "hi",
                            Date = "bi"
                        }).ToList(),


                    });

                var items = q.ToList()[0].Contact;
                return items;
            }
        }
        */
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
                    newMessage.Id = db.Contacts.Max(x => x.Id) + 1;

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

    }
}




using WebWhatsappApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebWhatsappApi.Service
{

    public class ContactToAdd
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
    }


    public class ContactsGet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string Last { get; set; }
        public string LastDate { get; set; }
    }

    public class Update
    {
        public string Name { get; set; }
        public string Server { get; set; }
    }


    public class ContactService
    {


        //public List<User> getAllContacts(string? UserName)
        //{

        //    using (var db = new WhatsappContext())
        //    {
        //        var items = db.Users.Include(x => x.Contacts).ThenInclude( m => m.UserName == UserName);
        //        return (List<User>)items;
        //    }
        //}



        public List<ContactsGet> getAllContacts(string userId)
        {
            using (var db = new WhatsappContext())
            {
                var q = db.Users.
                    Where(u => u.UserName == userId).    // only if you don't want all elements of Table1 
                    Select(u => u.Contacts.
                        Select(v => new ContactsGet
                        {
                            Id = v.ContactUserName,
                            Name = v.ContactNickName,
                            Server = v.Server,
                            Last = "hi",
                            LastDate = "bi"
                        }).ToList()

                    ).ToList();
                var items = q[0];
                return items;
            }
        }



        public Boolean AddToDB(string userId, ContactToAdd contact)
        {
            using (var db = new WhatsappContext())
            {

                //var q = db.Users.Where(u => u.UserName == userId);
                //var q = db.Users.Include(x => x.Contacts.Where(v => v.ContactUserName == contact.ContactUserName)).FirstOrDefaultAsync(u => u.UserName == userId);


                var q = db.Users.
                    Where(u => u.UserName == userId).    // only if you don't want all elements of Table1 
                    Select(u => new
                    {
                        //UserName = u.UserName,
                        Contact = u.Contacts.Where(v => v.ContactUserName == contact.Id).
                        Select(v => new
                        {
                            ContactUserName = v.ContactUserName,
                            ContactNickName = v.ContactNickName
                        }).ToList(),

                    });

                var b = q.ToList()[0].Contact;


                if (b.Count == 0)
                {
                    Contact cont = new Contact();
                    try
                    {
                        cont.Id = db.Contacts.Max(x => x.Id) + 1;

                    }
                    catch (Exception ex)
                    {
                        cont.Id = 0;

                    }
                    cont.ContactUserName = contact.Id;
                    cont.ContactNickName = contact.Name;
                    cont.Server = contact.Server;
                    cont.User = db.Users.FirstOrDefault(x => x.UserName == userId);

                    db.Contacts.Add(cont);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }







        public async Task<Contact> GetAContact(string id, string userId)
        {
            using (var db = new WhatsappContext())
            {
                var q = await db.Users.Where(u => u.UserName == userId).
                Select(user => user.Contacts.ToList()).ToListAsync();
                if (q.Count == 0)
                {
                    return null;
                }

                return q[0].Find(contact => contact.ContactUserName == id);
            }
        }

        public async Task<Boolean> DeleteAContact(string id, string userId)
        {
            using (var db = new WhatsappContext())
            {
                var q = await db.Users.Where(u => u.UserName == userId).
                Select(user => user.Contacts.ToList()).ToListAsync();
                if (q.Count == 0)
                {
                    return false;
                }

                Contact item = q[0].Find(contact => contact.ContactUserName == id);

                if(item!= null)
                {
                    db.Contacts.Remove(item);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }





        public async Task<Boolean> EditAContact(string id, string userId, Update body)
        {
            body.ToString();
            using (var db = new WhatsappContext())
            {
                var q = await db.Users.Where(u => u.UserName == userId).
                Select(user => user.Contacts.ToList()).ToListAsync();
                if (q.Count == 0)
                {
                    return false;
                }

                Contact item = q[0].Find(contact => contact.ContactUserName == id);

                if (item != null)
                {
                    item.Server = body.Server;
                    item.ContactNickName = body.Name;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}

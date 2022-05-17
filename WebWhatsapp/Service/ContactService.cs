
using WebWhatsappApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebWhatsappApi.Service
{

    public class ContactToAdd
    {
        public string Id { get; set; }
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




        public Boolean AddToDB(string userId, ContactToAdd contact)
        {
            using (var db = new WhatsappContext())
            {

                //var q = db.Users.Where(u => u.UserName == userId);
                //var q = db.Users.Include(x => x.Contacts.Where(v => v.ContactUserName == contact.ContactUserName)).FirstOrDefaultAsync(u => u.UserName == userId);

                var q = db.Users.Include(x => x.Contacts.Where(v => v.ContactUserName == contact.Id)).Where(u => u.UserName == userId);

                if (!q.Any())
                {
                    Contact cont = new Contact();
                    cont.Id = db.Contacts.Max(x => x.Id) + 1;
                    cont.ContactUserName = contact.Id;
                    cont.ContactNickName = contact.Name;
                    cont.Server = contact.Server;
                    cont.User = db.Users.FirstOrDefault(x=> x.UserName == userId);

                    db.Contacts.Add(cont);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        
    }
}


using WebWhatsappApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebWhatsappApi.Service
{
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


        public Boolean AddToDB(string userId, Contact contact)
        {
            using (var db = new WhatsappContext())
            {

                //var q = db.Users.Where(u => u.UserName == userId);
                //var q = db.Users.Include(x => x.Contacts.Where(v => v.ContactUserName == contact.ContactUserName)).FirstOrDefaultAsync(u => u.UserName == userId);
                var q = db.Users.Include(x => x.Contacts.Where(v => v.ContactUserName == contact.ContactUserName)).Where(u => u.UserName == userId);

                if (!q.Any())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        
    }
}

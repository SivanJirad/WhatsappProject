
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

        /*
        public Boolean addContact(Contact contact)
        {
            using (var db = new WhatsappContext())
            {
                var q = db.Contacts.Where(u => u.UserName == user.UserName);
                if (!q.Any())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        */
    }
}

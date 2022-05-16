using System.ComponentModel.DataAnnotations;


namespace WebWhatsappApi
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }


        public string ContactName { get; set; }

        public string Server { get; set; }

        public User User { get; set; }


        public IEnumerable<Message> Messages { get; set; }


    }
}

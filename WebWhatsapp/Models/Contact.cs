using System.ComponentModel.DataAnnotations;


namespace WebWhatsappApi
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }


        public string Name { get; set; }

        public string Server { get; set; }


        public string Last { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastDate { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public User User { get; set; }

        public string UserName { get; set; }
    }
}

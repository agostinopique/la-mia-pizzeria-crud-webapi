using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio!")]
        public string Text { get; set; }
        
        public Message(string name, string email, string text)
        {
            int id = 0;
            this.Id = id;
            this.Name = name;
            this.Email = email; 
            this.Text = text;
            id++;
        }

        public Message() { }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace halloween.Model
{
    public class Greetings
    {
        //ADD A UNIQUE IDENTIFIER
        [Key]
        public int ID { get; set; }

        [DisplayName("Your name")]
        [Display(Prompt = "Your name")]
        [Required(ErrorMessage = "Your name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string fromName { get; set; }

        [DisplayName("Your email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Your email is required")]
        public string fromEmail { get; set; }

        [DisplayName("Your friend's name")]
        [Display(Prompt = "Your friend's name")]
        [Required(ErrorMessage = "Your friend's name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string toName { get; set; }

        [DisplayName("Your friend's email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Your friend's email is required")]
        public string toEmail { get; set; }

        [DisplayName("Subject")]
        [Display(Prompt = "Subject")]
        [Required(ErrorMessage = "Subject Required")]
        public string subject { get; set; }

        [DisplayName("Message")]
        [Display(Prompt = "Your message")]
        [Required(ErrorMessage = "Message Required")]
        public string message { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "You must agree to our terms and conditions")]
        public string tandcagree { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createIP { get; set; }

        public string reCaptcha { get; set; }

    }

}

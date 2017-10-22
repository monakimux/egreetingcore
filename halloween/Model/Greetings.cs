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
        [DisplayName("Your name")]
        [Display(Prompt = "Your name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string fromName { get; set; }

        [DisplayName("Your email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Required")]
        public string fromEmail { get; set; }

        [DisplayName("Your friend's name")]
        [Display(Prompt = "Your friend's name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string toName { get; set; }

        [DisplayName("Your friend's email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Subject")]
        [Display(Prompt = "Subject")]
        [Required(ErrorMessage = "Required")]
        public string subject { get; set; }

        [DisplayName("Message")]
        [Display(Prompt = "Your message")]
        [Required(ErrorMessage = "Required")]
        public string message { get; set; }

        [Required(ErrorMessage = "Required")]
        public string tandcagree { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createIP { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {
        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public Greetings bridgeGreetings { get; set; }

        //CONNECT MY DATABASE TO THIS MODEL
        private DB _myDB;
        public PreviewModel(DB myDB)
        {
            _myDB = myDB;
        }

        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgeGreetings = _myDB.Greetings.Find(ID);
            }
        }

        // EMAIL-RELATED
        public string Message { get; set; }
        public IActionResult OnPost(int id = 0)
        {
            if (id > 0)
            {
                bridgeGreetings = _myDB.Greetings.Find(id);

                try
                {
                    // SEND 
                    MailMessage Mailer = new MailMessage();

                    Mailer.To.Add(new MailAddress(bridgeGreetings.toEmail, bridgeGreetings.toName));
                    Mailer.Subject = bridgeGreetings.subject;
                    Mailer.Body = bridgeGreetings.message;
                    Mailer.From = new MailAddress(bridgeGreetings.fromEmail, bridgeGreetings.fromName);

                    Mailer.IsBodyHtml = true;

                    Mailer.Body = "<img src='http://mona.wowoco.org/images/thumbnail.jpg' />"
                        + Mailer.From
                        + "has a greeting for you! Visit http://mona.wowoco.org/read/"
                        + Mailer.ID;

                    using (SmtpClient smtpServer = new SmtpClient())
                    {
                        smtpServer.EnableSsl = false;
                        smtpServer.Host = "smtp18.wowoco.org"; // CHANGE
                        smtpServer.Port = 2525; // CHANGE
                        smtpServer.UseDefaultCredentials = false;
                        smtpServer.Send(Mailer);
                    }

                    // DB-RELATED: ASSIGN SEND INFO TO DATABASE
                    bridgeGreetings.sendDate = DateTime.Now.ToString();
                    bridgeGreetings.sendIP = this.HttpContext.Connection.RemoteIpAddress.ToString();


                    // DB-RELATED: UPDATE RECORD ON THE DATABASE 
                    _myDB.Greetings.Update(bridgeGreetings);
                    _myDB.SaveChanges();


                    return RedirectToPage("complete");

                }
                catch
                {
                    Message = "Error! Your greeting can't be sent.";
                }
            }

            return Page();
        }
    }
}
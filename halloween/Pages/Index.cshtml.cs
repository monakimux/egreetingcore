using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using halloween.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace halloween.Pages
{
    public class IndexModel : PageModel
    {
        // DEFAULT MODE
        public void OnGet()
        {
            isPreviewPage = false;
        }

        // PREVIEW MODE (AFTER SUBMITTING)
        public async Task<IActionResult> OnPost()
        {
            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    //try
                    //{
                    // ADD TO DATABASE
                    _myDB.Greetings.Add(bridgeGreetings);
                    _myDB.SaveChanges();

                    return RedirectToPage("Preview", new { id = bridgeGreetings.ID });
                    //}
                    //catch { }
                }
            }
            else
            {
                ModelState.AddModelError("bridgeGreetings.Recaptcha", "Please prove that you're a human!");
            }

            return Page();
        }

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public Greetings bridgeGreetings { get; set; }

        //CONNECT MY DATABASE TO THIS MODEL
        private DB _myDB;
        public IndexModel(DB myDB)
        {
            _myDB = myDB;
        }


        // TEST IF USER IS LOOKING AT PREVIEW OR FORM
        public bool isPreviewPage { get; set; }

        // RE-CAPTCHA VALIDATION
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    values.Add("secret", "6LeO8zAUAAAAABP2UsvP6fZlS3TlkiVzlwD8XFzX");
                    values.Add("response", response);
                    values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString());

                    var query = new FormUrlEncodedContent(values);


                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }


            return false;
        }


    }
}

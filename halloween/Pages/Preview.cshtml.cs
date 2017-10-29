using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {
        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgeGreetings = _myDB.Greetings.Find(ID);
            }
        }

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public Greetings bridgeGreetings { get; set; }

        //CONNECT MY DATABASE TO THIS MODEL
        private DB _myDB;
        public PreviewModel(DB myDB)
        {
            _myDB = myDB;
        }


    }
}
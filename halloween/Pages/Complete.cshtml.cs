using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class CompleteModel : PageModel
    {
        private object bridgeGreetings;

        public object _myDB { get; private set; }

        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgeGreetings = _myDB.Greetings.Find(ID);
            }
        }
    }
}
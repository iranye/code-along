using LogicSolver.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogicSolver.Web.Pages
{
    public class ContactModel : PageModel
    {
        public string Title { get; set; } = "Contact Me";
        public string Message { get; set; }
        public ContactViewModel Contact { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(ContactViewModel model)
        {
            Message = "Not Implemented";
        }
    }
}

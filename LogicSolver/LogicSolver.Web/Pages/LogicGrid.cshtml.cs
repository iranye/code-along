using LogicSolver.Web.Data.Entities;
using LogicSolver.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogicSolver.Web.Pages
{
    public class LogicGridModel : PageModel
    {
        public string Title { get; set; } = "Logic Solver Grid";
        public string Message { get; set; } = String.Empty;

        [BindProperty]
        public EntityMapperViewModel TypeMapper { get; set; } = new();

        public EntityMapper EntityMapper { get; set; } = default!;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                ClearData();

                EntityMapper = new EntityMapper
                (
                    TypeMapper.EntityMainType,
                    TypeMapper.Entity02Type,
                    TypeMapper.Entity03Type,
                    TypeMapper.Entity04Type
                );

                // EntityMain entityMain = new EntityMain
                // {
                //     Title = TypeMapper,
                //     Entity02Id = 2,
                //     Entity03Id = 3,
                //     Entity04Id = 4
                // };
            }
            else
            {
                Message = "Please fix errors";
            }
        }

        private void ClearData()
        {
            // Contact = new ContactViewModel();
            ModelState.Clear();
        }
    }
}

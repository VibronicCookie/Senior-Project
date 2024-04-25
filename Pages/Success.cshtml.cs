using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Senior_Project.Pages
{
    public class SuccessModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            RedirectToPage("./Index");
        }
    }
}

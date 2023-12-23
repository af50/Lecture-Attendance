using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LectureAttendance.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Type")==null)
            {
                return RedirectToPage("/Login/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

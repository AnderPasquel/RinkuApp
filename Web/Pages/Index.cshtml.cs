using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RinkuApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(SignInManager<IdentityUser> signInManager, ILogger<IndexModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }



        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return Page();
            }
            return LocalRedirect("/Identity/Account/Login");

        }

    }
}
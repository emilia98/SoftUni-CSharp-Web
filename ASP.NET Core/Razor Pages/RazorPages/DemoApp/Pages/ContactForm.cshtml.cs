using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp
{
    public class ContactFormModel : PageModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [Required]
        [BindProperty]
        public string Title { get; set; }

        [Required]
        [BindProperty]
        public string Content { get; set; }

        public string InfoMessage { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                this.InfoMessage = "Thank you for submitting contact form.";

                return Redirect("/");
            }

            return Page();
        }

        public override async Task OnPageHandlerExecutionAsync(
            PageHandlerExecutingContext context, 
            PageHandlerExecutionDelegate next)
        {
            // Before page handler
            await next();
            // Adter page handler
        }
    }
}
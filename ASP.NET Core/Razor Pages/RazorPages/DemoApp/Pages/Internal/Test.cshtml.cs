using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp
{
    public class TestModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public void OnGet()
        {

        }
    }
}
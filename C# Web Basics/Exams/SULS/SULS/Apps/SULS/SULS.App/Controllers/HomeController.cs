using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SULS.App.ViewModels.Home;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }
        
        [HttpGet(Url = "/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            if(!this.IsLoggedIn())
            {
                return this.View();
            }

            var dbproblems = this.problemsService.GetAll();

            var problems = this.problemsService.GetAll().Select(p => new ProblemIndexViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Count = p.Submissions.Count(),
            }).ToList();

            return this.View(problems, "IndexLoggedIn");
        }
    }
}
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Models;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly string homeUrl = "/";

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProblemInputModel input)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            var problem = new Problem
            {
                Name = input.Name,
                Points = input.Points
            };

            this.problemsService.Create(problem);
            return this.Redirect(this.homeUrl);
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            var problem = this.problemsService.GetById(id);

            if (problem == null)
            {
                this.Redirect(this.homeUrl);
            }

            var viewModel = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                Submissions = problem.Submissions.Select(x => new SubmissionViewModel {
                    Username = x.User.Username,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    AchievedResult = x.AchievedResult,
                    MaxPoints = problem.Points,
                    SubmissionId = x.Id
                }).ToArray()
            };

            return this.View(viewModel, "Details");
        }
    }
}

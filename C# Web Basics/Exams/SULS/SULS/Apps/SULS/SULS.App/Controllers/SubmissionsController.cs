using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SULS.App.ViewModels;
using SULS.App.ViewModels.Submissions;
using SULS.Models;
using SULS.Services;
using System;
using System.Collections.Generic;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;
        private readonly string homeUrl = "/";

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            var problem = this.problemsService.GetById(id);

            if (problem == null)
            {
                return this.Redirect(this.homeUrl);
            }

            var inputModel = new SubmissionCreateViewModel
            {
                Name = problem.Name,
                ProblemId = id,
            };

            return this.View(inputModel, "Create");
        }

        [HttpPost]
        public HttpResponse Create(SubmissionCreateInputModel input)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            var problem = this.problemsService.GetById(input.ProblemId);

            if (problem == null)
            {
                return this.Redirect(this.homeUrl);
            }

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Code))
            {
                errors.Add("Code cannot be empty!");
            }

            int codeLength = input.Code.Length;

            if (codeLength < 30 || codeLength > 800)
            {
                errors.Add("Code should be between 30 and 80 characters!");
            }

            if (errors.Count > 0)
            {
                var errorViewModel = new ErrorViewModel
                {
                    Errors = errors
                };
                return this.View(errorViewModel, "Error");
            }

            var currentUser = this.User;
            var problemMaxPoints = problem.Points;
            var rnd = new Random();

            var submission = new Submission
            {
                Code = input.Code,
                ProblemId = input.ProblemId,
                AchievedResult = rnd.Next(0, problemMaxPoints + 1),
                UserId = currentUser.Id,
            };

            this.submissionsService.Create(submission);
            return this.Redirect(this.homeUrl);
        }

        public HttpResponse Delete(string id)
        {
            if(!this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            this.submissionsService.Delete(id);
            return this.Redirect(this.homeUrl);
        }
        
    }
}

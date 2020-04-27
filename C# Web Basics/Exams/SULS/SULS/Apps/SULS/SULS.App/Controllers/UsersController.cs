using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SULS.App.ViewModels.Users;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly string loginUrl = "/Users/Login";
        private readonly string homeUrl = "/";

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId, input.Username, input.Password);
                return this.Redirect("/");
            }

            return this.Redirect(this.loginUrl);
        }

        public HttpResponse Register()
        {
            if (this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsLoggedIn())
            {
                return this.Redirect(this.homeUrl);
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect(this.loginUrl);
        }

        public HttpResponse Logout()
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect(this.loginUrl);
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
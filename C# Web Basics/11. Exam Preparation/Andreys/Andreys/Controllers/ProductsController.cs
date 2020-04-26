using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly string loginUrl = "/Users/Login";
        private readonly string requiredError = "{0} is required!";

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect(this.loginUrl);
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect(this.loginUrl);
            }

            if (string.IsNullOrWhiteSpace(inputModel.Name))
            {
                // return this.Error(string.Format(this.requiredError, "Name"));
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Description))
            {
                // return this.Error(string.Format(this.requiredError, "Description"));
                return this.View();
            }

            if (string.IsNullOrEmpty(inputModel.Price.ToString()))
            {
                // return this.Error(string.Format(this.requiredError, "Price"));
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Category))
            {
                // return this.Error(string.Format(this.requiredError, "Category"));
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Gender))
            {
                // return this.Error(string.Format(this.requiredError, "Gender"));
                return this.View();
            }

            if (inputModel.Name.Length < 4 || inputModel.Name.Length > 20)
            {
                // return this.Error("Product Name should be between 4 and 20 characters!");
                return this.View();
            }

            if (inputModel.Description.Length > 10)
            {
                // return this.Error("Product Description should be max 10 characters long!");
                return this.View();
            }

            var productId = this.productsService.Add(inputModel);

            return this.Redirect($"/Products/Details?id={productId}");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect(this.loginUrl);
            }

            var product = this.productsService.GetById(id);
            // Maybe, it's pointless
            var productViewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Category = product.Category,
                Gender = product.Gender
            };
            return this.View(productViewModel);
        }

        public HttpResponse Delete(int id)
        {
            if(!this.IsUserLoggedIn())
            {
                return this.Redirect(this.loginUrl);
            }

            this.productsService.DeleteById(id);
            return this.Redirect("/");
        }
    }
}

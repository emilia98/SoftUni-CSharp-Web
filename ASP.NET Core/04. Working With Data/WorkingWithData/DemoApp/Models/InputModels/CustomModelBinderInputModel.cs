using DemoApp.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Models.InputModels
{
    public class CustomModelBinderInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ModelBinder(typeof(YearModelBinder))]
        public int Year { get; set; }

        public int[] Years { get; set; }
    }
}

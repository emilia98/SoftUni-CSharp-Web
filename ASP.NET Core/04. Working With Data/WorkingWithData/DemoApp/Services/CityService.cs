using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DemoApp.Services
{
    public class CityService : ICityService
    {
        public IEnumerable<SelectListItem> GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Sofia" },
                new SelectListItem { Value = "2", Text = "Gabrovo" },
                new SelectListItem { Value = "3", Text = "Plovdiv" }
            };
        }
    }
}

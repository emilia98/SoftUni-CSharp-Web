using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DemoApp.Services
{
    public interface ICityService
    {
        IEnumerable<SelectListItem> GetAll();
    }
}

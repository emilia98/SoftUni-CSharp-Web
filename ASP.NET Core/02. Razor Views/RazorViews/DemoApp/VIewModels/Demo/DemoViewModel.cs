using System.Collections.Generic;

namespace DemoApp.ViewModels.Demo
{
    public class DemoViewModel
    {
        public int Year { get; set; }

        public IEnumerable<string> Products { get; set; }

        public string Stringify => string.Join(", ", this.Products);
    }
}

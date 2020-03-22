using System.Collections.Generic;

namespace DemoApp.ViewModels.Data
{
    public class IndexViewModel
    {
        public string Message { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Names { get; set; }

        public string AllNames => string.Join(", ", Names);
    }
}

using System.Collections.Generic;

namespace DemoApp.Services
{
    public interface IYearsService
    {
        IEnumerable<int> GetLastYears(int count);
    }
}

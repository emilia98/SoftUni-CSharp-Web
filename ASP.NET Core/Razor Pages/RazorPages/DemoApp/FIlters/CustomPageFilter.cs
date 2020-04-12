using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DemoApp.FIlters
{
    public class CustomPageFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            // Before page handler
            await next();
            // After page handler
        }

        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
    }
}

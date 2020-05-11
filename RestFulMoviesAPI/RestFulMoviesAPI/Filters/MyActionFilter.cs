using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace RestFulMoviesAPI.Filters
{
    public class MyActionFilter : IActionFilter
    {
        private readonly ILogger<MyActionFilter> logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.logger = logger;
        }
        //before action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
            logger.LogWarning("OnActionExecuting");
        }
        //after action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
            logger.LogWarning("OnActionExecuted");
        }

        
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiAutores.filters {
    public class MyFilterAction : IActionFilter {
        private readonly ILogger<MyFilterAction> logger;

        public MyFilterAction( ILogger<MyFilterAction> logger) {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context) {
            logger.LogInformation(" después de ejecutar acción");
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            logger.LogInformation(" antes de ejecutar acción");
        }
    }
}
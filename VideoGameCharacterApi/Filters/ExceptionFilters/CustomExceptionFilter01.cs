using Microsoft.AspNetCore.Mvc.Filters;

namespace VideoGameCharacterApi.Filters.ExceptionFilters
{
    public class CustomExceptionFilter01: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            // Log the exception details here if needed
            context.ExceptionHandled = true; // Mark the exception as handled
            context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(new { error = context.Exception.Message })
            {
                StatusCode = 500 // Internal Server Error
            };
        }
    }
}

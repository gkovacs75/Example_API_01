using Microsoft.AspNetCore.Mvc.Filters;

namespace VideoGameCharacterApi.Filters.ActionFilters
{
    public class CustomActionFilter01 : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var actionName = context.ActionArguments["Key"];

            context.ModelState.AddModelError("Key","Error Message");

            context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(context.ModelState);
        }
    }
}

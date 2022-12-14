using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HRTask.Filters
{
    public class AccessFilter:ActionFilterAttribute
    {
        private readonly string _Name;

        public AccessFilter(string name)
        {
            _Name = name;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var val= context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == _Name);
            if (val == null|| !Convert.ToBoolean(val.Value))
            {
                context.Result = new ContentResult() { Content = "AccessDenied" };
            }

            base.OnActionExecuting(context);
        }
    }
}

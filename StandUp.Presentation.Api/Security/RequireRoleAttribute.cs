using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StandUp.Presentation.Api.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class RequireRoleAttribute : Attribute, IAsyncActionFilter
{
    private readonly string[] _roles;

    public RequireRoleAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var role = context.HttpContext.Request.Headers["X-User-Role"].FirstOrDefault();
        if (string.IsNullOrWhiteSpace(role) || !_roles.Any(x => string.Equals(x, role, StringComparison.OrdinalIgnoreCase)))
        {
            context.Result = new ForbidResult();
            return Task.CompletedTask;
        }

        return next();
    }
}

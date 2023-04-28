using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ProjektNTP.Application.Authorization.Policies;

namespace ProjektNTP.Application.Authorization.Handlers;

public class IsOwnerOrAdminRequirementHandler : AuthorizationHandler<IsOwnerOrAdminRequirement, Domain.Entities.Movie>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsOwnerOrAdminRequirement requirement, Domain.Entities.Movie movie)
    {
        if (requirement.ResourceOperation is IsOwnerOrAdminResourceOperation.Read or IsOwnerOrAdminResourceOperation.Create)
        {
            context.Succeed(requirement);
        }
        else
        {
            var loggedUserId = Guid.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (loggedUserId == movie.AddedById || context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
    
}
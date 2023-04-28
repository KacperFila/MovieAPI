using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ProjektNTP.Application.Authorization.Policies;

namespace ProjektNTP.Application.Authorization.Handlers;

public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Domain.Entities.Movie>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement,
        Domain.Entities.Movie movie)
    {
        if (requirement.ResourceOperation == ResourceOperation.Read ||
            requirement.ResourceOperation == ResourceOperation.Create)
        {
            context.Succeed(requirement);
        }
        else
        {
            var loggedUserId = Guid.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (loggedUserId == movie.AddedById)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}
using Microsoft.AspNetCore.Authorization;

namespace ProjektNTP.Application.Authorization.Policies;

public enum IsOwnerOrAdminResourceOperation
{
    Create,
    Read,
    Update,
    Delete
}
public class IsOwnerOrAdminRequirement : IAuthorizationRequirement
{
    public IsOwnerOrAdminResourceOperation ResourceOperation { get; }

    public IsOwnerOrAdminRequirement(IsOwnerOrAdminResourceOperation resourceOperation)
    {
        ResourceOperation = resourceOperation;
    }
        
}
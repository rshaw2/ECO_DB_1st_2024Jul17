using Microsoft.AspNetCore.Mvc;
using ECODB1st2024Jul17.Helpers.Extensions;

/// <summary>
/// Base class of API controller
/// </summary>
namespace ECODB1st2024Jul17.Helpers
{
    /// <summary>
/// Base class of API controller
/// </summary>
    public class BaseApiController : ControllerBase
    {
        protected Guid UserId { get => HttpContext.User.Identity.GetUserId(); }
        protected Guid TenantId { get => HttpContext.User.Identity.GetTenantId(); }
    }
}
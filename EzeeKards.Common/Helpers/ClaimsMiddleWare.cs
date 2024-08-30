using EzeeKards.Common.Helpers;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EzeeKard.Common.Helpers
{
    public class ClaimsMiddleWare
    {
        private readonly RequestDelegate _next;

        public ClaimsMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context?.User != null && context.User.Identity.IsAuthenticated)
            {
                var idClaim = context.User.Claims.FirstOrDefault(c => c.Type == "AdminId")?.Value
                                ?? context.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

                var id = !string.IsNullOrEmpty(idClaim) ? Guid.Parse(idClaim) : Guid.Empty;


                var userContext = new UserContext
                {
                    Id = id,
                    Name = context.User.FindFirst(ClaimTypes.Name)?.Value,
                    Role = context.User.FindFirst(ClaimTypes.Role)?.Value
                };

                UserContextAccessor.Current = userContext;
            }

            await _next(context);
        }
    }
}
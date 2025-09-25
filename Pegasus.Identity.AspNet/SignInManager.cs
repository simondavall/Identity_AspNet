using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Pegasus.Identity.AspNet;

public class SignInManager<TUser> : Microsoft.AspNetCore.Identity.SignInManager<TUser> where TUser : IdentityUser {
    
    public SignInManager(
        UserManager<TUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<TUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<TUser>> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<TUser> confirmation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation) {
    }

    public override async Task SignInWithClaimsAsync(TUser user, bool isPersistent, IEnumerable<Claim> additionalClaims) {
        List<Claim> claims = [];
        claims.AddRange(additionalClaims);
        claims.Add(new Claim(ClaimTypes.Role, "PegasusUser"));
        await base.SignInWithClaimsAsync(user, isPersistent, claims);
    }
}
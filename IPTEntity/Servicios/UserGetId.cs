using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IPTEntity.Servicios
{
	public class UserGetId : IUserGetId
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<IdentityUser> _userManager;

		public UserGetId(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
		{
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;	
		}

		public string getCurrentUserId()
		{
			ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
			return _userManager.GetUserId(currentUser);
		}
	}
}

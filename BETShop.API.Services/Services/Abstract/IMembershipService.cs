using BETShop.API.Core.Helpers;
using BETShop.API.Models;
using BETShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services.Abstract
{
		public interface IMembershipService
		{
				Task<ApplicationUser> FindByUsername(string user);
				Task<LoginResult> SignIn(UserView loginView);
				Task<bool> CheckEmailExists(string email);
				Task<LoginResult> SignUp(UserView signUpView);
				Task<string> GetCurrentUserId();
		}
}

using BETShop.API.Core.Helpers;
using BETShop.API.Models;
using BETShop.API.Services.Abstract;
using BETShop.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Identity.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BETShop.API.Services
{
		public class MembershipService : IMembershipService
		{
				private readonly UserManager<ApplicationUser> _userManager;
				private readonly SignInManager<ApplicationUser> _signInManager;
				private readonly IHttpContextAccessor _httpContextAccessor;

				public MembershipService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
				{
						_userManager = userManager;
						_signInManager = signInManager;
						_httpContextAccessor = httpContextAccessor;
				}
				public async Task<bool> CheckEmailExists(string email)
				{
						return await _userManager.FindByEmailAsync(email) != null;
				}

				public async Task<ApplicationUser> FindByUsername(string user)
				{
						return await _userManager.FindByEmailAsync(user);
				}

				public async Task<string> GetCurrentUserId()
				{
						var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
						return user.Id;
				}
				public async Task<LoginResult> SignIn(UserView  logInView)
				{
						var user = await _userManager.FindByEmailAsync(logInView.Email);

						if (user == null)
						{
								return new LoginResult() { Succeeded = false, Message = "User not found", User = null };
						}

						var result = await _signInManager.CheckPasswordSignInAsync(user, logInView.Password, false);

	
						if (result.Succeeded)
						{
								return new LoginResult() { Succeeded = result.Succeeded, User = user };
						}
						else
						{
								return new LoginResult() { Succeeded = false, Message = "User not found", User = null };
						}

				}
				public async Task<LoginResult> SignUp(UserView logInView)
				{
						var existingUser = await CheckEmailExists(logInView.Email);
						if (existingUser)
						{
								return new LoginResult() { Message = "Email address is already in use", Succeeded = false, User = null };
						}
						var user = new ApplicationUser
						{
								Email = logInView.Email,
								UserName = logInView.Email
						};
						var result = await _userManager.CreateAsync(user, logInView.Password);
						if (!result.Succeeded)
						{
								return new LoginResult() { User = null, Message= result.Errors.FirstOrDefault().Description, Succeeded = result.Succeeded };
						}
						return new LoginResult() { User = user, Succeeded = true };
				}
		}
}

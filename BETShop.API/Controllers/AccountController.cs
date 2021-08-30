using BETShop.API.Core.Helpers;
using BETShop.API.Infrastructure.Logging;
using BETShop.API.Services.Abstract;
using BETShop.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Controllers
{
		public class AccountController : BaseController
		{
				private readonly IAuthTokenService _authTokenService;
				private readonly IMembershipService _membershipService;
				private readonly ILoggerManager _logger;

				public AccountController(IAuthTokenService authTokenService, IMembershipService membershipService, ILoggerManager logger)
				{
						_authTokenService = authTokenService;
						_membershipService = membershipService;
						_logger = logger;
				}

				[HttpGet("userexists")]
				public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
				{
						return await _membershipService.CheckEmailExists(email);
				}

				[HttpPost("register")]
				public async Task<ActionResult<UserView>> Register(UserView userView)
				{
						try
						{
								var result = await _membershipService.SignUp(userView);
								if (result.Succeeded)
								{
										return new UserView()
										{
												Email = result.User.Email,
												Token = _authTokenService.CreateToken(result.User)
										};
								}
								else
								{

										return BadRequest(result);
								}
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}

				[HttpPost("login")]
				public async Task<ActionResult<UserView>> Login(UserView userView)
				{
						try
						{
								var result = await _membershipService.SignIn(userView);
								if (result.Succeeded)
								{
										return new UserView()
										{
												Email = result.User.Email,
												Token = _authTokenService.CreateToken(result.User)
										};
								}
								else
								{
										return Unauthorized(result);
								}
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return BadRequest(ex);
						}
				}
		}
}

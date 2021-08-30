using BETShop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services.Abstract
{
		public interface IAuthTokenService
		{
				string CreateToken(ApplicationUser user);
		}
}

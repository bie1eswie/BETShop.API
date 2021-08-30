
using BETShop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Core.Helpers
{
		public class LoginResult : BaseResult
		{
				public ApplicationUser User { get; set; }
		}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Services.Abstract
{
		public interface IEmailService
		{
				Task<bool> SendEmailAsync(string email, string subject, string message);
		}
}

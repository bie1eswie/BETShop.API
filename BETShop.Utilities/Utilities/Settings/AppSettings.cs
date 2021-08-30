using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Utilities.Settings
{
		public class AppSettings
		{
				public EmailSettings  EmailSettings { get; set; }
				public string BirthdayWishesEmail { get; set; }
				public string BirthdayWishesSubject { get; set; }
		}
}

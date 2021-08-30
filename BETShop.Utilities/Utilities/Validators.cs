using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BETShop.API.Utilities
{
		public static class Validators
		{
				public static bool ValidatePattern(string pattern, string value)
				{
						return Regex.IsMatch(value, pattern);
				}
		}
}

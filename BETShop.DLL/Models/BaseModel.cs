using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Models
{
		public class BaseModel
		{
				public int Id { get; set; }
				public DateTime? CreatedDate { get; set; }
		}
}

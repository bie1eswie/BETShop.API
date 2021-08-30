using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Models
{
		public class Product : BaseModel
		{
				public string Name { get; set; }
				public decimal Price { get; set; }
				public int Quantity { get; set; }
				public string PictureUrl { get; set; }
		}
}

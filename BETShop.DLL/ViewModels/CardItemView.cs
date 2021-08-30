﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.ViewModels
{
		public class CardItemView
		{
				public string Name { get; set; }
				public decimal Price { get; set; }
				public int Quantity { get; set; }
				public string PictureUrl { get; set; }
				public int ProductId { get; set; }
		}
}

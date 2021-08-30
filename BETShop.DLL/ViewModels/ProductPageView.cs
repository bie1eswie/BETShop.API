using BETShop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.ViewModels
{
		public class ProductPageView
		{
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<ProductView>  Products { get; private set; }

        public ProductPageView(int pageIndex, int pageSize, long count, IEnumerable<ProductView> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Products = data;
        }
    }
}

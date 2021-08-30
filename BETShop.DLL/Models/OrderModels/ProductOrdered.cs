namespace BETShop.API.Models.OrderModels
{
    public class ProductOrdered
    {
        public ProductOrdered()
        {
            
        }
        public ProductOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}
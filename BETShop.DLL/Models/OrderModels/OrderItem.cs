namespace BETShop.API.Models.OrderModels
{
    public class OrderItem : BaseModel
    {
        public OrderItem()
        {
        }

        public OrderItem(decimal price, int quantity,int productID)
        {
            Price = price;
            Quantity = quantity;
            ProductId = productID;
        }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
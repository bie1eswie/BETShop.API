using System.Runtime.Serialization;

namespace BETShop.API.Models.OrderModels
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending, 

        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived, 
        
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}
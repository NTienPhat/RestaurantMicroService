namespace RestaurantWeb.Models
{
    public class CouponDTO
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmmount { get; set; }
        public int MinAmmount { get; set; }
    }
}

using static RestaurantWeb.Utility.SD;

namespace RestaurantWeb.Models
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } 
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}

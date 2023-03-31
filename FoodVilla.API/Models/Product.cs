namespace FoodVilla.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set;}

        public DateTime? CreatedDate { get; set; }

        public string? ProductPicture { get; set; }
    }
}

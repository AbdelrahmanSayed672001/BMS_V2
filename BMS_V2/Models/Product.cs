using System.ComponentModel.DataAnnotations;

namespace BMS_V2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "maximum lenght is 50 please enter a title less than that")]
        public string Title { get; set; } =string.Empty;
        public int Price { get; set; }
        public double Tax { get; set; }
        public double Ads { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }


}

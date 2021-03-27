using System;
using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class BuyItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Vendor { get; set; }
    }
}

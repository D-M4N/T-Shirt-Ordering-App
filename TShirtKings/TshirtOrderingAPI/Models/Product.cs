using System.ComponentModel.DataAnnotations;
using TshirtOrderingAPI.Api.Data;
using TshirtOrderingAPI.Api.Models;

namespace TshirtOrderingAPI.Api.Models
{
    public class Product
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string ShirtSize { get; set; }

        public string DateOfOrder { get; set; }

        public string ShirtName { get; set; }

        public string ShippingAddress { get; set; }

        public string EmailAddress { get; set; }

        public string ContactDetails { get; set; }

        bool Done { get; set; }




















        /* public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal Price { get; set; }*/
    }
}


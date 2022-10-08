using System;
using System.ComponentModel.DataAnnotations;

namespace demo.api.Models.V1
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public decimal BasePrice { get; set; }
    }
}

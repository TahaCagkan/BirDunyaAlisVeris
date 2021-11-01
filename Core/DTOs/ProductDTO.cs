using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class ProductDTO
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public string productName { get; set; }
        public decimal productStok { get; set; }
        public decimal productPrice { get; set; }
        public string categoryName { get; set; }
        public string productImage { get; set; }
    }
}

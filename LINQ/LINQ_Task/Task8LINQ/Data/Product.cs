using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data
{
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Category { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
	}

    public static class ProductHelper
    {
        public static string ToProductsString(this IEnumerable<Product> products)
        {
            var sb = new StringBuilder();

            foreach (var product in products)
            {
                sb.Append(product.ProductName + ",");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}

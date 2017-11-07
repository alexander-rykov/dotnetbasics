using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data
{
	public class Supplier
	{
		public string SupplierName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}

    public static class SupplierHelper
    {
        public static string ToSupplierString(this IEnumerable<Supplier> suppliers)
        {
            var sb = new StringBuilder();

            foreach (var supplier in suppliers)
            {
                sb.Append(supplier.SupplierName + ",");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            
            return sb.ToString();
        }
    }
}

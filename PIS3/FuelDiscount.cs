using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS3
{
    public class FuelDiscount : FuelInfo
    {
        public string FuelType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public decimal DiscountPercent { get; set; }

        public override string ToString()
        {
            return $"FuelDiscount: {FuelType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}, Discount: {DiscountPercent}%";
        }
    }
}

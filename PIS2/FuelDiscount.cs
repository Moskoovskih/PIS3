using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    internal class FuelDiscount : FuelInfo
    {
        public string FuelType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercent { get; set; }

        public override string ToString()
        {
            return $"Скидка на топливо: {FuelType}, from {StartDate.ToString("yyyy.MM.dd")} to {EndDate.ToString("yyyy.MM.dd")}, {DiscountPercent:P2} discount";
        }
    }
}

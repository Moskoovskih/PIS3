using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class FuelPrice : FuelInfo
    {
        public string FuelType { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Цена топлива: {FuelType}, {Date.ToString("yyyy.MM.dd")}, {Price:C}";
        }
    }
}


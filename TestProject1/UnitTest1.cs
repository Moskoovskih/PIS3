using NUnit.Framework;
using PIS3;
using System;

namespace TestProject1
{
    public class FuelInfoLoaderTests
    {
        [Test]
        public void CreateFromDescription_ValidFuelPrice_CreatesFuelPrice()
        {

            string description = "Бензин,2023.04.02,5.0";
            FuelInfo result = FuelInfoLoader.CreateFromDescription(description);

            Assert.IsInstanceOf<FuelPrice>(result);//создается объект типа  и его поля устанавливаются верно
            var fuelPrice = result as FuelPrice;
            Assert.AreEqual("Бензин", fuelPrice.FuelType);
            Assert.AreEqual(new DateTime(2023, 4, 2), fuelPrice.Date);
            Assert.AreEqual(5.0M, fuelPrice.Price);
        }

        [Test]
        public void CreateFromDescription_ValidFuelDiscount_CreatesFuelDiscount()
        {
            string description = "Скидка на Бензин,2023.04.01,2023.04.30,5.0";
            FuelInfo result = FuelInfoLoader.CreateFromDescription(description);

            Assert.IsInstanceOf<FuelDiscount>(result);
            var fuelDiscount = result as FuelDiscount;
            Assert.AreEqual("Скидка на Бензин", fuelDiscount.FuelType);
            Assert.AreEqual(new DateTime(2023, 4, 1), fuelDiscount.StartDate);
            Assert.AreEqual(new DateTime(2023, 4, 30), fuelDiscount.EndDate);
            Assert.AreEqual(5.0M, fuelDiscount.DiscountPercent);
        }

        [Test]
        public void CreateFromDescription_InvalidData_ThrowsArgumentException()
        {

            string invalidDescription = "\"Бензин\",\"invalidDate\",\"50.0\"";
            var ex = Assert.Throws<FormatException>(() => FuelInfoLoader.CreateFromDescription(invalidDescription));//некорректная информ
        }

        [Test]
        public void CreateFromDescription_InsufficientData_ThrowsArgumentException()
        {
            string invalidDescription = "\"Бензин\",\"2023.01.01\""; // Недостаточно информ

            var ex = Assert.Throws<ArgumentException>(() => FuelInfoLoader.CreateFromDescription(invalidDescription));
            Assert.That(ex.Message, Is.EqualTo("Недостаточно данных для создания объекта."));
        }

        [Test]
        public void ParseDate_ValidDate_ReturnsDateTime()
        {

            string dateStr = "2023.01.01";
            DateTime result = FuelInfoLoader.ParseDate(dateStr);
            Assert.AreEqual(new DateTime(2023, 1, 1), result);
        }

        [Test]
        public void ParseDecimal_ValidDecimalString_ReturnsDecimal()
        {

            string decimalStr = "50.0";
            decimal result = FuelInfoLoader.ParseDecimal(decimalStr);
            Assert.AreEqual(50.0M, result);
        }

        [Test]
        public void ParseDecimal_InvalidDecimalString_ThrowsFormatException()
        {
            string invalidDecimalStr = "invalid";
            var ex = Assert.Throws<FormatException>(() => FuelInfoLoader.ParseDecimal(invalidDecimalStr));
            Assert.That(ex.Message, Does.Contain("Входная строка имела неверный формат"));
        }
    }
}

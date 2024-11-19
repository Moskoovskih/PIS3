
using PIS2;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        var objects = ReadObjectsFromFile("C:\\Users\\User\\Desktop\\1.txt");
        PrintObjects(objects);
        Console.ReadKey();
    }

    private static List<FuelInfo> ReadObjectsFromFile(string fileName)
    {
        var objects = new List<FuelInfo>();

        using (var reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    objects.Add(CreateFromDescription(line));
                }
            }
        }
        return objects;
    }

    private static FuelInfo CreateFromDescription(string description)
    {
        string[] properties = description.Split(',');
        string objectType = properties[0].Trim('"');

        switch (objectType)
        {
            case "Бензин":
                return new FuelPrice
                {
                    FuelType = properties[0].Trim('"'),
                    Date = DateTime.ParseExact(properties[1], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    Price = decimal.Parse(properties[2], CultureInfo.InvariantCulture)
                };
            case "Дизельное":
                return new FuelPrice
                {
                    FuelType = properties[0].Trim('"'),
                    Date = DateTime.ParseExact(properties[1], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    Price = decimal.Parse(properties[2], CultureInfo.InvariantCulture)
                };
            case "Заправка":
                return new FuelStation
                {
                    StationName = properties[1].Trim('"'),
                    Address = properties[2].Trim('"'),
                    ContactInfo = properties[3].Trim('"')
                };
            case "Скидка на Бензин":
                return new FuelDiscount
                {
                    FuelType = properties[0].Trim('"'),
                    StartDate = DateTime.ParseExact(properties[1], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(properties[2], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                    DiscountPercent = decimal.Parse(properties[3], CultureInfo.InvariantCulture)
                };
        
         case "Скидка на Дизельное":
            return new FuelDiscount
            {
                FuelType = properties[0].Trim('"'),
                StartDate = DateTime.ParseExact(properties[1], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact(properties[2], "yyyy.MM.dd", CultureInfo.InvariantCulture),
                DiscountPercent = decimal.Parse(properties[3], CultureInfo.InvariantCulture)
            };
        default:
            throw new ArgumentException($"Неизвестный тип объекта: {objectType}");
        }
    }

    private static void PrintObjects(IEnumerable<FuelInfo> objects)
    {
        foreach (var obj in objects)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}



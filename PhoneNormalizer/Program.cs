using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Нормалізатор телефонних номерів");
Console.Write("Введіть номер телефону: ");
string? phone = Console.ReadLine();

Console.WriteLine($"Введено: {phone}");
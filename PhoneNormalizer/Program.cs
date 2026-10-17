using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Нормалізатор телефонних номерів");
Console.Write("Введіть номер телефону: ");
string? phone = Console.ReadLine();

string? result = NormalizePhone(phone);

if (result == null)
    Console.WriteLine("Помилка: введіть 10 цифр, починаючи з 0.");
else
    Console.WriteLine($"Результат: {result}");

static string? NormalizePhone(string? phone)
{
    if (string.IsNullOrWhiteSpace(phone))
        return null;

    phone = phone.Trim();
    if (phone.StartsWith("+380") && phone.Length == 13)
        phone = "0" + phone.Substring(4);
    if (phone.Length != 10 || phone[0] != '0')
        return null;

    foreach (char symbol in phone)
    {
        if (symbol < '0' || symbol > '9')
            return null;
    }

    return $"+380 {phone.Substring(1, 2)} " +
           $"{phone.Substring(3, 3)} " +
           $"{phone.Substring(6, 2)} {phone.Substring(8, 2)}";
}
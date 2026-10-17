using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Нормалізатор телефонних номерів");
Console.WriteLine("Для виходу введіть exit.");

while (true)
{
    Console.Write("\nВведіть номер телефону: ");
    string? phone = Console.ReadLine();

    if (phone == null ||
        phone.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    string? result = NormalizePhone(phone);

    if (result == null)
        Console.WriteLine("Помилка: введіть номер у форматі 0XXXXXXXXX або +380XXXXXXXXX. Дозволено пробіли, дужки та дефіси.");
    else
        Console.WriteLine($"Результат: {result}");
}

static string? NormalizePhone(string? phone)
{
    if (string.IsNullOrWhiteSpace(phone))
        return null;

    phone = phone.Trim()
        .Replace(" ", "")
        .Replace("-", "")
        .Replace("(", "")
        .Replace(")", "");

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
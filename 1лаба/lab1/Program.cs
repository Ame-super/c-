using System.Globalization;
using System.IO.Compression;
using System.Xml.Serialization;
// 1.1.7
void Cylinder()
{
    double V = 0;

    Console.Write("Введите радиус ");
    double r = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите высоту цилиндра ");
    double h = Convert.ToDouble(Console.ReadLine());

    V = Math.PI * r * r * h;

    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine($"Цилиндр радиусом {r} высотой {h} и объемом {Math.Round(V,2)}\n");

}
//1.2.6
void Expression()
{
    //!Дроби пишутся с запятой а не точкой!
    double x, y, z, p;
    Console.WriteLine("Введите y1, y2, z1, z2, p1, p2 в одну строку через пробел"); 
    var input = Console.ReadLine().Split(); // селект аля лямбда функция  
    try 
    {
        var num = input.Select(double.Parse).ToArray();
        x = Math.Sqrt(Math.Pow(num[0],2)+Math.Pow(num[2],2)+Math.Pow(num[4],2));
        y = (num[0]-num[1])/x;
        z = (num[2]-num[3])/x;
        p = num[4]*num[5]/x;
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"x = √( Y1^2 + Z1^2 + P1^2 ) |   x = {Math.Round(x,2)}");
        Console.WriteLine($"y = ( Y1 - Y2 ) / X         |   y = {Math.Round(y,2)}");
        Console.WriteLine($"z = ( Z1 + Z2 ) / X         |   z = {Math.Round(z,2)}");
        Console.WriteLine($"p = P1 * P2 / X             |   p = {Math.Round(p,2)}");
    }
    catch 
    {
        Console.WriteLine("Ошибка: введены некорректные данные!");
        Expression();
    }
    
    
    

}
//2.1.16
void Tree()
{
    Console.WriteLine("Введите a1, a2, z в одну строку через пробел"); 
    var input = Console.ReadLine().Split(); 
    try 
    {
        var num = input.Select(double.Parse).ToArray();
        double q = 0;
        if (num[0] <= num[2] && num[2] <= num[1])
        {   
            Console.WriteLine("A1 ≤ Z ≤ A2  -> Q = A1 - Z**2");
            q = num[0]-Math.Pow(num[2],2);
        }
        else if (num[2] >= num[1])
        {   
            Console.WriteLine("Z > A2  -> Q = Z - A2**2");
            q = num[2]-Math.Pow(num[1],2);
        }
        else if (num[2] <= num[0])
        {
            Console.WriteLine("Z ≤ A1 -> Q = Z * A1");
            q = num[2]*num[0];
        }
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Q = {Math.Round(q,2)}");
    }
    catch 
    {
        Console.WriteLine("Ошибка: введены некорректные данные!");
        Tree();
    }
}
//3.1.10
void For()
{
    Console.WriteLine("Введите p, x1, x2 через пробел:");
    string[] inputs = Console.ReadLine().Split();
    if (!double.TryParse(inputs[0], out double P) ||
        !double.TryParse(inputs[1], out double X1) ||
        !double.TryParse(inputs[2], out double X2))
    {
        Console.WriteLine("Ошибка: некорректный формат чисел!");
        For();
        return;
    }
    Console.WriteLine("-----------------------------------------------");
    
    for (int V = -2; V >= -8; V--)
    {
        double X = (X1 + P * X2) / (1 + V);
        Console.WriteLine($"V = {V,2} => X = {Math.Round(X, 2)}");
    }
    
}


while(true)
{
    Console.WriteLine("\nВыберите задание (1-4) или введите 'exit' для выхода:");
    Console.WriteLine("1) 1.1.7\n2) 1.2.6\n3) 2.1.16\n4) 3.1.10");
    
    string? input = Console.ReadLine()?.Trim().ToLower();
    
    if (input == "exit") break;
    
    switch (input)
    {
        case "1":
            Cylinder();
            break;
        case "2":
            Expression();
            break;
        case "3":
            Tree();
            break;
        case "4":
            For();
            break;
        default:
            Console.WriteLine("Некорректный ввод! Используйте цифры 1-4.");
            break;
    }
}
using System;
using System.Globalization;
using System.Linq;

class Program
{
    void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание (1-6) или введите 'exit' для выхода:");
            Console.WriteLine("1) 1.1.7\n2) 1.2.6\n3) 2.1.16\n4) 3.1.10\n5) 3.2.1\n6) 2.2.1");

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
                case "5":
                    While();
                    break;
                case "6":
                    Numb();
                    break;
                default:
                    Console.WriteLine("Некорректный ввод! Используйте цифры 1-6.");
                    break;
            }
        }
    }

    // 1.1.7
    void Cylinder()
    {
        double V = 0;

        double r = ReadDouble("Введите радиус: ");
        double h = ReadDouble("Введите высоту цилиндра: ");
        
        if (r <= 0 || h <= 0) { Console.WriteLine("Некорректный ввод! Геометрические величины должны быть положительными"); Cylinder(); }

        V = Math.PI * r * r * h;

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Цилиндр радиусом {r} высотой {h} и объемом {Math.Round(V, 2)}\n");
    }

    // 1.2.6
    void Expression()
    {
        Console.WriteLine("Введите y1, y2, z1, z2, p1, p2 в одну строку через пробел:");
        var input = Console.ReadLine().Split();

        if (input.Length != 6 || !input.All(double.TryParse))
        {
            Console.WriteLine("Ошибка: введены некорректные данные!");
            Expression();
            return;
        }

        var num = input.Select(double.Parse).ToArray();
        double x = Math.Sqrt(Math.Pow(num[0], 2) + Math.Pow(num[2], 2) + Math.Pow(num[4], 2));
        double y = (num[0] - num[1]) / x;
        double z = (num[2] - num[3]) / x;
        double p = num[4] * num[5] / x;

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"x = √( Y1^2 + Z1^2 + P1^2 ) |   x = {Math.Round(x, 2)}");
        Console.WriteLine($"y = ( Y1 - Y2 ) / X         |   y = {Math.Round(y, 2)}");
        Console.WriteLine($"z = ( Z1 + Z2 ) / X         |   z = {Math.Round(z, 2)}");
        Console.WriteLine($"p = P1 * P2 / X             |   p = {Math.Round(p, 2)}");
    }

    // 2.1.16
    void Tree()
    {
        Console.WriteLine("Введите a1, a2, z в одну строку через пробел:");
        var input = Console.ReadLine().Split();

        if (input.Length != 3 || !input.All(double.TryParse))
        {
            Console.WriteLine("Ошибка: введены некорректные данные!");
            Tree();
            return;
        }

        var num = input.Select(double.Parse).ToArray();
        double q = 0;

        if (num[0] <= num[2] && num[2] <= num[1])
        {
            Console.WriteLine("A1 ≤ Z ≤ A2  -> Q = A1 - Z**2");
            q = num[0] - Math.Pow(num[2], 2);
        }
        else if (num[2] >= num[1])
        {
            Console.WriteLine("Z > A2  -> Q = Z - A2**2");
            q = num[2] - Math.Pow(num[1], 2);
        }
        else if (num[2] <= num[0])
        {
            Console.WriteLine("Z ≤ A1 -> Q = Z * A1");
            q = num[2] * num[0];
        }

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Q = {Math.Round(q, 2)}");
    }

    // 2.2.1
    void Numb()
    {
        double number1 = ReadDouble("Введите первое число: ");
        double number2 = ReadDouble("Введите второе число: ");
        double number3 = ReadDouble("Введите третье число: ");

        double minNumber = Math.Min(number1, Math.Min(number2, number3));

        Console.WriteLine($"Наименьшее число: {minNumber}");
    }

    // 3.1.10
    void For()
    {
        Console.WriteLine("Введите p, x1, x2 через пробел:");
        string[] inputs = Console.ReadLine().Split();

        if (inputs.Length != 3 || !inputs.All(double.TryParse))
        {
            Console.WriteLine("Ошибка: некорректный формат чисел!");
            For();
            return;
        }

        double P = double.Parse(inputs[0]);
        double X1 = double.Parse(inputs[1]);
        double X2 = double.Parse(inputs[2]);

        Console.WriteLine("-----------------------------------------------");

        for (int V = -2; V >= -8; V--)
        {
            double X = (X1 + P * X2) / (1 + V);
            Console.WriteLine($"V = {V,2} => X = {Math.Round(X, 2)}");
        }
    }

    // 3.2.1
    static void While()
    {
        double X2 = ReadDouble("Введите значение X2: ");
        double N = ReadDouble("Введите значение N: ");

        if (N == -1)
        {
            Console.WriteLine("Ошибка: N не может быть равно -1, так как это вызывает деление на ноль.");
            return;
        }

        Console.WriteLine("\nВычисление X для различных значений X1:");
        Console.WriteLine("X1\tX");

        for (double X1 = 0.9; X1 >= 0.1; X1 -= 0.1)
        {
            double X = (X1 + N * X2) / (1 + N);
            Console.WriteLine($"{X1:F1}\t{X:F4}");
        }
    }

    // Вспомогательный метод для безопасного чтения чисел
    double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double result))
            {
                return result;
            }

            Console.WriteLine("Ошибка: введено некорректное число. Попробуйте снова.");
        }
    }
}
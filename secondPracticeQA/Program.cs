using System;

// Собственные исключения
public class TangentUndefinedException : Exception
{
    public TangentUndefinedException() : base("Тангенс не определён: косинус равен нулю.") { }
}

public class CotangentUndefinedException : Exception
{
    public CotangentUndefinedException() : base("Котангенс не определён: синус равен нулю.") { }
}
class Program

{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); 
            

            Console.WriteLine("Введите значение косинуса угла:");
            string cosInput = Console.ReadLine();

            Console.WriteLine("Введите значение синуса угла:");
            string sinInput = Console.ReadLine();

            double cos, sin;

            try
            {
                // Попытка преобразовать строки в числа
                cos = Convert.ToDouble(cosInput);
                sin = Convert.ToDouble(sinInput);

                // Проверка корректности значений (должны быть в диапазоне [-1; 1])
                if (Math.Abs(cos) > 1 || Math.Abs(sin) > 1)
                {
                    Console.WriteLine("Ошибка: значения синуса и косинуса должны находиться в диапазоне от -1 до 1.");
                }
                else
                {
                    // Вычисление тангенса
                    try
                    {
                        if (cos == 0)
                            throw new TangentUndefinedException();
                        double tan = sin / cos;
                        Console.WriteLine($"Тангенс = {tan:F4}");
                    }
                    catch (TangentUndefinedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    // Вычисление котангенса
                    try
                    {
                        if (sin == 0)
                            throw new CotangentUndefinedException();
                        double cot = cos / sin;
                        Console.WriteLine($"Котангенс = {cot:F4}");
                    }
                    catch (CotangentUndefinedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено некорректное число. Убедитесь, что вы ввели действительное число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: введено слишком большое число.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
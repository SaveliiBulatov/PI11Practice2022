using System;

namespace moonShip
{

    class Program
    {

        static void Main(string[] args)
        {

            //Данные
            double h = 1000; //высота в метрах
            string t = ""; //время
            double f = 100;//топливо в секундах
            double v = 0; //начальная скорость корабля
            const double a = 5; // двигатель
            const double g = -1.625; // ускорение свободного 
            const double crushspeed = 5; //скорость разбивания
            bool onDrive = false;//включение выкл двигателя
            double x = 0;

            // основная прога
            while (h >= 0.001)
            {
                // Чвывод данных
                Console.WriteLine($"Расстояние до луны {Math.Abs(h)}, метров\n Скорость корабля {Math.Abs(v)}, м/с\n Запас топлива {f},сек ");
                // ввод пользователя с проверкой
                Console.WriteLine("На сколько секунд вы хотите включить двигатель?");
                t = Console.ReadLine();
                if (double.TryParse(t, out var number))
                {
                    onDrive = true;
                    if (number <= 0)
                    {
                        x = g;
                    }
                    else
                    {
                        x = a;
                    }
                    if (number < 0) number = 0;
                    if (number > f) number = f;
                    
                    if (x == a)
                    {
                        if (onDrive) f -= number;
                        h = h + v * number + x / 2 * number * number;
                        v = v + x * number;
                    }
                    else
                    {
                        if (onDrive) f -= number;
                        h = h + x + v;
                        v = v + x;
                    }
                }
                else
                {
                    Console.WriteLine("Введите число");
                }
            }
            //вывод промежуточного значения
            Console.WriteLine($"Расстояние до луны {Math.Abs(h)}, метров \n Скорость корабля {Math.Abs(v)}, м/с \n Осталось топлива {f}, сек");

            //итог 
            if (Math.Abs(v) < crushspeed)
            {
                Console.WriteLine("Да вы не лох");
            }
            else
            {
                Console.WriteLine("А ну повтори (лох что-ли?)");
            }
        }
    }
}
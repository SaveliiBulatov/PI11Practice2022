using System;
namespace TheRoom
{
    class Program
    {
        static int Getint(string s, int min, int max)
        {
            int result = min;
            bool valid = false;

            do
            {
                Console.WriteLine(s);
                valid = int.TryParse(Console.ReadLine(), out result);
            }
            while (!valid || result < min || result > max);
            return result;
        }

        static void Main(string[] args)
        {
            //Локации
            const int door = 1;
            const int wardrobe = 2;
            const int letter = 3;
            const int safe = 4;

            //Данные
            Random rnd = new Random();
            int loc = door;
            int code = rnd.Next(1000, 10000);//Спавним код от сейфа
            bool door_unlocked = false;
            bool wardrobe_unlocked = false;
            bool key_get = false;
            bool gun = false;
            bool safe_open = false;

            //Ввод в  игру
            Console.Clear();
            Console.WriteLine("Вы очнулись в просторной комнате");
            Console.WriteLine("Вы вспоминаете, как вас в баре угостили странным коктелем.");
            Console.WriteLine("Вы чувствуете невыносимую боль.все в ваше тело в ранах");
            Console.WriteLine("Вам нужно,выбраться.Найдите как излечиться");
            Console.WriteLine();

            //Основной цикл
            while (true)
            {
                Console.WriteLine();
                if (loc == door)
                {
                    Console.WriteLine("Перед вами массивная железная дверь.Грубой силой ее не открыть");
                    if (!door_unlocked)
                        Console.WriteLine("Вы видите огромную замочную скважину.Наверно должен быть ключ, но в этой ли комноте?");
                    Console.WriteLine();
                    Console.WriteLine("1) Подойти к шкафу");
                    Console.WriteLine("2) Прочитать газету");
                    Console.WriteLine("3) Подойти к сейфу");
                    if (!door_unlocked)
                        Console.WriteLine("4)Отпереть замок");
                    else
                        Console.WriteLine("4)Открыть дверь и уйти");

                    //Выбор действия
                    int n = Getint("Ваш выбор", 1, 4);

                    //Обработка действия
                    if (n == 1)//Подойти к шкафчику
                        loc = wardrobe;
                    else if (n == 2)//Прочитать письмо
                        loc = letter;
                    else if (n == 3)//Подойти к сейфу
                        loc = safe;
                    else if (n == 4)
                    {
                        if (!door_unlocked && !gun)
                        {
                            //Дверь открыта,но аптечка не использована
                            Console.WriteLine("Вы выбрались из комнаты,но вас тут-же схватила охрана.Вы погибли");
                            break;
                        }
                        if (!door_unlocked  && gun == true)
                        {
                            //Дверь заперта
                            if (key_get == true)
                            {
                                door_unlocked = true;
                                Console.WriteLine("Вы отпираете дверь найденым ключом.пистолет помог вам уйти от охранников");

                            }
                            else
                            {
                                Console.WriteLine("У вас нет ключа");
                            }
                            break; 
                        }
                    }
                }
                else if (loc == wardrobe)
                {
                    Console.WriteLine("В комнате стоит шкаф");
                    Console.WriteLine("Возможно в нем лежит что-то ценное");
                    Console.WriteLine();
                    Console.WriteLine("1) Подойти к двери");
                    Console.WriteLine("2) Взглянуть на газету");
                    Console.WriteLine("3) Подойти к сейфу");
                    Console.WriteLine("4) Осмотреть шкафчик");

                    int n = Getint("Выш выбор", 1, 4);

                    //Обработка действия
                    if (n == 1)
                        loc = door;
                    else if (n == 2)
                        loc = letter;
                    else if (n == 3)
                        loc = safe;
                    else if (n == 4)
                    {
                        Console.WriteLine("Внутри шкафа вы находите ключ.Но стоит ли спешить с побегом или поискать что-то что помжет обойти того кто заковал вас?");
                        key_get = true;
                    }
                }

                else if (loc == letter)
                {
                    Console.WriteLine("Вы замечаете на полу отрывок газеты");
                    Console.WriteLine();
                    Console.WriteLine("1) Подойти к двери");
                    Console.WriteLine("2) Подойти к шкафчику");
                    Console.WriteLine("3) Подойти к сейфу");
                    Console.WriteLine("4) Осмотреть газету");

                    //Выбор действия
                    int n = Getint("Ваш выбор", 1, 4);
                    if (n == 1)
                        loc = door;
                    else if (n == 2)
                        loc = wardrobe;
                    else if (n == 3)
                        loc = safe;
                    else if (n == 4)
                    {
                        Console.WriteLine($"Осмотрев газету,вы можете только различить цифры года ее издания {code}.Может это намек?");
                    }

                }

                else if (loc == safe)
                {
                    Console.WriteLine("В дальнем углу комнаты стоит старый сейф.Возможно внутри есть то что поможет мне сбежать");
                    Console.WriteLine();
                    Console.WriteLine("1) Подойти к двери");
                    Console.WriteLine("2) Подойти к шкафу");
                    Console.WriteLine("3) Взглянуть на газету");
                    Console.WriteLine("4) Открыть сейф");

                    //Выбо действия
                    int n = Getint("Ваш выбор", 1, 4);
                    if (n == 1)
                        loc = door;
                    else if (n == 2)
                        loc = wardrobe;
                    else if (n == 3)
                        loc = safe;
                    else if (n == 4)
                    {
                        //Видим запертый сейф
                        Console.WriteLine("Вы пытаетесь открыть сейф,но он так просто открыть не получится.Нужно ввести код");

                        int x = Getint("Введите код(4 цифры)", 1000, 9999);

                        if (x == code)
                        {
                            safe_open = true;
                            Console.WriteLine("У вас получилось открыть сейф");
                            Console.WriteLine("Внутри сейфа лежит пистолет.");
                            gun = true;


                        }
                        else
                            Console.WriteLine("Вы ввели неверный код.Попробуйте еще раз");

                    }

                }
            }


        }
    }
}
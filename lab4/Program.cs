Console.Clear();

Maze m = new Maze(ConsoleColor.Red, ConsoleColor.Yellow);

while (true)
{
    m.Print(5, 19, "Вы оказались в лабиринте.Вам нужно собрать монетки,купить на них ключ и открыть им дверь.Но не все так просто");


    m.Print(3, 3);
    if (m.door)
    {
        Console.CursorVisible = false;
        Console.Clear();
        m.Print(5, 25, "Вы спаслись");
        
    }
    if (m.score)
    {
        m.score = false;
        m.Print(5, 20, $"вы собрали {m.coins} деняг");
        //
        if (m.coins == 5)
        {

            m.Print(5, 21, "Вы можете купить ключик");
 
            m.maze = new int[,]
    {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                { 1, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

            if (m.key1 == true)
            {
                m.Print(5, 22, "Вы купили ключ");
            }


        }




    }


    ConsoleKeyInfo ki = Console.ReadKey(true);
    if (ki.Key == ConsoleKey.Escape)
    {

        Console.Clear();
        break;
    }
    //перемещение
    if (ki.Key == ConsoleKey.LeftArrow) m.Move(-1, 0);
    if (ki.Key == ConsoleKey.RightArrow) m.Move(1, 0);
    if (ki.Key == ConsoleKey.UpArrow) m.Move(0, -1);
    if (ki.Key == ConsoleKey.DownArrow) m.Move(0, 1);
}

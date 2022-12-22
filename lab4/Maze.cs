class Maze
{

    //данные

    public bool key1 = false;
    public int coins = 0;
    public bool door = false;
    public bool score = false;
    int playerx = 2;
    int playery = 1;
    public int[,] maze = new int[,]
    {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 3, 0, 1, 5, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1 }, 
                { 1, 0, 1, 5, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 0, 0, 5, 1, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 }, 
                { 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 5, 1, 0, 0, 0, 1, 0, 0, 1 }, 
                { 1, 0, 0, 0, 0, 1, 5, 1, 0, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };
    ConsoleColor ink;
    ConsoleColor paper;

    public Maze(ConsoleColor i, ConsoleColor p)
    {
        ink = i;
        paper = p;
    }
    //методы
    public void Move(int dx, int dy)
    {
        int nx = playerx + dx;
        int ny = playery + dy;


        if (maze[ny, nx] > maze.Length)
        {
            Console.WriteLine("Выход за пределы массива");

        }

        if (maze[ny, nx] == 0 || maze[ny, nx] == 4 || maze[ny, nx] == 5)
        {
            playerx = nx;
            playery = ny;
        }
        if (maze[ny, nx] == 2 && coins == 5)
        {
            Print(3, 24, "Вы купили ключикб не золотой но все же");
            key1 = true;
            playerx = 1;
            playery = 1;
            maze[ny, nx] = 0;
            maze = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                { 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

        }




        if (maze[ny, nx] == 4)
        {
            door = true;
        }
        if (maze[ny, nx] == 5)
        {
            maze[ny, nx] = 0;
            coins++;
            score = true;
        }
    }



    public void Print(int shiftx, int shifty)
    {
        for (int y = 0; y < 13; y++)
            for (int x = 0; x < 13; x++)
            {
                double dist = Math.Sqrt((playerx - x) * (playerx - x) + (playery - y) * (playery - y));
                if (dist > 5)
                {
                    Print(shiftx + x, shifty + y, " ", ConsoleColor.White, ConsoleColor.DarkBlue);
                }
                else
                {
                    if (maze[y, x] == 0) Print(shiftx + x, shifty + y, ".");
                    else if (maze[y, x] == 1) Print(shiftx + x, shifty + y, "#", ink, paper);
                    else if (maze[y, x] == 2) Print(shiftx + x, shifty + y, "&");
                    else if (maze[y, x] == 3) Print(shiftx + x, shifty + y, "|");
                    else if (maze[y, x] == 4) Print(shiftx + x, shifty + y, "%");
                    else if (maze[y, x] == 5) Print(shiftx + x, shifty + y, "$");
                }
            }

        Print(shiftx + playerx, shifty + playery, "@");
    }

    public void Print(int x, int y, string s, ConsoleColor ink = ConsoleColor.Blue, ConsoleColor paper = ConsoleColor.Black)
    {
        Console.ForegroundColor = ink;
        Console.BackgroundColor = paper;
        Console.CursorLeft = x;
        Console.CursorTop = y;
        Console.Write(s);



    }


}

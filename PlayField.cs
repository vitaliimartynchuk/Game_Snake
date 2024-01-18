namespace ConsoleApp_SnakeGame
{
    public class PlayField
    {
        public const int R = 10; // константи для розміру ігрового поля
        public const int S = 10;
        public void Draw(char[,] snakeArr, char[,] foodArr) // метод малювання ігрового поля, змії та їжі
        {
            Console.Clear();

            Console.WriteLine("\tSNAKE");

            Console.WriteLine("┌" + new string('─', S * 2) + "┐");

            for (int i = 0; i < R; i++)
            {
                Console.Write("│");

                for (int j = 0; j < S; j++)
                {
                    if (snakeArr[i, j] == ' ' && foodArr[i, j] == '\0')
                    {
                        Console.Write("  ");
                    }
                    else if (snakeArr[i, j] != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // встановлюємо зелений
                        Console.Write(snakeArr[i, j] + " ");
                        Console.ForegroundColor = ConsoleColor.White; // повертаємо до білого
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // жовтий
                        Console.Write(foodArr[i, j] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (j == S - 1)
                    {
                        Console.Write("│");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("└" + new string('─', S * 2) + "┘");
        }
    }
}
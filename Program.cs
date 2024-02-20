namespace ConsoleApp_SnakeGame
{
    internal class Program
    {
        static void Main()
        {
            Console.CursorVisible = false; // прибираємо курсор


            RecordFile recordFile = new RecordFile(); 
            int record = recordFile.ReedFromFile(); // запис рекорду із файлу


            PlayField playField = new PlayField();
            Snake snake = new Snake();
            Food food = new Food(snake.S_X, snake.S_Y);


            while (true) // цикл ходу змії
            {
                playField.Draw(snake.SnakeArr, food.FoodArr); // малюємо все
                Console.WriteLine($"Score: " + food.CountGame);


                if (food.CountGame > record)
                {
                    record = food.CountGame;
                    recordFile.RecordInFile(record); // записуємо рекрд у файл якщо він збільшився
                }
                Console.WriteLine($"Record: " + record);


                if (Console.KeyAvailable) // дивимось чи натиснута якась клавіша
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("GAME OVER!"); // виходимо з гри якщо насикаємо Escape
                        return;
                    }

                    snake.UpdateDirection(keyInfo); // якщо якась стрілка, змінюємо напрямок
                }


                snake.MoveHead(food.F_X, food.F_Y); // рух голови
                 

                if (snake.EndGame()) // перевірка на закінчення гри
                {
                    Console.WriteLine("GAME OVER!");
                    Console.WriteLine("Press Enter to play again or Escape to exit.");

                    ConsoleKeyInfo restartKey;
                    do // чекає поки натиснемо або ентер або ескейп
                    {
                        restartKey = Console.ReadKey(true);
                    } while (restartKey.Key != ConsoleKey.Enter && restartKey.Key != ConsoleKey.Escape);

                    if (restartKey.Key == ConsoleKey.Escape)
                    {
                        return; // Вихід з гри повністю
                    }
                    else if (restartKey.Key == ConsoleKey.Enter)
                    {
                        // Початок нової гри: обнулення змінних і т.д.
                        snake = new Snake();
                        food = new Food(snake.S_X, snake.S_Y);
                        continue;
                    }
                }


                snake.MoveTail(food.F_X, food.F_Y); // рух хвоста
                food.GenerateFood(snake.S_X, snake.S_Y); // генеруємо їжу


                Thread.Sleep(350); // Затримка у мілісекундах 
            }
        }
    }
}
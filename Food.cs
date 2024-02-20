namespace ConsoleApp_SnakeGame
{
    public class Food 
    {
        public char c = '*'; // їжа
        public char[,] foodArr; // окремий масив де малюється їжа щоб не заважати руху змії
        public int F_x; // координати їжі  
        public int F_y;
        public int countGame = -1; // кількість з'їдань їжі

        public int S_R = PlayField.R;
        public int S_S = PlayField.S;

        public Food(int snakeX, int snakeY)
        {
            foodArr = new char[S_R, S_S];
            GenerateFood(snakeX, snakeY);
        }

        public void GenerateFood(int snakeX, int snakeY)
        {
            Random random = new Random();

            foodArr[F_x, F_y] = ' ';

            if (F_x != snakeX || F_y != snakeY) // дивимось чи їжа не попадає на координати голови змії
            {
                foodArr[F_x, F_y] = c; // якщо ні, то малюємо їжу
            }
            else
            {
                do
                {
                    F_x = random.Next(S_R); 
                    F_y = random.Next(S_S);
                } while (F_x == snakeX && F_y == snakeY); // інакше генеруємо нові координати поки не попадемо на місце без голови

                foodArr[F_x, F_y] = c;
                countGame++;
            }
        }
    }
}
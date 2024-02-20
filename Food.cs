namespace ConsoleApp_SnakeGame
{
    public class Food 
    {
        private char c = '*'; // їжа
        private char[,] foodArr; // окремий масив де малюється їжа щоб не заважати руху змії
        private int F_x; // координати їжі  
        private int F_y;
        private int countGame = -1; // кількість з'їдань їжі

        private int F_R = PlayField.R; 
        private int F_S = PlayField.S; 

        public Food(int snakeX, int snakeY)
        {
            foodArr = new char[F_R, F_S];
            GenerateFood(snakeX, snakeY);
        }

        // Властивості для доступу до приватних змінних
        public char C
        {
            get { return c; }
            private set { c = value; }
        }

        public char[,] FoodArr
        {
            get { return foodArr; }
            private set { foodArr = value; }
        }

        public int F_X
        {
            get { return F_x; }
            private set { F_x = value; }
        }

        public int F_Y
        {
            get { return F_y; }
            private set { F_y = value; }
        }

        public int CountGame
        {
            get { return countGame; }
            private set { countGame = value; }
        }

        public int F_RR
        {
            get { return F_R; }
            private set { F_R = value; }
        }

        public int F_SS
        {
            get { return F_S; }
            private set { F_S = value; }
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
                    F_x = random.Next(F_R); 
                    F_y = random.Next(F_S);
                } while (F_x == snakeX && F_y == snakeY); // інакше генеруємо нові координати поки не попадемо на місце без голови

                foodArr[F_x, F_y] = c;
                countGame++;
            }
        }
    }
}
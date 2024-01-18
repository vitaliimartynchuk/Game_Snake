namespace ConsoleApp_SnakeGame
{
    public class Snake : PlayField
    {
        public char[,] snakeArr; // масив ігрового поля де рухається змія
        public List<(int, int)> tail; // список координат хвоста змії

        public char a = ' ';
        public char b = '■';

        public int S_x; // координати голови змії
        public int S_y;

        public enum Direction
        {
            Right,
            Left,
            Down,
            Up
        }

        private Direction currentDirection = Direction.Right; // початок автоматичного руху вправо

        public Snake()
        {
            S_x = 0;
            S_y = 0;
            snakeArr = new char[R, S];
            FillArr(snakeArr, a, b);
            tail = new List<(int, int)>();
        }

        private void FillArr(char[,] snakeArr, char a, char b) // початкове заповнення поля гри
        {
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < S; j++)
                {
                    snakeArr[i, j] = a;
                }
            }
            snakeArr[0, 0] = b;
        }

        public void MoveHead(int foodX, int foodY) // рух голови у вказаному напрямку
        {
            switch (currentDirection)
            {
                case Direction.Right:
                    MoveRight(foodX, foodY);
                    break;
                case Direction.Left:
                    MoveLeft(foodX, foodY);
                    break;
                case Direction.Down:
                    MoveDown(foodX, foodY);
                    break;
                case Direction.Up:
                    MoveUp(foodX, foodY);
                    break;
            }
        }

        public void UpdateDirection(ConsoleKeyInfo keyInfo) // зміна автоматичного руху напрямку
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (currentDirection != Direction.Left)  // Заборона змінювати напрямок на протилежний
                        currentDirection = Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
                case ConsoleKey.UpArrow:
                    if (currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
            }
        }

        public void MoveTail(int foodX, int foodY) // рух хвоста
        {
            if (tail.Count > 2 && !(S_x == foodX && S_y == foodY)) // якщо довжина списку більше 2 і якщо їжі немає
            {
                for (int i = 1; i < tail.Count - 1; i++)
                {
                    (int x0, int y0) = tail[i];
                    (int x1, int y1) = tail[i + 1];

                    Swap(ref snakeArr[x0, y0], ref snakeArr[x1, y1]); // робимо хід хвоста
                }
                tail.RemoveAt(tail.Count - 1); // видалили останній елемент з хвоста
            }
        }

        private void MoveRight(int foodX, int foodY) // реалізацію руху у певному напрямку
        {
            int S_x2 = S_x;
            int S_y2 = S_y;

            if (S_y != S - 1) // перевірка на вихід за межі поля
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x, S_y + 1]); // робимо хід голови
                S_y++;
                tail.Insert(0, (S_x, S_y)); // додаємо нове місце у список
            }
            else 
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x, 0]);
                S_y = 0;
                tail.Insert(0, (S_x, S_y));
            }

            if (S_x == foodX && S_y == foodY) // перевірка на їжу, якщо їжа є малюємо хвоста у попередній клітинці, та додаємо у список
            {
                snakeArr[S_x2, S_y2] = b; // якщо їжа є, малюємо хвоста у попередній клітинці

                if (tail.Count == 1)
                {
                    tail.Add((S_x2, S_y2)); // якщо довжина списку 1, то додаємо це місце 
                }
            }
        }

        private void MoveLeft(int foodX, int foodY)
        {
            int S_x2 = S_x;
            int S_y2 = S_y;

            if (S_y != 0)
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x, S_y - 1]);
                S_y--;
                tail.Insert(0, (S_x, S_y));
            }
            else
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x, S - 1]);
                S_y = S - 1;
                tail.Insert(0, (S_x, S_y));
            }

            if (S_x == foodX && S_y == foodY)
            {
                snakeArr[S_x2, S_y2] = b;

                if (tail.Count == 1)
                {
                    tail.Add((S_x2, S_y2));
                }
            }
        }

        private void MoveDown(int foodX, int foodY)
        {
            int S_x2 = S_x;
            int S_y2 = S_y;

            if (S_x != R - 1)
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x + 1, S_y]);
                S_x++;
                tail.Insert(0, (S_x, S_y));
            }
            else
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[0, S_y]);
                S_x = 0;
                tail.Insert(0, (S_x, S_y));
            }

            if (S_x == foodX && S_y == foodY)
            {
                snakeArr[S_x2, S_y2] = b;

                if (tail.Count == 1)
                {
                    tail.Add((S_x2, S_y2));
                }
            }
        }

        private void MoveUp(int foodX, int foodY)
        {
            int S_x2 = S_x;
            int S_y2 = S_y;

            if (S_x != 0)
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[S_x - 1, S_y]);
                S_x--;
                tail.Insert(0, (S_x, S_y));
            }
            else
            {
                Swap(ref snakeArr[S_x, S_y], ref snakeArr[R - 1, S_y]);
                S_x = R - 1;
                tail.Insert(0, (S_x, S_y));
            }

            if (S_x == foodX && S_y == foodY)
            {
                snakeArr[S_x2, S_y2] = b;

                if (tail.Count == 1)
                {
                    tail.Add((S_x2, S_y2));
                }
            }
        }
        private static void Swap<T>(ref T a, ref T b) // метод свап, є стандартний у C++, ту треба написати свій
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public bool EndGame() // перевірка чи ми врізались у свій хвіст
        {
            bool end = false;
            if (tail.Count > 3)
            {
                for (int i = 1; i < tail.Count - 1; i++)
                {
                    if (tail[0] == tail[i])
                    {
                        end = true; // дивимось чи голова не врізалась у один із координатів хвоста
                    }
                }
            }
            return end;
        }
    }
}
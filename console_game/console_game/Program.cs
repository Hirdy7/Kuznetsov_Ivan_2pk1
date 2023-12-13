using System;
using System.Diagnostics.Metrics;
using System.IO;


namespace ConsoleApp8
{
    internal class Program
    {

        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize + 1]; //карта
        static char[,] saveMap;
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек

        static int enemiesCount = 10;
        //параметры консоли
        static int winHeight = 40;
        static int winWidth = 100;

        //параметры игрока
        static int playerHP = 50;
        static int playerStrong = 10;
        static int playerStepCount = 0;

        static byte enemyStrong = 5;
        static int enemyHP = 30;

        static int bossHP = 500;
        static int bossStrong = 20;
        static bool isBoss;

        static int buffCount;

        static bool isAlive = true;

        static string path = "save.txt";
        static void Main(string[] args)
        {
            Console.SetWindowSize(winWidth, winHeight);
            StartGame();
        }


        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в чередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;

            if (isBoss)
            {
                x = random.Next(0, mapSize - 5);
                y = random.Next(0, mapSize - 5);
                map[x, y] = 'O';
                map[x, y + 1] = '-';
                map[x, y + 2] = 'O';
            }

            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли

            Console.SetCursorPosition(0, 28); //позиция курсора для подсчета шагов
            Console.Write($"Шагов сделано: {playerStepCount}");

            Console.SetCursorPosition(0, 29);
            Console.Write($"Сила удара: {playerStrong}");

            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}");
        }
        /// <summary>
        /// перемещение персонажа
        /// </summary>
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (isAlive)
            {
                playerOldX = playerX;
                playerOldY = playerY;
                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerY--;
                        playerStepCount++;
                        if (playerY < 0)
                        {
                            playerY = 0;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        playerY++;
                        playerStepCount++;
                        if (playerY >= mapSize)
                        {
                            playerY = mapSize - 1;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        playerX--;
                        playerStepCount++;
                        if (playerX < 0)
                        {
                            playerX = 0;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        playerStepCount++;
                        if (playerX >= mapSize)
                        {
                            playerX = mapSize - 1;
                            playerStepCount--;
                        }
                        break;
                    case ConsoleKey.B:
                        BossSpawn();
                        break;
                    case ConsoleKey.Escape:
                        GameMenu();
                        break;

                }

                if (playerStepCount - buffCount == 20)
                    BuffUp();

                Console.CursorVisible = false; //скрытный курсов

                Console.SetCursorPosition(0, 28);
                Console.Write($"Шагов сделано: {playerStepCount}");

                if (map[playerY, playerX] == 'B')
                {
                    buffCount = playerStepCount;
                    BuffUp();
                }

                if (map[playerY, playerX] == 'E')
                    Fight();

                if (map[playerY, playerX] == 'H')
                    AidUp();

                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldX, playerOldY);
                Console.Write('_');

                //обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(playerX, playerY);
                Console.Write('P');

                if (playerHP <= 0)
                {
                    isAlive = false;
                    GameOver();
                }


            }
        }
        /// <summary>
        /// вывод карты на консоль
        /// </summary>
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'B') Console.ForegroundColor = ConsoleColor.Blue;
                    if (map[i, j] == 'E') Console.ForegroundColor = ConsoleColor.Red;
                    if (map[i, j] == 'H') Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            Console.SetCursorPosition(30, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Буквой B на карте обазначены баффы, увеличивающие силу удара в 2 раза");

            Console.SetCursorPosition(30, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Буквой E на карте обазначены враги, имеющие 30 HP");
            Console.SetCursorPosition(30, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Буквой H на карте обазначены аптечки,");

            Console.SetCursorPosition(30, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("увеличивающие ваше здоровье до 50");
            Console.ResetColor();

            Console.SetCursorPosition(30, 4);
            Console.Write("Буквой P обозначен игрок");

            Console.SetCursorPosition(0, 29);
            Console.Write($"Сила удара: {playerStrong}  ");
            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}  ");
            Console.SetCursorPosition(0, 28);
            Console.Write($"Шагов сделано: {playerStepCount}");

        }
        /// <summary>
        /// стартовое меню игры
        /// </summary>
        static void StartGame()
        {
            Console.Clear();
            string new_game_text = "N - начать новую игру";
            string load_game_text = "L - загрузить последнее сохранение";

            Console.Write(TextToCentre(new_game_text, 1));
            Console.Write(TextToCentre(load_game_text, 0));

            Console.CursorVisible = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    if (!isAlive) ResetMap();
                    GenerationMap();
                    Move();
                    break;
                case ConsoleKey.L:
                    isAlive = true;
                    LoadGame();
                    break;
                default:
                    StartGame();
                    break;

            }
        }
        /// <summary>
        /// логика поднятия бафа
        /// </summary>
        static void BuffUp()
        {
            if (playerStepCount - buffCount == 20)
            {
                playerStrong = 10;

                Console.SetCursorPosition(0, 29);
                Console.Write($"Сила удара: {playerStrong}  ");
            }
            else
            {
                playerStrong *= 2;
                Console.SetCursorPosition(0, 29);
                Console.Write($"Сила удара: {playerStrong}  ");

                map[playerY, playerX] = '_';
            }
        }

        static void Fight()
        {
            while (playerHP > 0 && enemyHP > 0)
            {
                playerHP -= enemyStrong;
                enemyHP -= (playerStrong);

                Console.SetCursorPosition(0, 30);
                Console.Write($"Здоровье игрока: {playerHP}  ");
            }
            enemiesCount--;
            enemyHP = 30;
        }

        static void AidUp()
        {
            playerHP = 50;

            Console.SetCursorPosition(0, 30);
            Console.Write($"Здоровье игрока: {playerHP}  ");
        }

        static void GameOver()
        {
            Console.Clear();
            string game_over = "GAME OVER";
            string lose = "Вы проиграли :(";
            string steps = $"Проделано шагов: {playerStepCount}";
            string go_next = "Нажмите клавишу Enter, чтобы вернуться в меню игры";

            Console.Write(TextToCentre(game_over, 1));
            Console.Write(TextToCentre(lose, 0));
            Console.Write(TextToCentre(steps, -1));
            Console.Write(TextToCentre(go_next, -4));

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                StartGame();
            else
                GameOver();
        }

        static string TextToCentre(string text, sbyte n)
        {
            int text2_X = (Console.WindowWidth / 2) - (text.Length / 2);
            int text2_Y = (Console.WindowHeight / 2) - n;
            Console.SetCursorPosition(text2_X, text2_Y);
            return text;
        }
        static void ResetMap()
        {
            playerHP = 50;
            playerStrong = 10;
            playerStepCount = 0;
            enemies = 10;
            enemiesCount = 10;
            buffs = 5;
            health = 5;
            enemyStrong = 5;
            enemyHP = 30;
            playerY = mapSize / 2;
            playerX = mapSize / 2;
            isAlive = true;
        }

        static void RemoveMap()
        {
            playerHP = 50;
            playerStrong = 10;
            enemies = 0;
            enemiesCount = 0;
            buffs = 4;
            health = 2;
            isAlive = true;
        }

        static void Winning()
        {
            Console.Clear();
            string you_re_winner = "YOU ARE A WINNER!";
            string congruts = "Поздравляем! Вы уничтожили всех врагов!";
            string steps = $"Проделано шагов: {playerStepCount}";
            string go_next = "Нажмите клавишу Enter, чтобы вернуться в меню игры";

            Console.Write(TextToCentre(you_re_winner, 1));
            Console.Write(TextToCentre(congruts, 0));
            Console.Write(TextToCentre(steps, -1));
            Console.Write(TextToCentre(go_next, -4));

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                StartGame();
            else
                Winning();
        }
        static void GameMenu()
        {
            Console.Clear();
            string save = "Нажмите S, чтобы сохранить игру";
            string menu = "Нажмите M, чтобы выйти в главное меню";
            string go = "Нажмите C, чтобы продолжить игру";

            Console.Write(TextToCentre(save, 1));
            Console.Write(TextToCentre(menu, 0));
            Console.Write(TextToCentre(go, -1));

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    SaveGame();
                    break;
                case ConsoleKey.M:
                    ResetMap();
                    StartGame();
                    break;
                case ConsoleKey.C:
                    UpdateMap();
                    Move();
                    break;
                default:
                    GameMenu();
                    break;
            }
        }

        static string SaveGame()
        {
            Console.Clear();
            string save = "Вы успешно сохранили игру!";
            string save1 = "Нажмите любую клавишу, чтобы вернуться в меню паузы";
            Console.Write(TextToCentre(save, 1));
            Console.Write(TextToCentre(save1, 0));
            Console.ReadKey();


            string path = "save.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"playerX={playerX}");
                writer.WriteLine($"playerY={playerY}");
                writer.WriteLine($"playerHP={playerHP}");
                writer.WriteLine($"playerStrong={playerStrong}");
                writer.WriteLine($"playerStepCount={playerStepCount}");
                writer.WriteLine($"enemyHP={enemyHP}");
                writer.WriteLine($"enemies_count={enemiesCount}");

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (map[i, j] == 'P')
                        {
                            map[i, j] = '_';
                        }
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }
            }
            GameMenu();
            return path;
        }
        static void LoadGame()
        {
            string path = "save.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                        int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                        int.TryParse(lines[2].Split('=')[1], out int loadedPlayerHP) &&
                        int.TryParse(lines[3].Split('=')[1], out int loadedPlayerStrong) &&
                        int.TryParse(lines[4].Split('=')[1], out int loadedPlayerStepCount) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadedEnemyHP) &&
                        int.TryParse(lines[6].Split('=')[1], out int loadedEnemies_count))
                    {
                        playerX = loadedPlayerX;
                        playerY = loadedPlayerY;
                        playerHP = loadedPlayerHP;
                        playerStrong = loadedPlayerStrong;
                        playerStepCount = loadedPlayerStepCount;
                        enemyHP = loadedEnemyHP;
                        enemiesCount = loadedEnemies_count;

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 7][j];
                            }
                        }
                        map[playerY, playerX] = 'P';
                        UpdateMap();
                        Move();
                    }

                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден.");
            }
        }

        static void BossSpawn()
        {
            isBoss = true;
            RemoveMap();
            GenerationMap();
            Move();
            isBoss = false;
        }
    }
}
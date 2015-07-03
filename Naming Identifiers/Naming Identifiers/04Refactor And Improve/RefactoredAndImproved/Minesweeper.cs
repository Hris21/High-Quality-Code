namespace Minesweeper
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Minesweeper
    {

        public static void Main()
        {
            const int MAXIMUM_CELLS = 35;

            string command = "";   //<--- Equals to string.Empty
            char[,] gamingField = CreateGamingField();
            char[,] mines = PlantBombs();
            int pointsCounter = 0;
            int rows = 0;
            int cols = 0;
            bool showGameIntro = true;
            bool gameOver = false;
            bool gameWon = false;
            List<Score> highScores = new List<Score>(6);

            do
            {
                if (showGameIntro)
                {
                    Console.WriteLine("Lets play Minesweeper!\nTry to find all fields without mines.\n" +
                        "Command 'top' shows the scoreboard.\nComand 'start' starts a new game.\n" +
                        "Command 'exit' terminates the game!\nHave fun Playing Minesweeper");
                    CreateGameBoard(gamingField);
                    showGameIntro = false;
                }

                Console.Write("Enter row and col separated by space or a command: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if ((int.TryParse(command[0].ToString(), out rows)) &&
                        (int.TryParse(command[2].ToString(), out cols)) &&
                        (rows <= gamingField.GetLength(0) && cols <= gamingField.GetLength(1)))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRankList(highScores); break;

                    case "restart":
                        gamingField = CreateGamingField();
                        mines = PlantBombs();
                        CreateGameBoard(gamingField);
                        gameOver = false;
                        showGameIntro = false;break;

                    case "exit": Console.WriteLine("Farewell!"); break;

                    case "turn":
                        if (mines[rows, cols] != '*')
                        {
                            if (mines[rows, cols] == '-')
                            {
                                UpdatePlayBoard(gamingField, mines, rows, cols);
                                pointsCounter++;
                            }
                            if (MAXIMUM_CELLS == pointsCounter)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                CreateGameBoard(gamingField);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                        break;

                    default:
                        Console.WriteLine("\nError! Invalid command\n"); break;
                }

                if (gameOver)
                {
                    CreateGameBoard(mines);
                    Console.Write("\nGame Over you died with {0} points. " + "Enter your nickname: ", pointsCounter);
                    string nickName = Console.ReadLine();
                    Score result = new Score(nickName, pointsCounter);
                   
                    if (highScores.Count < 5)
                    {
                        highScores.Add(result);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i]. < result.UserPoints)
                            {
                                highScores.Insert(i, result);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }
                    highScores.Sort((Score result1, Score result2) => result2.UserName.CompareTo(result1.UserName));
                    highScores.Sort((Score result1, Score result2) => result2.UserPoints.CompareTo(result1.UserPoints));
                    PrintRankList(highScores);

                    gamingField = CreateGamingField();
                    mines = PlantBombs();
                    pointsCounter = 0;
                   
                    gameOver = false;
                    showGameIntro = true;
                }
                if (gameWon)
                {
					Console.WriteLine("\nCongratulations! You opened 35 cells!");
                    CreateGameBoard(mines);
					Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Score result = new Score(name, pointsCounter);
                    highScores.Add(result);
                    PrintRankList(highScores);
                    gamingField = CreateGamingField();
                    mines = PlantBombs();
                   
                    pointsCounter = 0;
                    gameWon = false;
                    showGameIntro = true;
                }
            }
            while (command != "exit");
			Console.WriteLine("Made in Bulgaria");
			Console.Read();
        }

        private static void PrintRankList(List<Score> points)
        {
            Console.WriteLine("\nPoints: ");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].UserName, points[i].UserPoints);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No highscore!\n");
            }
        }

        private static void UpdatePlayBoard(char[,] field, char[,] mines, int row, int col)
        {
            char bombsNearBy = CountBombsNearBy(mines, row, col);
            mines[row, col] = bombsNearBy;
            field[row, col] = bombsNearBy;
        }

        private static void CreateGameBoard(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGamingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlantBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameEnvironment = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameEnvironment[i, j] = '-';
                }
            }

            List<int> randomIntegers = new List<int>();
            while (randomIntegers.Count < 15)
            {
                Random random = new Random();
                int newRandom = random.Next(50);
                if (!randomIntegers.Contains(newRandom))
                {
                    randomIntegers.Add(newRandom);
                }
            }

            foreach (int random in randomIntegers)
            {
                int col = (random / cols);
                int row = (random % cols);
                if (row == 0 && random != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameEnvironment[col, row - 1] = '*';
            }

            return gameEnvironment;
        }

        private static void fieldCalculations(char[,] field)
        {
            int kol = field.GetLength(0);
            int red = field.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsNearBy = CountBombsNearBy(field, i, j);
                        field[i, j] = bombsNearBy;
                    }
                }
            }
        }

        private static char CountBombsNearBy(char[,] PlayField, int row, int col)
        {
            int count = 0;
            int rows = PlayField.GetLength(0);
            int cols = PlayField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (PlayField[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (PlayField[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (PlayField[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (PlayField[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (PlayField[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (PlayField[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (PlayField[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (PlayField[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}

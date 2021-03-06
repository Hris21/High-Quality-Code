﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Game
{
    internal class Game
    {
        private const string highScoresFile = @"..\..\HighScores.txt"; // The directory of the external highscores file
        private static int[] size = { 35, 20 }; // size[0] - width; size[1] - height
        private static char[,] board = new char[size[0], size[1]]; //main game board
        private static int x = size[0] / 2; // player x
        private static int y = size[1] - 2; // player y
        private static int updateRate = 10; // The rate of update of lines and bonuses
        private static int updateLineCount = 0; //update counter for the lines
        private static int updateBonusesCount = 0; //update counter of the bonus points
        private static int[] playerPosition = { x, y }; // Player coordinates
        private static int currentScore = 0; // The current score of the player
        private static int lineHeight = 0; // Line position according to the player
        private static bool gameNotOver = true; // Checks if the game is over
        private static int[] bonusPosition = { 1, size[1] / 2 }; // Position of the bonus
        private static int level = 0; // Default level of the game
        private static char bonusSymbol = '+';

        private static void Main() //Main menu of the game
        {
            Console.BufferHeight = Console.WindowHeight; //remove the buffer (scrollbar)
            Console.BufferWidth = Console.WindowWidth;

            Console.Title = "Aim For The Hole";
            Console.Clear();

            while (true)
            {
                ResetGame();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                for (int i = 0; i < 5; i++)                //If this for was missing
                {
                    Console.WriteLine();
                }
                Console.SetWindowSize(85, 27);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Play"));        //Using basic formating, to be sure that everything is..
                Console.WriteLine();                                                                    //..in the center.
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Highscores"));
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Options"));
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Exit"));
                int startCol = 43;
                int positionUpDown = 5;  //I just had to guess the right cordinates for the pointer.I've written them on one row so you know that these are the coordinates.
                char arrowForMenu = (char)17; //The arrow for the menu.
                while (true)
                {
                    Console.CursorVisible = false; //This here is making sure that the arrow wont be flashin
                    Console.SetCursorPosition(startCol, positionUpDown);
                    Console.WriteLine(arrowForMenu);
                    Console.SetCursorPosition(startCol, positionUpDown);
                    ConsoleKeyInfo MenuArrowPosition = Console.ReadKey();
                    if (positionUpDown > 5 || positionUpDown <= 12)
                    {
                        if (MenuArrowPosition.Key == ConsoleKey.UpArrow)              //If up arrow is pressed the pointer goes down.
                        {
                            Console.SetCursorPosition(startCol, positionUpDown);
                            Console.WriteLine(" ");

                            positionUpDown -= 2;
                        }
                        else if (MenuArrowPosition.Key == ConsoleKey.DownArrow)       //If down arrow is pressed the pointer goes down.
                        {
                            Console.SetCursorPosition(startCol, positionUpDown);
                            Console.WriteLine(" ");
                            positionUpDown += 2;
                        }
                    }
                    if (positionUpDown < 5)  //Making sure that the arrow will not get too high.
                    {
                        positionUpDown = 11;
                    }
                    if (positionUpDown > 12) //Making sure that the arrow will not get too low.
                    {
                        positionUpDown = 5;
                    }
                    if (MenuArrowPosition.Key == ConsoleKey.Enter)   //This break here is making sure that we break to switch .
                    {
                        break;
                    }
                }

                try
                {
                    switch (positionUpDown - 4)
                    {
                        case 1:
                            Play(size[0], size[1]);
                            break;

                        case 3:
                            Highscores();
                            break;

                        case 5:
                            size = Options(size);
                            break;

                        case 7:
                            ExitConfirm();
                            break;

                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                }
            }
        }

        private static void Play(int width, int height) //Starts the game
        {
            int[] line = { 1, 1 }; // line {place of the hole, row of the line}
            int[] player = { x, y };

            while (true)
            {
                line = FallingLines(line);
                bonusPosition = BonusPosition(bonusPosition);
                char[,] board = new char[width, height];
                board = Board(board, line, playerPosition, bonusPosition);
                PlayerPosition(playerPosition);
                Level();
                StringBuilder renderer = new StringBuilder("");
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        renderer.Append(board[j, i]);
                    }

                    if (i == size[1] / 2 - 1)
                    {
                        if (gameNotOver)
                        {
                            renderer.Append("  Score: "); // Draws the score
                            renderer.Append(currentScore);
                        }
                        else
                        {
                            renderer.Append("  Final score: ");
                            renderer.Append(currentScore);
                        }
                    }
                    if ((i == size[1] / 2) && gameNotOver == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        renderer.Append("  GAME OVER! ");
                    }
                    if (i == size[1] / 2 + 1)
                    {
                        if (gameNotOver)
                        {
                            renderer.Append("  Level: "); // Draws the level
                            renderer.Append(level);
                        }
                        else
                        {
                            renderer.Append("  Press enter to continue... ");
                        }
                    }
                    renderer.Append("\n");
                }

                Console.Clear();
                Console.WriteLine(renderer);
                if (gameNotOver == false)
                {
                    while (true)
                    {
                        ConsoleKeyInfo userInput = Console.ReadKey();
                        if (userInput.Key == ConsoleKey.Enter)
                        {
                            WriteScores();
                            return;
                        }
                    }
                }
                Thread.Sleep(20);
            }
        }

        private static void PlayerPosition(int[] player) //Check for pressed key and changes player position
        {
            int[] newPlayerPosition = player;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    player[0]--;
                    if (player[0] < 1)
                        player[0]++;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    player[0]++;
                    if (player[0] > size[0] - 2)
                        player[0]--;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    player[1]--;
                    if (player[1] < 1)
                        player[1]++;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    player[1]++;
                    if (player[1] > size[1] - 2)
                        player[1]--;
                }
            }
            if (player[1] == lineHeight) // Check the position of the player according to the line
            {
                currentScore++;
            }
            if (player[0] == bonusPosition[0] && player[1] == bonusPosition[1]) // Update score when hitted bonus position
            {
                bonusSymbol = ' ';
                currentScore += 10;
            }
        }

        private static void Highscores() // Menu of the highscores
        {
            Console.Clear();
            Console.WriteLine("Highscores:");
            List<long> highScores = GetHighScores();
            List<string> names = GetHighScoreNames();
            for (int i = 0; i < highScores.Count; i++)
            {
                Console.WriteLine(string.Format("{0,2}. {1,8} - {2}", i + 1, names[i], highScores[i]));
            }
            Console.ReadLine();
        }

        private static char[,] Board(char[,] board, int[] line, int[] playerPosition, int[] bonusPosition) //Fills the game board
        {
            char characterFace = (char)1;
            try
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    board[i, 0] = '.';
                }
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    board[0, i] = '.';
                    board[board.GetLength(0) - 1, i] = '.';
                }
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    board[i, board.GetLength(1) - 1] = '.';
                }
                for (int i = 1; i < board.GetLength(0) - 1; i++)
                {
                    board[i, line[1]] = 'X';
                }
                board[line[0], line[1]] = ' ';
                board[playerPosition[0], playerPosition[1]] = characterFace;
                board[bonusPosition[0], bonusPosition[1]] = bonusSymbol;
                lineHeight = line[1]; // Check the position of the player according to the line
                if (playerPosition[1] == line[1] && playerPosition[0] != line[0]) //The death
                {
                    gameNotOver = false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Your given position is outside the bounds of the game field.");
                return null;
            }

            return board;
        }

        private static Random rnd = new Random();

        private static int[] FallingLines(int[] line) //Creates line position
        {
            if (updateLineCount == updateRate)
            {
                line[1]++;
                if (line[1] > size[1] - 2)
                {
                    line[1] = 1;
                    line[0] = rnd.Next(1, size[0] - 2);
                }
                updateLineCount = 0;
            }
            else
                updateLineCount++;
            return line;
        }

        private static int[] BonusPosition(int[] bonusPosition) // Returns the position of bonus points
        {
            if (updateBonusesCount == updateRate)
            {
                bonusPosition[1]++;
                if (bonusPosition[1] > size[1] - 2)
                {
                    bonusSymbol = '+';
                    bonusPosition[1] = 1;
                    bonusPosition[0] = rnd.Next(1, size[0] - 2);
                }
                updateBonusesCount = 0;
            }
            else
                updateBonusesCount++;
            return bonusPosition;
        }

        private static int[] Options(int[] size) //Game configuration options
        {
            //using to check if not correct data was entered
            bool isOutOfRange = false;

            while (true)
            {
                Console.Clear();
                if (isOutOfRange)
                {
                    Console.WriteLine("The provided width/height was not correct");
                }

                Console.WriteLine("Current width: {0}", size[0]);
                Console.WriteLine("Current height: {0}", size[1]);
                Console.WriteLine();
                Console.WriteLine("1. Change width");
                Console.WriteLine("2. Change height");
                Console.WriteLine("3. Save");
                Console.WriteLine();
                Console.Write("Choice: ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    Console.Write("Change to: ");
                    if (choice == 1)
                    {
                        int newWidth = int.Parse(Console.ReadLine());
                        // checking if the new width is in the range of the console
                        if (newWidth <= Console.WindowWidth && newWidth >= 0)
                        {
                            isOutOfRange = false;
                            size[0] = newWidth;
                        }
                        else
                        {
                            isOutOfRange = true;
                        }
                    }
                    else if (choice == 2)
                    {
                        int newHeight = int.Parse(Console.ReadLine());
                        // checking if the new height is in the range of the console
                        if (newHeight <= Console.WindowHeight && newHeight >= 0)
                        {
                            isOutOfRange = false;
                            size[1] = newHeight;
                        }
                        else
                        {
                            isOutOfRange = true;
                        }
                    }
                    else if (choice == 3)
                    {
                        x = size[0] / 2;
                        y = size[1] - 2;
                        playerPosition[0] = x;
                        playerPosition[1] = y;
                        bonusPosition[1] = size[1] / 2;
                        return size;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                }
            }
        }

        private static void ExitConfirm() //Asks the player if he's sure he wants to quit
        {
            Console.Clear();
            Console.WriteLine("Are you sure?");
            Console.WriteLine("1. Yes!");
            Console.WriteLine("2. No!");
            Console.Write("Enter choice: ");
            int exitChoice = int.Parse(Console.ReadLine());
            if (exitChoice == 1)
            {
                Environment.Exit(0);
            }
            else if (exitChoice == 2)
            {
                return;
            }
        }

        public static void WriteScores() //When the highscores change, writes them in the external file
        {
            Console.WriteLine("Enter name up to 8 symbols:");
            string playerName = Console.ReadLine();
            while (playerName.Length > 8)
            {
                Console.Clear();
                Console.WriteLine("Enter name up to 8 symbols:");
                playerName = Console.ReadLine();
            }
            const int maxRecordedScores = 10;

            List<long> highScores = GetHighScores();
            List<string> highScoreNames = GetHighScoreNames();

            long[] scores = new long[highScores.Count + 1];
            string[] names = new string[highScores.Count + 1];

            highScores.Add(currentScore);
            highScoreNames.Add(playerName);

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = highScores[i];
                names[i] = highScoreNames[i];
            }

            Array.Sort(scores, names);

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(File.Open(highScoresFile, FileMode.OpenOrCreate)))
            {
                if (scores.Length >= maxRecordedScores)
                {
                    for (int i = scores.Length - 1; i >= scores.Length - maxRecordedScores; i--)
                    {
                        file.WriteLine("{0,-8} - {1}", names[i], scores[i]);
                    }
                }
                else
                {
                    for (int i = scores.Length - 1; i >= 0; i--)
                    {
                        file.WriteLine("{0,-8} - {1}", names[i], scores[i]);
                    }
                }
                file.Flush();
            }
        }

        public static List<long> GetHighScores() //Used to read the highscores from the external file
        {
            string line;
            List<long> highScores = new List<long>();
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(File.Open(highScoresFile, FileMode.OpenOrCreate)))
            {
                line = file.ReadLine();
                while ((line != string.Empty) && (line != null))
                {
                    highScores.Add(long.Parse(line.Substring(10)));
                    line = file.ReadLine();
                }
            }
            return highScores;
        }

        private static List<string> GetHighScoreNames()
        {
            string line;
            List<string> names = new List<string>();
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(File.Open(highScoresFile, FileMode.OpenOrCreate)))
            {
                line = file.ReadLine();
                while ((line != string.Empty) && (line != null))
                {
                    names.Add(line.Substring(0, 8));
                    line = file.ReadLine();
                }
            }
            return names;
        }

        private static void Level() //Changes the speed of the lines according to the current score
        {
            level = currentScore / 1000;
            if (level > 5)
            {
                level = 5;
            }
            updateRate = 10 - level;
        }

        private static void ResetGame() //Used to reset scores, positions, levels, etc. when the game is over
        {
            board = new char[size[0], size[1]];
            x = size[0] / 2;
            y = size[1] - 2;
            updateRate = 10;
            updateLineCount = 0;
            updateBonusesCount = 0;
            playerPosition[0] = x;
            playerPosition[1] = y;
            currentScore = 0;
            lineHeight = 0;
            gameNotOver = true;
            bonusPosition[1] = size[1] / 2;
            bonusPosition[0] = 1;
            level = 0;
            bonusSymbol = '+';
        }
    }
}
namespace SnakeGame
{
    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            #region Vars
            int[] xPosition = new int[50];
            xPosition[0] = 35;
            int[] yPosition = new int[50];
            yPosition[0] = 20;
            int appleXDim = 10;
            int appleYDim = 10;
            int eatenApples = 0;

            string userAcion = "";

            decimal gameSpeed = 150m;

            bool gameIsOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;
            
            Random random = new Random();

            Console.CursorVisible = false;

            ShowMenu(out userAcion);
            switch (userAcion)
            {
                case "1":
                case "p":
                case "play":
                    break;

                case "2":
                case "e":
                case "exit":
                    System.Environment.Exit(0);
                    break;
                    
                default:
                    Console.WriteLine("Your input was not understood, please press enter and try again.");
                    Console.ReadLine();
                    Console.Clear();
                    ShowMenu(out userAcion);
                    break;
            }

            #endregion

            #region Game Setup
            PaintSnake(eatenApples, xPosition, yPosition, out xPosition, out yPosition);

            SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
            PaintTheApple(appleXDim, appleYDim);
            BuildBoundries();

            ConsoleKey command = Console.ReadKey().Key;
            #endregion


            do
            {
                #region Change Directions
                switch (command)
                {

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;

                }
                #endregion

                #region Playing The Game
                PaintSnake(eatenApples, xPosition, yPosition, out xPosition, out yPosition);
                
                
                isWallHit = DidSnakeHitTheWall(xPosition[0], yPosition[0]);

                if (isWallHit)
                {
                    gameIsOn = false;
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("The snake hit the wall and died");

                }

                isAppleEaten = CheckIfAppleIsEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

                if (isAppleEaten)
                {
                    SetApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    PaintTheApple(appleXDim, appleYDim);
                    eatenApples++;
                    gameSpeed *= .925m;
                }
                
                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }

                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
                #endregion

            } while (gameIsOn);


        }

        #region Game Menu
        private static void ShowMenu(out string userAcion)
        {
            string firstMenu = "1)Play\n2) Exit \n\n\n" + @"

              ``.--.`                                                         
          `:osyooyyyys/.                                                      
          `-:/++osyyhhhh/                                             
                   .:ohddo`       `-oyyyyyyys:`                        
                      ./ydh+-.`../yyo::----::os/.`     `-os+//::://oo/`           
                        -+dmmdhdmdo/:`       `-ohyssosshy/-`````'' `-/so-`        
                         :ydmmhs/+           `:oyhhhy+.`           `./sys+:::/+.
                          .:/://-                -/osys+-`                                                                               
                                                                               ";
           
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(firstMenu); System.Threading.Thread.Sleep(2000); Console.Clear();
           
            userAcion = Console.ReadLine().ToLower();
        }
        #endregion
        #region Methods
        private static void PaintSnake(int eatenApples, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            //paint the head
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("o");
            //paint the body
            for (int i = 1; i < eatenApples + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O");// check if here and if not, put o
            }
            //erase last part of snake
            Console.SetCursorPosition(xPositionIn[eatenApples + 1], yPositionIn[eatenApples + 1]);
            Console.WriteLine(" ");

            //record location of each body part
            for (int i = eatenApples + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            //return the new array;
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }

        private static void SetApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(2, 69);
            appleYDim = random.Next(2, 38);
        }

        private static bool DidSnakeHitTheWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40)
            {
                return true;
            }
            return false;
        }

        private static void BuildBoundries()
        {
            for (int i = 1; i < 40; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");
            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }

        private static void PaintTheApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool CheckIfAppleIsEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

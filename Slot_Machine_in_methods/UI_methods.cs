namespace Slot_Machine_in_methods
{
    public static class UI_methods
    {
        public static void DisplayingRoolsForUser()
        {
            Console.WriteLine("Welcome to the slot mashine");
            Console.WriteLine();
            Console.WriteLine("The rools to the game:");
            Console.WriteLine("1. Add your game money amount in $ USD");
            Console.WriteLine("2. Choose how many lines you would like to play.");
            Console.WriteLine("3. One line cost 1$ per game");
            Console.WriteLine("4. More lines yyou choosee more chance to win!");
            Console.WriteLine("5. Options to choose for the lines:  \n\t" +
                "1. Center Line.\n\t" +
                "2. All horizontal lines.\n\t" +
                "3. All vertical lines.\n\t" +
                "4. Diagonals.");
            Console.WriteLine("Good luck!");
        }

        public static int UsersGameMoneyFromInput()
        {
            while (true)
            {
                try  // ask to tell more about this, copied code!
                {
                    Console.WriteLine("Add your amount of game money in USD $");
                    int playersGameMoney = int.Parse(Console.ReadLine()); // Converting input to int directly, because later it will be used only as int
                    return playersGameMoney;
                }
                catch (Exception) // ask to tell more about this, copied code!
                {
                    Console.WriteLine("That wasn't a number.");
                    continue;
                }
            }

        }

        public static int[,] CreateArrayWithRandomNumbers()
        {
            Random randomNumbersGenerator = new Random(); // random numbers function
            int[,] array2Dimmensional = new int[3, 3];  // columns and lines of the grid

            for (int rows = 0; rows < 3; rows++) //populating 2D Array. for every row for loop is adding three columns and random numbers to it
            {
                for (int columns = 0; columns < 3; columns++)
                {
                    array2Dimmensional[rows, columns] = randomNumbersGenerator.Next(0, 10); // attributing random numbers to every row and column. 10 is not including
                }
            }
            return array2Dimmensional;
        }

        public static void Print2DArray(int[,] array2Dimmensional)
        {
            for (int rows = 0; rows < array2Dimmensional.GetLength(0); rows++) // getting the length of rows and columns from array2Dimmensional = new int[3, 3];
                                                                               // GetLength(0) means first number in 2 dimensional array like in here is "3"
                                                                               // GetLength(1) means second number in 2 dimensional array like in here is "3"
            {
                for (int columns = 0; columns < array2Dimmensional.GetLength(1); columns++)
                {
                    Console.Write($" {array2Dimmensional[rows, columns]}"); // printing out the grid 
                }
                Console.WriteLine(); // empty place
            }
        }

        public static int UsersChosedOption()
        {
            while (true)
            {
                try  // ask to tel more about this, copied code!
                {
                    Console.WriteLine("Choose how many lines you will play by typing in number of the menu:");
                    Console.WriteLine("\n\t1 - Center Line. One turn 1$\n\t2 - All horizontal lines. One turn 3$\n\t3 - All vertical lines. One turn 3$\n\t4 - Diagonals. One turn 2$");

                    int playersChoseOptionToPLay = int.Parse(Console.ReadLine()); // Converting input to int directly, because later it will be used only as int
                    return playersChoseOptionToPLay;                                                         // add while loop until the player has money                                                                             
                }
                catch (Exception) // ask to tel more about this, copied code!
                {
                    Console.WriteLine("That wasn't a number.");
                    continue;
                }
            }
        }

        public static bool CheckIfPlayerHasMoney(int num1, int num2)
        {
            if (num1 == 1 && num2 < 1 ||
                num1 == 2 && num2 < 3 ||
                num1 == 3 && num2 < 3 ||
                num1 == 4 && num2 < 2)
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfChosedOptionHigherThanFour(int num1)
        {
            if (num1 > 4)
            {
                return true;
            }
            return false;
        }

        public static void InformUserAboutWrongOption(int num1)
        {
            Console.WriteLine($"There is no Option with number {num1}");
        }

        public static void PrintUserMoneyBalanceTooLow()
        {
            Console.WriteLine("Your current balance is too low! Choose another option!");
        }

        public static void InformUserAboutWinAndLoses(int num1)
        {
            if (num1 < 1)
            {
                Console.WriteLine("You lost! Try again!");

            }
            else
            {
                Console.WriteLine($"You won {num1} dollars");
            }
        }

        public static int CoutnWinAndLoses(int[,] array2Dimmensional, int playersChoseOptionToPLay, int playersGameMoney)
        {
            int fColFLine = array2Dimmensional[0, 0]; // getting numbers from 2D array 
            int sColFLine = array2Dimmensional[0, 1];
            int tColFLine = array2Dimmensional[0, 2];
            int fColSLine = array2Dimmensional[1, 0];
            int sColSLine = array2Dimmensional[1, 1];
            int tColSLine = array2Dimmensional[1, 2];
            int fColTLine = array2Dimmensional[2, 0];
            int sColTLine = array2Dimmensional[2, 1];
            int tColTLine = array2Dimmensional[2, 2];

            // boolean for if statements with horizontal lines

            bool firstLineH = fColFLine == sColFLine && sColFLine == tColFLine;
            bool secondLineH = fColSLine == sColSLine && sColSLine == tColSLine;
            bool thirdLineH = fColTLine == sColTLine && sColTLine == tColTLine;

            // boolean for if statements with vertical lines

            bool firstColumnV = fColFLine == fColSLine && fColSLine == fColTLine;
            bool secondColumnV = sColFLine == sColSLine && sColSLine == sColTLine;
            bool thirdColumnV = tColFLine == tColSLine && tColSLine == tColTLine;

            // boolean for diagonals

            bool diagonalDown = fColFLine == sColSLine && sColSLine == tColTLine;
            bool diagonalUp = fColTLine == sColSLine && sColSLine == tColFLine;

            // IF statements for every option

            Console.WriteLine(); // empty line

            int winAmount = 0;

            if (playersChoseOptionToPLay == 1 && playersGameMoney > 0) // player chose 1st option and player must have 1 dollar to play this line
            {
                if (secondLineH) // to get this true, all numbers in the middle line in the grid must match
                {
                    winAmount = 2; // adding 2 dollars to current balance for user
                }
                else
                {
                    winAmount--; // taking 1 dollar from current balance because player lost 
                }
            }
            else if (playersChoseOptionToPLay == 2 && playersGameMoney > 2) // player chose 2st option and player must have 3 dollars to play this line
            {
                if (firstLineH && secondLineH && thirdLineH) // Most unlikely wining condition on the top to avoid other conditions will break the code
                {
                    winAmount = 6;

                }
                else if (firstLineH && secondLineH || firstLineH && thirdLineH || secondLineH && thirdLineH)
                {
                    winAmount = 4;
                }
                else if (firstLineH | secondLineH | thirdLineH)
                {
                    winAmount = 2;
                }
                else
                {
                    winAmount -= 3;
                }
            }
            else if (playersChoseOptionToPLay == 3 && playersGameMoney > 2)
            {
                // here player plays with columns instead of lines
                if (firstColumnV && secondColumnV && thirdColumnV)
                {
                    winAmount = 6;
                }
                else if (firstColumnV && secondColumnV || firstColumnV && thirdColumnV || secondColumnV && thirdColumnV)
                {
                    winAmount = 4;
                }
                else if (firstColumnV | secondColumnV | thirdColumnV)
                {
                    winAmount = 4;
                }
                else
                {
                    winAmount -= 3;
                }
            }
            else if (playersChoseOptionToPLay == 4 && playersGameMoney > 1)
            {
                if (diagonalDown && diagonalUp)
                {
                    winAmount = 4;
                }
                else if (diagonalDown || diagonalUp)
                {
                    winAmount = 2;
                }
                else
                {
                    winAmount -= 2;
                }
            }
            return winAmount;
        }

        public static int SumUpWinsAndLoses(int num1, int num2)
        {
            int num3 = num1 + num2;
            return num3;
        }

        public static void PrintTheBalance(int num2)
        {
            Console.WriteLine($"Your acount balance now is: {num2} dollars");
            return;
        }

        public static void YouLostMessage()
        {
            Console.WriteLine("You lost! Try again!");
        }

        public static void YouWonMoneyMessage(int countedWinsLoses)
        {
            Console.WriteLine($"You won {countedWinsLoses} dollars");
        }
    }
}


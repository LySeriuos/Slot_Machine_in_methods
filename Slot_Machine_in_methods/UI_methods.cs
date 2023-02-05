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

        //public static int[,] CreateArrayWithRandomNumbers(int array2Dimmensional)
        //{
        //    Random randomNumbersGenerator = new Random(); // random numbers function
        //    int[,] array2Dimmensional = new int[3, 3];  // columns and lines of the grid

        //    for (int rows = 0; rows < 3; rows++) //populating 2D Array. for every row for loop is adding three columns and random numbers to it
        //    {
        //        for (int columns = 0; columns < 3; columns++)
        //        {
        //            array2Dimmensional[rows, columns] = randomNumbersGenerator.Next(0, 10); // attributing random numbers to every row and column. 10 is not including
        //            return array2Dimmensional;
        //        }
        //    }
        //}

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
                    Console.WriteLine("Choose how many lines you will play by typing in number of the menu");
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
    }
}


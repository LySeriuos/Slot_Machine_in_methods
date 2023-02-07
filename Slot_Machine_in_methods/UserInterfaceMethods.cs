namespace Slot_Machine_in_methods
{
    public static class UserInterfaceMethods
    {
        /// <summary>
        /// UI method to print out all the game rools to the screen
        /// </summary>
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
        /// <summary>
        /// Talking in user input as gameMoney and checking if the input is number or is not equal to zero
        /// </summary>
        /// <returns>int gameMoney from valid user input</returns>
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
        /// <summary>
        /// Talking in user input as chosed game Option from the menu and checking if the input is number or is not equal to zero
        /// </summary>
        /// <returns>int playersChoseOptionToPLay from valid user input</returns>
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
        /// <summary>
        /// taking user input as num1 and printing out error message after user's chosed option not exist
        /// </summary>
        /// <param name="num1">int playersChoseOptionToPLay used as parameter to method</param>
        public static void InformUserAboutWrongOption(int num1)
        {
            Console.WriteLine($"There is no Option with number {num1}");
        }

        /// <summary>
        /// Printing error message to inform that game money is not enough to play chosed option
        /// </summary>
        public static void PrintUserMoneyBalanceTooLow()
        {
            Console.WriteLine("Your current balance is too low! Choose another option!");
        }

        /// <summary>
        /// Printing out game money balance to user
        /// </summary>
        /// <param name="num2">int playersGameMoney used as parameter to method</param>
        public static void PrintTheBalance(int num2)
        {
            Console.WriteLine($"Your acount balance now is: {num2} dollars");
            return;
        }

        /// <summary>
        /// Printing out message to inform user that he lost
        /// </summary>
        public static void YouLostMessage()
        {
            Console.WriteLine("You lost! Try again!");
        }

        /// <summary>
        /// Printing out message with user winnings 
        /// </summary>
        /// <param name="num3">Taking winAmount as parameter</param>
        public static void YouWonMoneyMessage(int num3)
        {
            Console.WriteLine($"You won {num3} dollars");
        }
    }
}


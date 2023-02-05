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
                    int num1 = int.Parse(Console.ReadLine()); // Converting input to int directly, because later it will be used only as int
                    return num1;
                }
                catch (Exception) // ask to tell more about this, copied code!
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


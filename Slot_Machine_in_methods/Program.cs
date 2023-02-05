using Slot_Machine_in_methods;

namespace The_slot_machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Plan for the slot machine code:
            // 1. Instructions for game play.

            UserInterfaceMethods.DisplayingRoolsForUser();
            Console.WriteLine();

            // 2. Choose option for bidding (player adds amount to play $). 

            // User's inputs variables
            int playersGameMoney;
            int playersChoseOptionToPLay;

            // looping until user's input is 0. 
            while (true)
            {
                playersGameMoney = UserInterfaceMethods.UsersGameMoneyFromInput();
                Console.WriteLine();

                while (playersGameMoney > 0 && playersGameMoney < 101)
                {
                    playersChoseOptionToPLay = UserInterfaceMethods.UsersChosedOption();

                    bool hasNoMoney = LogicMethods.CheckIfPlayerHasMoney(playersChoseOptionToPLay, playersGameMoney);
                    if (hasNoMoney)
                    {
                        UserInterfaceMethods.PrintUserMoneyBalanceTooLow();
                        continue;
                    }
                    else if (LogicMethods.CheckIfChosedOptionHigherThanFour(playersChoseOptionToPLay))
                    {
                        UserInterfaceMethods.InformUserAboutWrongOption(playersChoseOptionToPLay);
                        continue;
                    }

                    // 3. Create and output Random Numbers machine (slot machine).

                    int[,] array2Dimmensional = LogicMethods.CreateArrayWithRandomNumbers();

                    Console.WriteLine();

                    LogicMethods.Print2DArray(array2Dimmensional);

                    // 4. Create if statements to see if he wants to play combination of (vertical lines, horizontal lines, only center line, two horizontal lines...)
                    // variables for booleans and positions of each object in the grid

                    int winAmount = LogicMethods.CoutnWinAndLoses(array2Dimmensional, playersChoseOptionToPLay, playersGameMoney);
                    Console.WriteLine();

                    if (winAmount < 1)
                    {
                        UserInterfaceMethods.YouLostMessage();
                    }
                    else
                    {
                        UserInterfaceMethods.YouWonMoneyMessage(winAmount);
                    }

                    playersGameMoney += winAmount; // adding wins or extracting loses from the main game money balance

                    UserInterfaceMethods.PrintTheBalance(playersGameMoney);
                    Console.WriteLine();
                }

            }
        }
    }
}
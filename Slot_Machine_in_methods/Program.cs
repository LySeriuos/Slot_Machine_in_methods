using Slot_Machine_in_methods;

namespace The_slot_machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Plan for the slot machine code:
            // 1. Instructions for game play.

            UI_methods.DisplayingRoolsForUser();

            // 2. Choose option for bidding (player adds amount to play $). 

            // User's inputs variables
            int playersGameMoney;
            int playersChoseOptionToPLay;

            // looping until user's input is 0. 
            while (true)
            {
                playersGameMoney = UI_methods.UsersGameMoneyFromInput();

                while (playersGameMoney > 0 && playersGameMoney < 101)
                {
                    playersChoseOptionToPLay = UI_methods.UsersChosedOption();

                    bool hasNoMoney = UI_methods.CheckIfPlayerHasMoney(playersChoseOptionToPLay, playersGameMoney);
                    if (hasNoMoney)
                    {
                        UI_methods.PrintUserMoneyBalanceTooLow();
                        continue;
                    }
                    else if (UI_methods.CheckIfChosedOptionHigherThanFour(playersChoseOptionToPLay))
                    {
                        UI_methods.InformUserAboutWrongOption(playersChoseOptionToPLay);
                        continue;
                    }

                    // 3. Create and output Random Numbers machine (slot machine).

                    int[,] array2Dimmensional = UI_methods.CreateArrayWithRandomNumbers();

                    Console.WriteLine();

                    UI_methods.Print2DArray(array2Dimmensional);

                    // 4. Create if statements to see if he wants to play combination of (vertical lines, horizontal lines, only center line, two horizontal lines...)
                    // variables for booleans and positions of each object in the grid

                    int winAmount = UI_methods.CoutnWinAndLoses(array2Dimmensional, playersChoseOptionToPLay, playersGameMoney);

                    if (winAmount < 1)
                    {
                        UI_methods.YouLostMessage();
                    }
                    else
                    {
                        UI_methods.YouWonMoneyMessage(winAmount);
                    }

                    playersGameMoney += winAmount; // adding wins or extracting loses from the main game money balance

                    UI_methods.PrintTheBalance(playersGameMoney);
                }

            }
        }
    }
}
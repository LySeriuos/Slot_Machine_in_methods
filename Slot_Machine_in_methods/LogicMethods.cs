namespace Slot_Machine_in_methods
{
    public class LogicMethods
    {
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
    }
}

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
                try  // ask to tell more about this, copied code!
                {
                    playersGameMoney = UI_methods.UserGameMoney("Add your amount of game money in USD $");
                }
                catch (Exception) // ask to tell more about this, copied code!
                {
                    Console.WriteLine("That wasn't a number.");
                    continue;
                }

                while (playersGameMoney > 0 && playersGameMoney < 101)
                {
                    try  // ask to tel more about this, copied code!
                    {
                        Console.WriteLine("Choose how many lines you will play by typing in number of the menu");
                        Console.WriteLine("\n\t1 - Center Line. One turn 1$\n\t2 - All horizontal lines. One turn 3$\n\t3 - All vertical lines. One turn 3$\n\t4 - Diagonals. One turn 2$");

                        playersChoseOptionToPLay = int.Parse(Console.ReadLine()); // Converting input to int directly, because later it will be used only as int
                                                                                  // add while loop until the player has money
                                                                                  // 3. Create 2D array for random numbers.
                    }
                    catch (Exception) // ask to tel more about this, copied code!
                    {
                        Console.WriteLine("That wasn't a number.");
                        continue;
                    }

                    bool result = UI_methods.CheckIfPlayerHasMoney(playersChoseOptionToPLay, playersGameMoney);
                    if (result)
                    {
                        continue;
                    }

                    Random randomNumbersGenerator = new Random(); // random numbers function
                    int[,] array2Dimmensional = new int[3, 3];  // columns and lines of the grid

                    for (int rows = 0; rows < 3; rows++) //populating 2D Array. for every row for loop is adding three columns and random numbers to it
                    {
                        for (int columns = 0; columns < 3; columns++)
                        {
                            array2Dimmensional[rows, columns] = randomNumbersGenerator.Next(0, 10); // attributing random numbers to every row and column. 10 is not including
                        }
                    }

                    // 4. Create and output Random Numbers machine (slot machine).

                    Console.WriteLine();

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


                    // 5. Create if statements to see if he wants to play combination of (vertical lines, horizontal lines, only center line, two horizontal lines...)
                    // variables for booleans and positions of each object in the grid

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

                    if (winAmount < 1)
                    {
                        Console.WriteLine("You lost! Try again!");
                    }
                    else
                    {
                        Console.WriteLine($"You won {winAmount} dollars");
                    }

                    // all the repeated code

                    playersGameMoney = playersGameMoney + winAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Your acount balance now is: {playersGameMoney} dollars");
                }

            }
        }
    }
}
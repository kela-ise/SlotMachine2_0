using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine2_0
{
    public static class UI
    {
        public static void DisplayWelcomeMessage(int budget)
        {
            Console.WriteLine("\nThis is a Slot Machine Game!");
            // Console.WriteLine($"You have ${budget} in your account");
        }

        public static int GetWager(int budget)
        {
            int wager;
            Console.Write($"You have ${budget}, Enter your wager amount (Minimum: ${Constant.MIN_WAGER}): ");
            while (!int.TryParse(Console.ReadLine(), out wager) || wager < Constant.MIN_WAGER || wager > budget) // use TryParse to convert user input into an integer
            {
                Console.Write($"Enter an amount within budget ${budget}: ");
            }
            return wager;
        }

        public static int GetSpinCheckMode()
        {
            int checkSpin;
            Console.Write(Constant.MessageForSpinCheckMode);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out checkSpin) && checkSpin >= Constant.CENTER_MODE && checkSpin <= Constant.DIAGONAL_MODE)
                    return checkSpin; // Valid input, return the value

                Console.WriteLine(Constant.InvalidChoiceMessage);
            }
        }

        public static void DisplaySlotGrid(int[,] slotGrid)
        {
            for (int rows = 0; rows < Constant.SLOT_ROWS; rows++) // iterate through rows & columns to assign & print random numbers
            {
                for (int cols = 0; cols < Constant.SLOT_COLUMNS; cols++)
                {
                    Console.Write(slotGrid[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int DisplayResult(bool checkWin, int wager, int budget)
        {
            if (checkWin)
            {
                int winnings = wager + Constant.BUDGET_INCREMENTER;
                budget += winnings;
                Console.WriteLine($"There's a match. You Won ${winnings}");
            }
            else
            {
                Console.WriteLine("No match found");
            }
            Console.WriteLine($"Your remaining budget: ${budget}");
            return budget; // Return updated budget
        }

        public static bool AskToContinue()
        {
            Console.Write("\nEnter 'Y' to continue playing or anything else to end game: ");  // Ask if the player wants to continue playing
            string response = Console.ReadLine().ToUpper();
            return response == "Y";
        }

        public static void DisplayGameOver()
        {
            Console.WriteLine("\nGame Over! You're out of money");
        }
    }
}


namespace SlotMachine2_0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int budget = Constant.INITIAL_BUDGET;   // Player's initial budget
            Random random = new Random(); // Random number generator for slot machine spins
            int[,] slotGrid = new int[Constant.SLOT_ROWS, Constant.SLOT_COLUMNS]; // 3x3 grid representing the slot machine

            while (true) // Keep the game running
            {
                UI.DisplayWelcomeMessage(budget);
                int wager = UI.GetWager(budget);
                budget -= wager; // Deduct wager from budget

                int checkSpin = UI.GetSpinCheckMode();

                Logic.GenerateSlotGrid(slotGrid, random);
                UI.DisplaySlotGrid(slotGrid);

                bool checkWin = Logic.CheckWin(slotGrid, checkSpin);
                budget = UI.DisplayResult(checkWin, wager, budget); // Assign returned budget

                if (budget < Constant.MIN_WAGER)
                {
                    UI.DisplayGameOver();
                    break; // Exit loop/game when budget is < 1(MIN_WAGER)
                }

                if (!UI.AskToContinue())
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlotMachine2_0
{
    internal class Logic
    {
        // Method to generate the slot grid with random values
        public static void GenerateSlotGrid(int[,] slotGrid, Random random)
        {
            for (int rows = 0; rows < Constant.SLOT_ROWS; rows++) // iterate through rows & columns to assign & print random numbers
            {
                for (int cols = 0; cols < Constant.SLOT_COLUMNS; cols++)
                {
                    slotGrid[rows, cols] = random.Next(Constant.LOWER_LIMIT, Constant.UPPER_LIMIT + Constant.UPPER_LIMIT_INCREMENTER);
                }
            }
        }

        /// <summary> Checks if the player has won based on the selected spin mode. </summary>
        /// <param name="slotGrid">A 2D array representing the slot machine grid with randomly generated values.</param>
        /// <param name="checkSpin">An integer representing the spin mode selected by the player. It can be one of the following:  </param>
        /// <returns> Returns true if a win is detected based on the selected mode, otherwise returns false. </returns>
        public static bool CheckWin(int[,] slotGrid, int checkSpin)
        {
            if (checkSpin == Constant.CENTER_MODE)
                return CenterMode(slotGrid);
            else if (checkSpin == Constant.VERTICAL_MODE)
                return VerticalMode(slotGrid);
            else if (checkSpin == Constant.HORIZONTAL_MODE)
                return HorizontalMode(slotGrid);
            else if (checkSpin == Constant.DIAGONAL_MODE)
                return DiagonalMode(slotGrid);

            return false;
        }
        public static bool CenterMode(int[,] slotGrid)   // Method to check for win in Center Mode
        {
            bool checkWin = true;
            int centerRow = Constant.SLOT_ROWS / 2;
            for (int col = 1; col < Constant.SLOT_COLUMNS; col++)
            {
                if (slotGrid[centerRow, col] != slotGrid[centerRow, Constant.COLUMN_ONE])
                {
                    checkWin = false;
                    break;
                }
            }
            return checkWin;
        }
        public static bool VerticalMode(int[,] slotGrid)   // Method to check for win in Vertical Mode
        {
            bool checkWin = false;
            for (int col = 0; col < Constant.SLOT_COLUMNS; col++)
            {
                bool columnMatch = true;
                for (int row = 1; row < Constant.SLOT_ROWS; row++)
                {
                    if (slotGrid[row, col] != slotGrid[Constant.ROW_ONE, col])
                    {
                        columnMatch = false;
                        break;
                    }
                }
                if (columnMatch)
                {
                    checkWin = true;
                    break;
                }
            }
            return checkWin;
        }


        public static bool HorizontalMode(int[,] slotGrid) // Method to check for win in Horizontal Mode
        {
            bool checkWin = false;
            for (int row = 0; row < Constant.SLOT_ROWS; row++)
            {
                bool rowMatch = true;
                for (int col = 1; col < Constant.SLOT_COLUMNS; col++)
                {
                    if (slotGrid[row, Constant.COLUMN_ONE] != slotGrid[row, col])
                    {
                        rowMatch = false;
                        break;
                    }
                }
                if (rowMatch)
                {
                    checkWin = true;
                    break;
                }
            }
            return checkWin;
        }

        /// <summary>
        /// Checks for a win in Diagonal Mode by comparing the values of the two diagonals in the slot grid.
        /// </summary>
        /// <param name="slotGrid">A 2D array representing the slot machine grid with randomly generated values.</param>
        /// <returns>
        /// Returns true if either the main diagonal or the anti-diagonal has matching values across all rows, otherwise returns false.
        /// </returns>
        public static bool DiagonalMode(int[,] slotGrid)   // Method to check for win in Diagonal Mode
        {
            bool diagonalMatch1 = true;
            bool diagonalMatch2 = true;

            for (int i = 1; i < Constant.SLOT_ROWS; i++) // Iterate through the diagonals
            {
                if (slotGrid[i, i] != slotGrid[Constant.ROW_ONE, Constant.COLUMN_ONE]) // Check main diagonal
                    diagonalMatch1 = false;

                if (slotGrid[i, Constant.SLOT_COLUMNS - i - Constant.INDEX_OFFSET] != slotGrid[Constant.ROW_ONE, Constant.SLOT_COLUMNS - Constant.INDEX_OFFSET]) // Check anti-diagonal
                    diagonalMatch2 = false;
            }

            return diagonalMatch1 || diagonalMatch2; // Return true if either diagonal matches, else false
        }
    }
}

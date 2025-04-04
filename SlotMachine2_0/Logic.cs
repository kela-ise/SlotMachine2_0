using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine2_0
{
    public static class Logic
    {
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

        public static bool CheckWin(int[,] slotGrid, int checkSpin)
        {
            int centerRow = Constant.SLOT_ROWS / 2;  // Dynamically calculate middle row index
            bool checkWin = true;

            if (checkSpin == Constant.CENTER_MODE) // Check if the player selected center row check
            {
                for (int col = 1; col < Constant.SLOT_COLUMNS; col++)
                {
                    if (slotGrid[centerRow, col] != slotGrid[centerRow, Constant.COLUMN_ONE]) // Compare with the first column of the center row
                    {
                        checkWin = false;
                        break;
                    }
                }
            }
            else if (checkSpin == Constant.VERTICAL_MODE) // Check Vertical Mode for all columns
            {
                checkWin = false;
                for (int col = 0; col < Constant.SLOT_COLUMNS; col++) // Iterate through all columns
                {
                    bool columnMatch = true;
                    for (int row = 1; row < Constant.SLOT_ROWS; row++) // Check each row in the column
                    {
                        if (slotGrid[row, col] != slotGrid[Constant.ROW_ONE, col]) // Compare with the first row
                        {
                            columnMatch = false;
                            break;
                        }
                    }
                    if (columnMatch) // If any column matches, set checkWin to true
                    {
                        checkWin = true;
                        break;
                    }
                }
            }
            else if (checkSpin == Constant.HORIZONTAL_MODE) // Check Horizontal Mode
            {
                checkWin = false;
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
            }
            else if (checkSpin == Constant.DIAGONAL_MODE) // Check diagonal mode
            {
                bool diagonalMatch1 = true;
                bool diagonalMatch2 = true;

                for (int i = 1; i < Constant.SLOT_ROWS; i++)
                {
                    if (slotGrid[i, i] != slotGrid[Constant.ROW_ONE, Constant.COLUMN_ONE])
                        diagonalMatch1 = false;
                    if (slotGrid[i, Constant.SLOT_COLUMNS - i - Constant.INDEX_OFFSET] != slotGrid[Constant.ROW_ONE, Constant.SLOT_COLUMNS - 1])
                        diagonalMatch2 = false;
                }

                checkWin = diagonalMatch1 || diagonalMatch2;
            }

            return checkWin;
        }
    }
}

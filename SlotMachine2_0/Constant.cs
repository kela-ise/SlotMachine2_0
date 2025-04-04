using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine2_0
{
    public static class Constant
    {

        public const int SLOT_ROWS = 3;
        public const int SLOT_COLUMNS = 3;
        public const int LOWER_LIMIT = 1;
        public const int UPPER_LIMIT = 3;
        public const int CENTER_MODE = 1;
        public const int BUDGET_INCREMENTER = 2;
        public const int UPPER_LIMIT_INCREMENTER = 1;
        public const int MIN_WAGER = 1;
        public const int INITIAL_BUDGET = 20;
        public const int VERTICAL_MODE = 2;
        public const int HORIZONTAL_MODE = 3;
        public const int DIAGONAL_MODE = 4;
        public const int COLUMN_ONE = 0;
        public const int ROW_ONE = 0;
        public const int INDEX_OFFSET = 1;

        public static string InvalidChoiceMessage = $"Invalid choice. Please enter a number between {CENTER_MODE} and {DIAGONAL_MODE}.";
        public static string MessageForSpinCheckMode = $"Enter a number to check spin. {CENTER_MODE}: Center, {VERTICAL_MODE}: Vertical, {HORIZONTAL_MODE}: Horizontal, {DIAGONAL_MODE}: Diagonal: ";
    }
}

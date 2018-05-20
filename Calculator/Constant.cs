using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator
{
    class Constant
    {
        public static Key[] OPERATION_KEY =
        {
            Key.OemMinus, Key.F9, Key.OemQuestion
        };

        public static Key[] INITIALIZATION_KEY =
        {
            Key.Escape, Key.Delete, Key.Enter, Key.OemPlus, Key.Back
        };

        public static string[] INITIALIZING_KEY =
        {
            "CE",
            "C",
            "backspace",
            "equal"
        };

        public static string[] NUMBER_KEY =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "dot"
        };

        public static string[] OPERATION =
        {
            "÷",
            "×",
            "-",
            "+",
            "negate"
        };

        public const int INITIALIZER = 0;
        public const int OPERATOR = 1;
        public const int NUMBER = 2;

        public const int DEVISION = 0;
        public const int MULTIPLICATION = 1;
        public const int SUBTRACTION = 2;
        public const int ADDTION = 3;
        public const int NEGATE = 4;
        
        public const int CE = 0;
        public const int C = 1;
        public const int BACKSPACE = 2;
        public const int EQUAL = 3;

        public const int MINUS = 143;
        public const int F9 = 98;
        public const int OEM_QUESTION = 145;

        public const int ESCAPE = 13;
        public const int DELETE = 32;
        public const int ENTER = 6;
        public const int OEM_PLUS = 141;
        public const int BACK = 2;

        public static Color BUTTON_COLOR = (Color)ColorConverter.ConvertFromString("#FFDDDDDD");
    }
}

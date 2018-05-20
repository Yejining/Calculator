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
            Key.OemMinus, Key.OemPlus, Key.F9, Key.OemQuestion, Key.D8
        };

        public static Key[] INITIALIZATION_KEY =
        {
            Key.Escape, Key.Delete, Key.Enter, Key.OemPlus
        };

        public static string[] NUMBER =
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

        public const int DEVISION = 0;
        public const int MULTIPLICATION = 1;
        public const int SUBTRACTION = 2;
        public const int ADDTION = 3;
        public const int NEGATE = 4;

        public static Color BUTTON_COLOR = (Color)ColorConverter.ConvertFromString("#FFDDDDDD");
    }
}

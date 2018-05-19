using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Calculator
{
    class Constant
    {
        public static Key[] OPERATION_KEYS =
        {
            Key.OemMinus, Key.OemPlus, Key.F9, Key.OemQuestion, Key.Escape, Key.Enter
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
            "nine"
        };
    }
}

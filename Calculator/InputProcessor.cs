using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Calculator
{
    class InputProcessor
    {
        private Pad pad;

        public void keyUp(object sender, KeyEventArgs e)
        {
            if (IsNumberKey(e.Key))
            {
                pad.PressKey((int)e.Key.GetHashCode() - 34);
                Calculation.AddNumber((int)e.Key.GetHashCode() - 34);
            }
        }

        public void SetPad(Pad pad)
        {
            this.pad = pad;
        }

        public bool IsNumberKey(Key key)
        {
            if (key >= Key.D0 && key <= Key.D9)
                return true;
            else
                return false;
        }

        public bool IsSymbolKey(Key key)
        {
            foreach (Key symbol in Constant.OPERATION_KEYS)
            {
                if (key == symbol)
                    return true;
            }

            return false;
        }
    }
}

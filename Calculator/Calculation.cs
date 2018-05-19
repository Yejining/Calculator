using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Calculator
{
    public class Calculation
    {
        private Screen screen;

        private string board = "";
        private string sentence = "";
        
        public void AddNumber(int number)
        {
            sentence += number;
            screen.WriteNumber(sentence);
            screen.WriteBoard(sentence);
        }

        public void SetClass(Screen screen)
        {
            this.screen = screen;
        }
    }
}

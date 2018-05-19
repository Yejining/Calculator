using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Screen.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Screen : UserControl
    {
        private bool isValidInputLength = true;

        public Screen()
        {
            InitializeComponent();
        }

        public void WriteBoard(string sentence)
        {
            board.Content = sentence;
        }

        public void WriteNumber(string number)
        {
            double inputWidth = InputWidth(number);

            while (InputWidth(number) > width.ActualWidth - 7)
                this.number.FontSize -= 3;

            if (this.number.FontSize < 5)
                isValidInputLength = false;

            this.number.Content = number;
        }

        public double InputWidth(string sentence)
        {
            FormattedText formattedText = new FormattedText(sentence, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(number.FontFamily, number.FontStyle, number.FontWeight, number.FontStretch), number.FontSize, Brushes.Black);
            
            return formattedText.Width;
        }
    }
}

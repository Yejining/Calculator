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
            board.Text = sentence;

            if (InputWidth(sentence, Constant.UPPER_BOARD) >= width.ActualWidth)
            {
                left.Visibility = Visibility.Visible;
                right.Visibility = Visibility.Visible;
            }
            else
            {
                left.Visibility = Visibility.Hidden;
                right.Visibility = Visibility.Hidden;
            }
        }

        public void WriteNumber(string number)
        {
            this.number.FontSize = 50;

            while (InputWidth(number, Constant.LOWER_BOARD) > width.ActualWidth - 8)
                this.number.FontSize -= 3;

            if (this.number.FontSize < 5)
                isValidInputLength = false;

            this.number.Content = number;
        }

        public double InputWidth(string sentence, int mode)
        {
            FormattedText formattedText;

            if (mode == Constant.LOWER_BOARD)
            {
                formattedText = new FormattedText(sentence, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(number.FontFamily, number.FontStyle, number.FontWeight, number.FontStretch), number.FontSize, Brushes.Black);
            }
            else
            {
                formattedText = new FormattedText(sentence, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(board.FontFamily, board.FontStyle, board.FontWeight, board.FontStretch), board.FontSize, Brushes.Black);
            }
            
            return formattedText.Width;
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            board.ScrollToHorizontalOffset(board.HorizontalOffset - 60);
        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            board.ScrollToHorizontalOffset(board.HorizontalOffset + 60);
        }
    }
}

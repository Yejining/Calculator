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

namespace Calculator
{
    /// <summary>
    /// TitleBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBar : UserControl
    {
        private MainWindow mainWindow;

        public TitleBar()
        {
            InitializeComponent();
        }

        public void PassMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.DragMove();
        }

        private void close_MouseEnter(object sender, MouseEventArgs e)
        {
            close.Background = Brushes.Red;
            close.Foreground = Brushes.White;
        }

        private void close_MouseLeave(object sender, MouseEventArgs e)
        {
            close.Background = Brushes.Transparent;
            close.Opacity = 1;
            close.Foreground = Brushes.Gray;
        }

        private void close_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            close.Opacity = 0.5;
        }

        private void close_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            mainWindow.Close();
        }
    }
}

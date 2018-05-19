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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}

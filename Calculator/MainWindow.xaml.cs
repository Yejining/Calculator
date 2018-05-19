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
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private TitleBar titleBar = new TitleBar();
        private Pad pad = new Pad();
        private Screen screen = new Screen();

        public MainWindow()
        {
            InitializeComponent();

            titleBar.PassMainWindow(this);
            MainGrid.Children.Add(titleBar);
            Grid.SetRow(titleBar, 0);

            screen.PassMainWindow(this);
            MainGrid.Children.Add(screen);
            Grid.SetRow(screen, 2);

            pad.PassMainWindow(this);
            MainGrid.Children.Add(pad);
            Grid.SetRow(pad, 3);
        }
    }
}

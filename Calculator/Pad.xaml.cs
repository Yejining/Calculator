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
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// MainDesign.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Pad : UserControl
    {
        private MainWindow mainWindow;

        public Pad()
        {
            InitializeComponent();
        }

        public void PassMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            Calculation.AddNumber(Int32.Parse((sender as Button).Tag.ToString()));
        }

        public async void PressKey(int tag)
        {
            string name = Constant.NUMBER[tag];
            Button button = (Button)this.FindName(name);
            
            button.Background = Brushes.DimGray;
            await Task.Delay(100);
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
        }
    }
}

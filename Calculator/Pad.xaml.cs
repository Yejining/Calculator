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
        private Calculation calculation;

        /// <summary>
        /// Pad의 생성자 메소드입니다.
        /// </summary>
        public Pad()
        {
            InitializeComponent();
        }

        public void SetClass(Calculation calculation)
        {
            this.calculation = calculation;
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            calculation.AddNumber(Int32.Parse((sender as Button).Tag.ToString()));
        }

        public void keyUp(object sender, KeyEventArgs e)
        {
            if (IsNumberKey(e.Key))
            {
                PressKey((int)e.Key.GetHashCode() - 34);
                calculation.AddNumber((int)e.Key.GetHashCode() - 34);
            }
            else if (IsSymbolKey(e.Key))
            {
                // 연산키 눌렀을 때
            }
        }

        public async void PressKey(int tag)
        {
            string name = Constant.NUMBER[tag];
            Button button = (Button)this.FindName(name);

            button.Background = Brushes.DimGray;
            await Task.Delay(100);
            button.Background = new SolidColorBrush(Constant.BUTTON_COLOR);
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

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
using System.Diagnostics;

namespace Calculator
{
    /// <summary>
    /// MainDesign.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Pad : UserControl
    {
        private Calculation calculation;
        private bool isShift = false;
        private Stopwatch stopwatch = new Stopwatch();
        private long time;

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

        private void initializationButton_Click(object sender, RoutedEventArgs e)
        {
            calculation.Initialize(Int32.Parse((sender as Button).Tag.ToString()));
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            calculation.AddOperation(Int32.Parse((sender as Button).Tag.ToString()));
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            calculation.AddNumber((sender as Button).Tag.ToString());
        }

        public void keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                isShift = true;
                stopwatch.Start();
                return;
            }

            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                time = stopwatch.ElapsedMilliseconds;

                if (isShift && time > 500) isShift = false;
            }
            
            if (e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift) || isShift)
            {
                if (e.Key == Key.OemPlus)
                {
                    PressKey("addtion");
                    calculation.AddOperation(Constant.ADDTION);
                }
                else if (e.Key == Key.D8)
                {
                    PressKey("multiplication");
                    calculation.AddOperation(Constant.MULTIPLICATION);
                }

                isShift = false;

                return;
            }
            
            if (IsInitializationKey(e.Key))
            {
                PressInitializationKey((int)e.Key.GetHashCode());
            }
            else if (IsOperationKey(e.Key))
            {
                PressOperationKey((int)e.Key.GetHashCode());
            }
            else if (IsNumberKey(e.Key))
            {
                PressNumberKey((int)e.Key.GetHashCode());
            }
        }

        public void PressInitializationKey(int hashcode)
        {
            string name;
            int key;

            switch (hashcode)
            {
                case Constant.ESCAPE:
                    name = "C";
                    key = Constant.C;
                    break;
                case Constant.DELETE:
                    name = "CE";
                    key = Constant.CE;
                    break;
                case Constant.ENTER:
                    name = "equal";
                    key = Constant.EQUAL;
                    break;
                case Constant.OEM_PLUS:
                    name = "equal";
                    key = Constant.EQUAL;
                    break;
                case Constant.BACK:
                    name = "backspace";
                    key = Constant.BACKSPACE;
                    break;
                default:
                    name = "";
                    key = -1;
                    break;
            }

            PressKey(name);
            calculation.Initialize(key);
        }

        public void PressOperationKey(int hashcode)
        {
            string name;
            int key;

            switch (hashcode)
            {
                case Constant.MINUS:
                    name = "subtraction";
                    key = Constant.SUBTRACTION;
                    break;
                case Constant.F9:
                    name = "negate";
                    key = Constant.NEGATE;
                    break;
                case Constant.OEM_QUESTION:
                    name = "devision";
                    key = Constant.DEVISION;
                    break;
                default:
                    name = "";
                    key = -1;
                    break;
            }

            PressKey(name);
            calculation.AddOperation(key);
        }

        public void PressNumberKey(int hashcode)
        {
            int tag;
            string name;
            
            if (hashcode == 144)
                tag = 10;
            else
                tag = hashcode - 34;

            name = Constant.NUMBER_KEY[tag];
            
            PressKey(name);
            calculation.AddNumber(((Button)this.FindName(name)).Content.ToString());
        }

        public async void PressKey(string name)
        {
            Button button = (Button)this.FindName(name);

            button.Background = Brushes.DimGray;
            await Task.Delay(100);
            button.Background = new SolidColorBrush(Constant.BUTTON_COLOR);
        }

        public bool IsInitializationKey(Key key)
        {
            foreach (Key symbol in Constant.INITIALIZATION_KEY)
            {
                if (key == symbol)
                    return true;
            }

            return false;
        }

        public bool IsOperationKey(Key key)
        {
            foreach (Key symbol in Constant.OPERATION_KEY)
            {
                if (key == symbol)
                    return true;
            }

            return false;
        }

        public bool IsNumberKey(Key key)
        {
            if (key >= Key.D0 && key <= Key.D9 || key == Key.OemPeriod)
                return true;
            else
                return false;
        }
    }
}

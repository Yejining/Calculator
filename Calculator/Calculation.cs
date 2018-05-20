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

        private double number = 0;
        private int operation = -1;
        private string board = "";
        private string numberToCalculate = "";

        private bool isNewNumberInput = true;
        private bool isFraction = false;
        
        public void AddOperation(int symbol)
        {
            isNewNumberInput = false;

            // board가 비어있을 경우
            if (board.Length == 0 && numberToCalculate.Length == 0)
                board = number.ToString();
            else if (board.Length == 0)
                number = Convert.ToDouble(numberToCalculate);

            // 연산기호가 연속적으로 입력되는 경우
            if (numberToCalculate.Length == 0 && operation != -1)
                board = board.Remove(board.Length - 2);

            // 계산기 기능 시작시 연산부터 입력하는 경우
            if (numberToCalculate.Length == 0)
                board = $"{board} {Constant.OPERATION[symbol]}";
            else
                board = $"{board} {numberToCalculate} {Constant.OPERATION[symbol]}";

            // 계산
            if (operation != -1)
                Calculate();

            // 연산기호 저장
            operation = symbol;

            // 프린트
            PostOnScreen();

            isNewNumberInput = true;
        }

        public void Calculate()
        {
            switch (operation)
            {
                case Constant.DEVISION:
                    Devide();
                    break;
                case Constant.NEGATE:
                    Negate();
                    break;
                default:
                    Compute(operation);
                    break;
            }

            operation = -1;
        }

        public void Devide()
        {
            // 0으로 나누려는 경우
            if (Convert.ToDouble(numberToCalculate) == 0)
            {
                board = "";
                numberToCalculate = "0으로 나눌 수 없습니다.";
            }
            else
            {
                number /= Convert.ToDouble(numberToCalculate);
                numberToCalculate = number.ToString();
            }
        }

        public void Negate()
        {

        }

        public void Compute(int operation)
        {
            switch (operation)
            {
                case Constant.MULTIPLICATION:
                    number *= Convert.ToDouble(numberToCalculate);
                    break;
                case Constant.SUBTRACTION:
                    number -= Convert.ToDouble(numberToCalculate);
                    break;
                case Constant.ADDTION:
                    number += Convert.ToDouble(numberToCalculate);
                    break;
            }
        }

        public void AddNumber(string number)
        {
            if (isNewNumberInput)
            {
                numberToCalculate = "";
                isNewNumberInput = false;
            }

            // 소수점 한 번만 찍기
            if (IsDot(number) && isFraction)
                return;
            else if (IsDot(number))
                isFraction = true;

            // 제일 처음 0만 찍은 경우
            if (numberToCalculate.Length == 1 && IsZero(numberToCalculate))
                numberToCalculate = "";
            
            numberToCalculate += number;
            
            // 제일 처음 .만 찍은 경우 (.→0.)
            if (numberToCalculate[0] == '.')
                numberToCalculate = numberToCalculate.Insert(0, "0");
            
            PostOnScreen();
        }

        public void PostOnScreen()
        {
            screen.WriteBoard(board);
            screen.WriteNumber(numberToCalculate);
        }

        public void SetClass(Screen screen)
        {
            this.screen = screen;
        }

        public bool IsDot(string number)
        {
            if (string.Compare(number, ".") == 0)
                return true;
            else
                return false;
        }

        public bool IsZero(string number)
        {
            if (string.Compare(number, "0") == 0)
                return true;
            else
                return false;
        }
    }
}

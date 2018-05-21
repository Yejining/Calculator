﻿using System;
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
        private string numberToCalculate = "0";

        private int symbolInputCount = 0;
        private int negateInputCount = 0;
        private bool isNewNumberInput = true;   // 숫자가 처음 입력되는지 판별
        private bool isFraction = false;        // 소수점 입력됐는지 판별
        
        public void Initialize(int key)
        {
            switch (key)
            {
                case Constant.CE:
                    numberToCalculate = "0";
                    isNewNumberInput = true;
                    isFraction = false;
                    break;
                case Constant.C:
                    number = 0;
                    operation = -1;
                    board = "";
                    numberToCalculate = "0";
                    symbolInputCount = 0;
                    isNewNumberInput = true;
                    isFraction = false;
                    break;
                case Constant.BACKSPACE:
                    if (numberToCalculate.Length != 0 && !isNewNumberInput)
                        numberToCalculate = numberToCalculate.Remove(numberToCalculate.Length - 1);
                    if (numberToCalculate.Length == 0)
                        numberToCalculate = "0";
                    break;
                case Constant.EQUAL:
                    Calculate();
                    number = 0;
                    operation = -1;
                    board = "";
                    symbolInputCount = 0;
                    isNewNumberInput = true;
                    isFraction = false;
                    break;
            }

            PostOnScreen();
        }

        public void AddOperation(int symbol)
        {
            isNewNumberInput = false;

            if (symbol != Constant.NEGATE)
            {
                symbolInputCount++;
                negateInputCount = 0;
            }
            else
                negateInputCount++;

            // 계산할 숫자가 0인 경우
            if (IsZero(numberToCalculate) && !isFraction)
            {
                numberToCalculate = "0";
            }

            // 쓸모없는 0 지우기
            while ((isFraction && numberToCalculate[numberToCalculate.Length - 1] == '0') || numberToCalculate[numberToCalculate.Length - 1] == '.')
            {
                if (symbol == Constant.NEGATE && numberToCalculate[numberToCalculate.Length - 1] == '.')
                    break;
                else
                    numberToCalculate = numberToCalculate.Remove(numberToCalculate.Length - 1);
            }

            isFraction = false;

            // board가 비어있을 경우
            if (board.Length == 0 && numberToCalculate.Length == 0)
                board = number.ToString();
            else if (board.Length == 0)
                number = Convert.ToDouble(numberToCalculate);

            // 연산기호가 연속적으로 입력되는 경우
            if (numberToCalculate.Length == 0 && operation != -1 || symbolInputCount > 1)
            {
                board = board.Remove(board.Length - 2);
                operation = -1;
            }

            // 계산기 기능 시작시 연산부터 입력하는 경우
            else if (numberToCalculate.Length == 0 || symbolInputCount > 1 && symbol != Constant.NEGATE)
                board = $"{board} {Constant.OPERATION[symbol]}";
            else if (operation != Constant.NEGATE && symbol != Constant.NEGATE)
                board = $"{board} {numberToCalculate} {Constant.OPERATION[symbol]}";
            else if (operation == Constant.NEGATE && symbol != Constant.NEGATE)
                board = $"{board} {Constant.OPERATION[symbol]}";

            // 계산
            if (operation != -1 && symbol != Constant.NEGATE)
                Calculate();
            else if (symbol == Constant.NEGATE)
                Negate();

            // 연산기호 저장
            //if (symbol != Constant.NEGATE)
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
                //case Constant.NEGATE:
                //    Negate();
                //    break;
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
            symbolInputCount = 0;

            // 계산할 숫자가 0이 아니고 첫 연산 전일 경우 부호 바꾸기
            if (string.Compare(numberToCalculate, "0") != 0 && operation == -1)
            {
                if (numberToCalculate[0] == '-')
                    numberToCalculate = numberToCalculate.Remove(0, 1);
                else
                    numberToCalculate = numberToCalculate.Insert(0, "-");
            }
            else if (negateInputCount == 1)
            {
                board = $"{board} negate({numberToCalculate})";

                if (numberToCalculate[0] == '-')
                    numberToCalculate = numberToCalculate.Remove(0, 1);
                else
                    numberToCalculate = numberToCalculate.Insert(0, "-");
            }
            else
            {
                int a = board.LastIndexOf($"negate(");
                board = board.Insert(a, "negate(");
                board = board.Insert(board.Length, ")");

                if (numberToCalculate[0] == '-')
                    numberToCalculate = numberToCalculate.Remove(0, 1);
                else
                    numberToCalculate = numberToCalculate.Insert(0, "-");
            }

            number += Convert.ToDouble(numberToCalculate);
            numberToCalculate = number.ToString();
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

            numberToCalculate = number.ToString();
        }

        public void AddNumber(string number)
        {
            symbolInputCount = 0;
            negateInputCount = 0;

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

﻿using System;

namespace DemoCalc
{
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Substract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            
            return a / b;
        }

        public double Factorial(double a)
        {
            double abs = Math.Abs(a);
            return (a > 1) ? a * Factorial(a - 1) : a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class DoubleNumber
    {
        public void Multiple(double x, double y, out double result)
        {
            result = x * y;
        }

        public void Substract(double x, double y, out double result)
        {
            result = x - y;
        }
    }
}

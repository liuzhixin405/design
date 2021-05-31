namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class UglyCalculator
    {
        public void Calculate(double price, double quantity, double discount, 
            out double result)
        {   
            // û�취�� û�� = �� new ������ DoubleNumber û�ش�
            new DoubleNumber().Multiple(price, quantity, out result);
            new DoubleNumber().Substract(result, discount, out result);
        }
    }
}

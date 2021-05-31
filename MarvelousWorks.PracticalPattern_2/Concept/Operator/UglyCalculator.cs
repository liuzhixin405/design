namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class UglyCalculator
    {
        public void Calculate(double price, double quantity, double discount, 
            out double result)
        {   
            // 没办法， 没有 = ， new 出来的 DoubleNumber 没地存
            new DoubleNumber().Multiple(price, quantity, out result);
            new DoubleNumber().Substract(result, discount, out result);
        }
    }
}

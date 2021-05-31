namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class CommonCalcultor
    {
        public double Calculate(double price, double quantity, double discount)
        {
            return price * quantity - discount;
        }
    }
}

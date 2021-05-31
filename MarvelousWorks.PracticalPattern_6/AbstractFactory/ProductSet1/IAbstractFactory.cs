using System;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.ProductSet1
{
    public class ConcreteFactory : IAbstractFactory
    {
        private Type typeA;
        private Type typeB;

        public ConcreteFactory(Type typeA, Type typeB)
        {
            this.typeA = typeA;
            this.typeB = typeB;
        }

        public virtual IProductA CreateProducctA() 
        {
            return (IProductA)Activator.CreateInstance(typeA); 
        }
        public virtual IProductB CreateProducctB() 
        {
            return (IProductB)Activator.CreateInstance(typeB); 
        }
    }
}

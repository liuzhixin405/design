using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Reversable
{
    public class Product 
    {
        public int Count;
        public IList<int> Items;
    }

    public interface IBuilder<T>
    {
        T BuildUp();
        T TearDown();
    }

    public class ProductBuilder : IBuilder<Product>
    {
        private Product product = new Product();
        private Random random = new Random();
        public Product BuildUp()
        {
            product.Count = 0;
            product.Items = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                product.Items.Add(random.Next());
                product.Count++;
            }
            return product;
        }

        public Product TearDown()
        {
            while (product.Count > 0)
            {
                int val = product.Items[0];
                product.Items.Remove(val);
                product.Count--;
            }
            return product;
        }
    }
}

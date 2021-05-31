using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    public interface IObjectWithName
    {
        string Name { get; set;}
    }

    public interface IFeature : IObjectWithName
    {
        string Description { get;set;}
    }

    public interface IProduct : IObjectWithName
    {
        double Price { get; set;}
        IList<IFeature> Features { get;}
    }

    public abstract class ProductBase : IProduct
    {
        protected string name;
        protected double price;
        protected IList<IFeature> features = new List<IFeature>();

        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public virtual IList<IFeature> Features
        {
            get { return this.features; }
            set { this.features = value; }
        }
    }

    public class Car : ProductBase { }

    public class FeaturePair : IFeature
    {
        private string name;
        private string description = string.Empty;  // default

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Name
        {
            get{return this.name;}
            set { this.name = value; }
        }
    }


    
}

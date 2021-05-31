namespace MarvellousWorks.PracticalPattern.BuilderPattern.RawHome
{
    public interface IProduct { string Name { get; set;} }
    public class ConcreteProduct : IProduct
    {
        protected string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }

    public interface IBuilder
    {
        void BuildPart();
        /// <summary>
        /// 相当于GetResult()方法，由于构造的产品属于同一种类型，
        /// 因此这类Builder模式实现中，将该方法直接定义在抽象对象上。
        /// </summary>
        /// <returns></returns>
        IProduct BuildUp();     
    }

    public class ConcreteBuilderA : IBuilder
    {
        private IProduct product = new ConcreteProduct();
        public void BuildPart() { product.Name = "A"; }
        public IProduct BuildUp() { return product; }
    }

    public class Director
    {
        public void Construct(IBuilder builder) { builder.BuildPart(); }
    }
}

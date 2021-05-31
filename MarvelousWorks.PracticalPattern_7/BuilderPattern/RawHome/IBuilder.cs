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
        /// �൱��GetResult()���������ڹ���Ĳ�Ʒ����ͬһ�����ͣ�
        /// �������Builderģʽʵ���У����÷���ֱ�Ӷ����ڳ�������ϡ�
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

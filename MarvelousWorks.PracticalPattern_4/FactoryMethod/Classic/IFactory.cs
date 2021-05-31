namespace MarvellousWorks.PracticalPattern.FactoryMethod.Classic
{
    /// <summary>
    /// ����Ĺ���������������
    /// </summary>
    public interface IFactory
    {
        IProduct Create();  //  ÿ����������Ҫ���еĹ�����������������Ʒ
    }

    /// <summary>
    /// ʵ�幤������
    /// </summary>
    public class FactoryA : IFactory
    {
        public IProduct Create()
        {
            return new ProductA();
        }
    }

    /// <summary>
    /// ʵ�幤������
    /// </summary>
    public class FactoryB : IFactory
    {
        public IProduct Create()
        {
            return new ProductB();
        }
    }
}

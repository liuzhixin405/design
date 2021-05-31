namespace MarvellousWorks.PracticalPattern.FactoryMethod
{
    /// <summary>
    /// �����Ʒ����
    /// </summary>
    public interface IProduct
    {
        string Name { get;}     // Լ���ĳ����Ʒ��������е�����
    }

    /// <summary>
    /// �����Ʒ����
    /// </summary>
    public class ProductA : IProduct
    {
        public string Name { get { return "A"; } }
    }
    /// <summary>
    /// �����Ʒ����
    /// </summary>
    public class ProductB : IProduct
    {
        public string Name { get { return "B"; } }
    }
}

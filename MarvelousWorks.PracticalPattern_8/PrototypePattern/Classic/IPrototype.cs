using System;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Classic
{
    public class Indicator { }

    public interface IPrototype
    {
        IPrototype Clone();
        string Name { get; set;}    // Ϊ����ʾ�����ӵĶ�������
        Indicator Signal { get; }   
    }

    public class ConcretePrototype : IPrototype
    {
        public IPrototype Clone() { return (IPrototype)this.MemberwiseClone(); }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private Indicator signal = new Indicator();
        public Indicator Signal { get { return this.signal; } }
    }
}

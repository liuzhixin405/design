using System;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Refresh
{
    public interface IPrototype
    {
        string Name { get; set;}
        IPrototype Clone();
    }

    [Serializable]
    public abstract class PrototypeBase : IPrototype
    {
        public virtual IPrototype Clone()
        {
            string graph = SerializationHelper.SerializeObjectToString(this);
            return SerializationHelper.DeserializeStringToObject<IPrototype>(graph);
        }

        protected string name;

        public virtual string Name
        {
            get{return name;}
            set{name = value;}
        }
    }

    [Serializable]
    public class ConcretePrototype : PrototypeBase { }
}

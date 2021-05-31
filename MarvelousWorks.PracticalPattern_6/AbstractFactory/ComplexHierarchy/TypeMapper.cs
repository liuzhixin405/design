using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.ComplexHierarchy
{
    public abstract class TypeMapperBase : Dictionary<Type, Type> { }
    public class TypeMapperDictionary : Dictionary<Type, TypeMapperBase> { }
    public interface IAbstarctFactoryWithTypeMapper : IAbstractFactory
    {
        TypeMapperBase Mapper { get;set;}
    }

    public abstract class AbstractFactoryBase : IAbstarctFactoryWithTypeMapper
    {
        protected TypeMapperBase mapper;

        public virtual TypeMapperBase Mapper
        {
            get { return mapper; }
            set { mapper = value; }
        }

        public virtual T Create<T>()
        {
            Type targetType = mapper[typeof(T)];
            return (T)Activator.CreateInstance(targetType);
        }
    }

    /// <summary>
    /// X系列和Y系列产品的具体TypeMapper类
    /// </summary>
    public class ConcreteXTypeMapper : TypeMapperBase
    {
        public ConcreteXTypeMapper()
        {
            base.Add(typeof(IProductXA), typeof(ProductXA2));
            base.Add(typeof(IProductXB), typeof(ProductXB1));
        }
    }
    public class ConcreteYTypeMapper : TypeMapperBase
    {
        public ConcreteYTypeMapper()
        {
            base.Add(typeof(IProductYA), typeof(ProductYA1));
            base.Add(typeof(IProductYB), typeof(ProductYB1));
            base.Add(typeof(IProductYC), typeof(ProductYC1));
        }
    }

    public class ConcreteFactoryX : AbstractFactoryBase { }
    public class ConcreteFactoryY : AbstractFactoryBase { }

    public static class AssemblyMechanism
    {
        private static TypeMapperDictionary dictionary = new TypeMapperDictionary();

        /// <summary>
        /// 加载相关TypeMapper / IAbstractFactory的对应信息，实际
        /// 执行的时候可以通过访问配置完成。
        /// </summary>
        static AssemblyMechanism()
        {
            dictionary.Add(typeof(ConcreteFactoryX), new ConcreteXTypeMapper());
            dictionary.Add(typeof(ConcreteFactoryY), new ConcreteYTypeMapper());
        }

        /// <summary>
        /// 为AbstractFactory找到他的TypeMapper，并注入
        /// </summary>
        /// <param name="factory"></param>
        public static void Assembly(IAbstarctFactoryWithTypeMapper factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            TypeMapperBase mapper = dictionary[factory.GetType()];
            factory.Mapper = mapper;
        }
    }
}

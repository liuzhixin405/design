using System;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Configurable
{
    /// <summary>
    /// ����ʵ����Ҫʹ�õı�ʾ��Ʒÿ�����Ե�ʵ������
    /// </summary>
    public class ConcreteFeatureConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public virtual string TypeName { get { return (string)base["type"]; } }

        /// <summary>
        /// ����Ԫ��ͬʱ��Ϊ����������һ����û�ӵ��������Ĳ�Ʒ����ʵ��ë��
        /// </summary>
        /// <returns></returns>
        public IFeature Create()
        {
            return (IFeature)Activator.CreateInstance(Type.GetType(TypeName));
        }
    }
}

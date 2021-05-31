using System;
using System.Collections.Generic;
using System.Reflection;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// ͨ��������ĳ���������BuildPart()����ָ����Ϣ�Ĺ�������
    /// </summary>
    public static class TypeDiscovery
    {
        /// <summary>
        /// �����Ѿ���������������Ϣ
        /// </summary>
        private static IDictionary<Type, IList<BuildStepAttribute>> cache =
            new Dictionary<Type, IList<BuildStepAttribute>>();

        /// <summary>
        /// �������������� T ����ִ��BuildPart()���Զ����ֻ���
        /// </summary>
        /// <returns></returns>
        public static IList<BuildStepAttribute> DiscoveryBuildSteps(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (!cache.ContainsKey(type)) 
            {
                IList<MethodInfo> methods =
                    AttributeHelper.GetMethodsWithCustomAttribute<BuildStepAttribute>(type);
                if ((methods == null) || (methods.Count == 0)) return null;
                BuildStepAttribute[] attributes = new BuildStepAttribute[methods.Count];
                for (int i = 0; i < methods.Count; i++)
                {
                    BuildStepAttribute attribute =
                        AttributeHelper.GetMethodCustomAttribute<BuildStepAttribute>(methods[i]);
                    attribute.Handler = methods[i];
                    attributes[i] = attribute;
                }
                Array.Sort<BuildStepAttribute>(attributes);
                IList<BuildStepAttribute> buildSteps = new List<BuildStepAttribute>(attributes);
                cache.Add(type, buildSteps);
            }
            return cache[type];
        }
    }
}

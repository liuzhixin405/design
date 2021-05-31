using System;
using System.Collections.Generic;
using System.Reflection;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// 通过反射获得某个类型相关BuildPart()步骤指导信息的工具类型
    /// </summary>
    public static class TypeDiscovery
    {
        /// <summary>
        /// 缓冲已经解析过的类型信息
        /// </summary>
        private static IDictionary<Type, IList<BuildStepAttribute>> cache =
            new Dictionary<Type, IList<BuildStepAttribute>>();

        /// <summary>
        /// 借助反射获得类型 T 所需执行BuildPart()的自动发现机制
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

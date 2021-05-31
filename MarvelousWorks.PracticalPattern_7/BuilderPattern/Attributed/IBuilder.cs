using System;
using System.Collections.Generic;
using System.Reflection;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Attributed
{
    public interface IBuilder<T> where T : class, new()
    {
        T BuildUp();
    }

    public class Builder<T> : IBuilder<T>where T : class, new()
    {
        public virtual T BuildUp()
        {
            IList<BuildStepAttribute> attributes = DiscoveryBuildSteps();
            if (attributes == null) return new T(); // 没有BuildPart步骤，退化为Factory模式
            T target = new T();
            foreach (BuildStepAttribute attribute in attributes)
                for (int i = 0; i < attribute.Times; i++)
                    attribute.Handler.Invoke(target, null);
            return target;
        }

        private static IDictionary<Type, IList<BuildStepAttribute>> cache =
            new Dictionary<Type, IList<BuildStepAttribute>>();

        /// <summary>
        /// 借助反射获得类型 T 所需执行BuildPart()的自动发现机制
        /// </summary>
        /// <returns></returns>
        protected virtual IList<BuildStepAttribute> DiscoveryBuildSteps()
        {
            if (!cache.ContainsKey(typeof(T)))
            {
                IList<MethodInfo> methods =
                    AttributeHelper.GetMethodsWithCustomAttribute<BuildStepAttribute>(typeof(T));
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
                cache.Add(typeof(T), buildSteps);
            }
            return cache[typeof(T)];
        }
    }
}

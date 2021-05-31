using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.WithBuilder
{
    public class DecoratorBuilder
    {
        private DecoratorAssembly assembly = new DecoratorAssembly();

        public IText BuildUp(IText target) 
        {
            if (target == null) throw new ArgumentNullException("target");
            IList<Type> types = assembly[target.GetType()];
            if ((types != null) && (types.Count > 0))
                foreach (Type type in types)
                    // Ïàµ±ÓÚ text = new ColorDecorator(text);
                    target = (IText)Activator.CreateInstance(type, target);
            return target;
        }
    }
}

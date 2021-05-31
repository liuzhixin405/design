using System;
using System.Collections.Generic;
using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Common.Configuration
{
    /// <summary>
    /// ITypeCreator µƒ≈‰÷√Ω‚Œˆ¿‡
    /// </summary>
    class ObjectBuilderConfigurationSource : ConfigurationSection
    {
        private const string typeProperty = "type";

        [ConfigurationProperty(typeProperty, IsRequired = true)]
        public string TypeName
        {
            get { return (string)this[typeProperty]; }
        }
    }
}
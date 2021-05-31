using System;
namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    #region static impl.
    //public static class RawGenericFactory
    //{
    //    public static T Create<T>(string typeName)
    //    {
    //        return (T)Activator.CreateInstance(Type.GetType(typeName));
    //    }
    //}
    #endregion

    public class RawGenericFactory<T>
    {
        public T Create(string typeName)
        {
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}

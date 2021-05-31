namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    // 解决类似 where T : A || B 的需要
    interface INewComer { }
    class OrA : INewComer { }
    class OrB : INewComer { }
    class OrClient<T> where T : INewComer { }


    // 解决类似 where T : A && B 的需要
    interface Layer11 { }
    interface Layer12 { }
    interface Layer2 : Layer11, Layer12 { }
    class AndA : Layer11 { }
    class AndB : Layer12 { }
    class AndClient<T> where T : Layer12 { }
}

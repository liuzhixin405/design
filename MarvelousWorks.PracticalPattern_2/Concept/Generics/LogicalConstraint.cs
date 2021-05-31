namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    // ������� where T : A || B ����Ҫ
    interface INewComer { }
    class OrA : INewComer { }
    class OrB : INewComer { }
    class OrClient<T> where T : INewComer { }


    // ������� where T : A && B ����Ҫ
    interface Layer11 { }
    interface Layer12 { }
    interface Layer2 : Layer11, Layer12 { }
    class AndA : Layer11 { }
    class AndB : Layer12 { }
    class AndClient<T> where T : Layer12 { }
}

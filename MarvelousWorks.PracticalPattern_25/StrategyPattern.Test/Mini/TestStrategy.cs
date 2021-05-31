using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StrategyPattern.Mini;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Test.Mini
{
    [TestClass]
    public class TestStrategy
    {
        #region �����Strategy����

        public class ComparerByID : IComparer<IBusinessObject>
        {
            public int Compare(IBusinessObject x, IBusinessObject y)
            {
                if ((x == null) || (y == null)) throw new ArgumentNullException("x or y");
                return x.ID - y.ID;
            }
        }

        public class ComparerByName : IComparer<IBusinessObject>
        {
            public int Compare(IBusinessObject x, IBusinessObject y)
            {
                if ((x == null) || (y == null)) throw new ArgumentNullException("x or y");
                return new CaseInsensitiveComparer().Compare(x.Name, y.Name);
            }
        }

        #endregion

        /// <summary>
        /// ����Context����
        /// </summary>
        public class BusinessObjectCollection : IBusinessObjectCollection
        {
            private IList<IBusinessObject> objects = new List<IBusinessObject>();

            /// <summary>
            /// ΪContext����Strategy
            /// </summary>
            private IComparer<IBusinessObject> comparer;
            public IComparer<IBusinessObject> Comparer
            {
                get { return this.comparer; }
                set { this.comparer = value; }
            }

            /// <summary>
            /// Context�������Strategy����Լ����㷨
            /// ���������������ӳ�Ա�������������ǽ���Strategy������
            /// </summary>
            /// <returns></returns>
            public IEnumerable<IBusinessObject> GetAll()
            {
                if (objects.Count == 0) yield break;
                if (objects.Count == 1)
                {
                    yield return objects[0];
                    yield break;
                }

                IBusinessObject[] array = new IBusinessObject[objects.Count];
                objects.CopyTo(array, 0);
                Array.Sort<IBusinessObject>(array, comparer);
                for (int i = 0; i < array.Length; i++)
                    yield return array[i];
            }

            public void Add(IBusinessObject obj) { objects.Add(obj); }
        }


        class Student : BusinessObjectBase
        {
            public Student(int id, string name) : base(id, name) { }
        }

        [TestMethod]
        public void Test()
        {
            IBusinessObjectCollection collection = new BusinessObjectCollection();
            collection.Add(new Student(2, "B"));
            collection.Add(new Student(1, "C"));
            collection.Add(new Student(3, "A"));

            // ��֤�㷨����Ч��
            collection.Comparer = new ComparerByID();
            int id = 0;
            foreach (IBusinessObject obj in collection.GetAll())
                Assert.AreEqual<int>(++id, obj.ID);

            // �滻����һ���㷨
            collection.Comparer = new ComparerByName();
            string[] data = new string[3] { "A", "B", "C" };
            int index = 0;
            foreach (IBusinessObject obj in collection.GetAll())
                Assert.AreEqual<string>(data[index++], obj.Name);
        }
    }
}

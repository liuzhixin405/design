using System;
using System.Collections;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Iterating
{
    public class RawIterator
    {
        private int[] data = new int[]{0, 1, 2, 3, 4};

        // 最简单的基于数组的全部遍历
        // 如果客户程序需要强类型的返回值，可以采用泛型声明 public IEnumerator<int>
        public IEnumerator GetEnumerator() 
        { 
            foreach (int item in data) 
                yield return item; 
        }

        // 返回某个区间内数据的 IEnumerable
        public IEnumerable GetRange(int start, int end)
        {
            for (int i = start; i <= end; i++) 
                yield return data[i]; 
        }

        // 手工“捏”出来的 IEnumerable<string>
        public IEnumerable<string> Greeting
        { 
            get
            { 
                yield return "hello"; 
                yield return "world"; 
                yield return "!"; 
            } 
        }
    }
}

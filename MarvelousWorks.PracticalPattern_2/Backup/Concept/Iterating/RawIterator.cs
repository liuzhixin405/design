using System;
using System.Collections;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Iterating
{
    public class RawIterator
    {
        private int[] data = new int[]{0, 1, 2, 3, 4};

        // ��򵥵Ļ��������ȫ������
        // ����ͻ�������Ҫǿ���͵ķ���ֵ�����Բ��÷������� public IEnumerator<int>
        public IEnumerator GetEnumerator() 
        { 
            foreach (int item in data) 
                yield return item; 
        }

        // ����ĳ�����������ݵ� IEnumerable
        public IEnumerable GetRange(int start, int end)
        {
            for (int i = start; i <= end; i++) 
                yield return data[i]; 
        }

        // �ֹ����󡱳����� IEnumerable<string>
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

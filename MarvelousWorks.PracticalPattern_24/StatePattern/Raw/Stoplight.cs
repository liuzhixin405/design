using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Raw
{
    public enum Color { Red, Yellow, Green }

    public class StopLight
    {
        private Color current = Color.Green;    // default

        /// <summary>
        /// ��һ���űȵ�if else���ת���߼�
        /// </summary>
        /// <returns></returns>
        public Color ChangeColor()
        {
            if (current == Color.Green)
                current = Color.Yellow;
            else if (current == Color.Yellow)
                current = Color.Red;
            else if(current == Color.Red)
                current = Color.Green;
            return current;
        }
    }
}

﻿/* Heap.cs
 * Heap ADT
 * 
 * Revision History: 
 *  Chris Mosey: 15.03.2015: created
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHLPlayer;

namespace HeapADT
{
    public class Heap<T> where T : IComparable
    {
        int arraySize;
        T[] objArray;
        int maxNum;

        public Heap(int maxNum)
        {
            if (maxNum > 2000000)
            {
                throw new IndexOutOfRangeException();
            }
            arraySize = 0;
            objArray = new T[maxNum + 1];
            this.maxNum = maxNum;
        }

        public bool IsEmpty()
        {
            if (arraySize == 0)
            {
                return true;
            }
            return false;
        }

        public int Entries()
        {
            return arraySize;
        }

        public void Insert(T new_item)
        {
            if (arraySize >= maxNum)
            {
                throw new ArgumentException("Heap is full");
            }

            objArray[++arraySize] = new_item;

            int tracer = arraySize;
            while (tracer > 1 && objArray[tracer / 2].CompareTo(objArray[tracer]) == 1)
            {
                exch(tracer, tracer / 2);
                tracer = tracer / 2;
            }
        }

        public T getMin()
        {
            exch(1, arraySize);

            int tracer = 1;
            while (2 * tracer <= arraySize - 1)
            {
                int x = 2 * tracer;
                if (x < arraySize - 1 && objArray[x].CompareTo(objArray[x + 1]) == 1)
                {
                    x++;
                }
                if (!(objArray[tracer].CompareTo(objArray[x]) == 1))
                {
                    break;
                }
                exch(tracer, x);

                tracer = x;
            }

            T tempObj = objArray[arraySize];
            objArray[arraySize--] = default(T);
            return tempObj;
        }

        private void exch(int x, int y)
        {
	        T temp;
	        temp = objArray[x];
            objArray[x] = objArray[y];
	        objArray[y] = temp;
        }
    }
}

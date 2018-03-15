using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTree
{
    public class MyPriorityQueue
    {
        public List<int> list = new List<int>();

        public void Add(int value)
        {
            list.Add(value);

            Heapify();
        }

        private void Heapify()
        {
            int index = list.Count - 1;
            if (index <= 0)
            {
                return;
            }
            while (index >= 0)
            {
                int parIndex = (index - 1) / 2;
                if (parIndex < 0)
                {
                    return;
                }
                if (list[parIndex] <= list[index])
                {
                    return;
                }

                int temp = list[parIndex];
                list[parIndex] = list[index];
                list[index] = temp;

                index = parIndex;
            }
        }

        public int? Remove()
        {
            if (list.Count == 0)
            {
                return null;
            }

            if (list.Count == 1)
            {
                int val = list[0];
                list.RemoveAt(0);
                return val;
            }

            int temp = list[0];
            list[0] = list[list.Count - 1];
            list[list.Count - 1] = temp;

            int val2 = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            

            BackHeapify();
            return val2;
        }

        private void BackHeapify()
        {
            int index = 0;

            while (index < list.Count)
            {
                int leftIndex = 2 * index + 1;
                int rightIndex = 2 * index + 2;

                int? minIndex = Min(leftIndex, rightIndex);

                if (!minIndex.HasValue)
                {
                    break;
                }
                if (index == Min(index, minIndex.Value).Value)
                {
                    break;
                }

                int temp = list[index];
                list[index] = list[minIndex.Value];
                list[minIndex.Value] = temp;

                index = minIndex.Value;
            }
        }
        private int? Min(int leftIndex, int rightIndex)
        {
            if (leftIndex >= list.Count)
            {
                return null;
            }
            if (rightIndex >= list.Count)
            {
                return leftIndex;
            }

            if (list[leftIndex] >= list[rightIndex])
            {
                return rightIndex;
            }
            else
            {
                return leftIndex;
            }
        }
    }
}

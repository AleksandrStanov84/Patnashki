using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SatckIEnumerableCSharp
{
    public class Stack<T> : IEnumerable
    {
        public T[] items;
        private int count;
        private const int Capacity = 10;

        public Stack()
        {
            items = new T[Capacity];
        }

        public int GetCount()
        {
            return count;
        }

        public int GetCapacity()
        {
            return Capacity;
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return count == items.Length;
            }
        }

        public T Peek()
        {
            return items[count - 1];
        }

        public void Push(T item)
        {
            if (IsFull)
                throw new InvalidOperationException("Переполнение стека");
            items[count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            return item;
        }

        public IEnumerator GetEnumerator()
        {
            MyEnumerator<T> myEnumerator = new MyEnumerator<T>(items);
            return myEnumerator;
        }
    }

    class MyEnumerator<T> : IEnumerator
    {
        private T[] items;
        private int index = -1;

        public MyEnumerator(T[] items)
        {
            this.items = items;
        }

        public object Current
        {
            get
            {
                if (index < 0)
                    throw new InvalidOperationException();
                return items[index];
            }
        }

        public bool MoveNext()
        {
            if (index + 1 < items.Length)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(1);
            }

            foreach (int item in myStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}


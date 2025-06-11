using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{

    public class MyStack<T>
    {
        private T[] _elements;
        private int _top;
        private  int _maxCapacity;

        public MyStack(int capacity)
        {
            _maxCapacity = capacity;
            _elements = new T[_maxCapacity];
            _top = -1; 
        }

        public bool Push(T value)
        {
            if (IsFull())
                return false;

            _elements[++_top] = value;
            return true;
        }

        public T? Pop()
        {
            if (IsEmpty())
                return default; 

            return _elements[_top--];
        }

        public bool IsEmpty() => _top < 0;

        public bool IsFull() => _top >= _maxCapacity - 1;

        public int Count => _top + 1; 
    }
}

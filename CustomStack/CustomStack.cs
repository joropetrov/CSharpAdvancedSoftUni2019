using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private int count;

        T[] items;

        public CustomStack()
        {
            this.count = 0;
            this.items = new T[InitialCapacity];
        }

        public int Count => this.count;

        public void Push(T element)
        {
            EnsureCapacity();
            this.items[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            ThrowWhenEmpty();
            var lastElement = this.items[this.count - 1];
            this.count--;
            return lastElement;
        }

        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[this.count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.count -1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void EnsureCapacity()
        {   
            if (this.items.Length > this.Count)
            {
                return;
            }
            var tempArray = new T[2 * this.items.Length];
            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }
            this.items = tempArray; 
        }

        private void ThrowWhenEmpty()
        {
            if (this.count == 0)
            {
                throw new Exception("Stack is empty");
            }
        }

        // foreach and linq for our stack :)
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return (IEnumerator)GetEnumerator();
        }
    }
}

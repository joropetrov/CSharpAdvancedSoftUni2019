using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;

        public CustomList()
        {

            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index] // [] overloading important
        {
            get
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            EnsureCapacity();
            this.items[this.Count] = element;
            this.Count++;
        }

        public void Reverse()
        {
            //easier way Swap(i, this.Count - i -1)
            for (int i = 0; i < this.Count/2; i++)
            {
                T leftDigit = this.items[i];
                this.items[i] = this.items[this.Count - i - 1];
                this.items[this.Count - i - 1] = leftDigit;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                stringBuilder.Append($"{this.items[i]}, ");
            }
            return stringBuilder.ToString().TrimEnd(' ', ',');
        }
        
        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            var element = this.items[index];
            this.ShiftToLeft(index);
            this.Count--;
            this.Shrink();
            return element;
        }

        public void InsertAt(int index, T element)
        {
            ValidateIndex(index);
            EnsureCapacity();
            this.Count++;
            ShiftToRight(index);
            this.items[index] = element;
        }

        public bool Contains(T elements)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(elements))
                {
                    return true;
                }
            }

            return false;
        }

        public void Slap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            T tempValue = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempValue;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void EnsureCapacity()
        {   // instead copy by hand, we can call Array.Copy(this.items, 0, tempArray, 0, this.items.Lenght); it'll copy them smarter, faster 
            //works for arrays only 
            if (this.items.Length > this.Count)
            {
                return;
            }
            var tempArray = new T[2 * this.items.Length];
            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }
            this.items = tempArray; // reference between both vanishes and garbije collector cleans the old array ;
        }

        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }
            var tempArray = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }
            this.items = tempArray;
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default(T); //or default(int)
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count-1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            
        }
    }
}

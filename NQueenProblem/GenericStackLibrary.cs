using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackLibrary
{
	class GenericStackClass<T>
	{
		protected const int maxSize = 100;
		public T[] arr = new T[maxSize];
		public int countIndex = 0;

		public GenericStackClass()
		{
		}
		public GenericStackClass(GenericStackClass<T> toCloneFrom)
        {
			for (int i = 0; i < maxSize; i++)
            {
				if (toCloneFrom.get(i) != null)
				{
					push(toCloneFrom.get(i));
				}
            }
        }
		public void push(T value)
		{
			if (countIndex > maxSize-1)
			{
				Console.WriteLine("The array is out of bounds");
			}
			else
			{
				arr[countIndex] = value;
				countIndex++;
			}
		}
		public T top()
		{
			return arr[countIndex - 1]; // since array start from zero index 
		}
		public void pop()
		{
			if (isEmpty())
			{
				Console.WriteLine("The array is already empty");
			}
			else
			{
				countIndex--;
			}
		}
		public int size()
		{
			return countIndex;
		}
		public bool isEmpty()
		{
			if (countIndex == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public string toString()
		{
			string emptyString = "";
			for (int i = 0; i < countIndex; i++)
			{
				emptyString += arr[i];
			}
			return emptyString;
		}
		public T get(int i)
		{
			return arr[i];
		}
	}
}

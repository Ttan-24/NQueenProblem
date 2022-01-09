using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackLibrary
{
    class GenericStackClass<T> : IDisplayable
	{
		/* Class Description
		 * This class is a Last-In/First-Out (LIFO) stack
		 * implemented with a generic type (T)
		 */

		/// <summary>
		/// This classs is a Last-In/First-Out (LIFO) stack
		/// implemented with a generic type (T)
		/// 
		/// It also implements the IDisplayable interface
		/// which is used to store generic displayable
		/// stacks.
		/// </summary>

		///// Member Data /////
		protected const int maxSize = 1000;
		public T[] arr = new T[maxSize];
		public int countIndex = 0;

        // default constructor 
        public GenericStackClass()
		{
		}
		// copy constructor used to store solutions in the SolutionFinder
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

		///// Member Functions /////
		// Push new values to stack
		public void push(T value)
		{
			if (countIndex > maxSize-1)
			{
				//throw new IndexOutOfRangeException();
			}
			else
			{
				arr[countIndex] = value;
				countIndex++;
			}
		}
		// Get the top variable in the stack (the last to be pushed and first to be popped)
		public T top()
		{
			return arr[countIndex - 1]; // since array start from zero index 
		}
		// Pop the top member variable from the stack
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
		// Get the size of the stack
		public int size()
		{
			return countIndex;
		}
		// Check if there is no data in the stack
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
		// Convert the stack to a string. This function can be overridden for display purposes
		public virtual string toString()
		{
			string emptyString = "";
			for (int i = 0; i < countIndex; i++)
			{
				emptyString += arr[i];
			}
			return emptyString;
		}
		// Get the stack variable at a specific index
		public T get(int i)
		{
			return arr[i];
		}
	}
}

using GenericStackLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueenProblem
{
    class Program
    {
        /// <summary>
        /// Main class primarily used for getting
        /// user input to define constraints and
        /// use static classes to form solutions
        /// for the given data.
        /// </summary>
        
        static void Main(string[] args)
        {
            // Create initial queenstack
            QueenStack queenStack = new QueenStack();

            bool correctInput = false;
            while (correctInput == false)
            {
                try
                {
                    // Get grid size
                    Console.WriteLine("Input size: ");
                    int gridSize = Int32.Parse(Console.ReadLine());
                    queenStack.gridSize = gridSize;
                    if (gridSize > 0)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Choose a non-negative number");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect format. Try again");
                }
            }

            // Create display stack
            GenericStackClass<IDisplayable> displayStack = new GenericStackClass<IDisplayable>();

            // Add string to displayable stack
            displayStack.push(new StringStack("Showing Solutions..."));

            // Start recursive system to find solutions
            SolutionFinder.placeOrBacktrack(queenStack, 0, 0, false, displayStack);

            // Add solution stack to displayable stack
            displayStack.push(SolutionFinder.solutionStack);


            // Prompt user for validity checks
            Console.WriteLine("Show validity checks? (y/n): ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Validity Check Count: {0}", SolutionFinder.validityCheckCount);
                displayStack.push(new StringStack("Showing validity check..."));
                SolutionFinder.placeOrBacktrack(queenStack, 0, 0, true, displayStack);
            }

            // Print all displayables
            for (int i = 0; i < displayStack.size(); i++)
            {
                IDisplayable displayableStack = displayStack.get(i);
                Console.WriteLine(displayableStack.toString());
            } 

            // Pause so user can read
            Console.ReadLine();
        }
    }
}
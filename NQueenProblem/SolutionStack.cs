using GenericStackLibrary;

namespace NQueenProblem
{
    class SolutionStack : GenericStackClass<QueenStack>
    {
        /// <summary>
        /// SolutionStack is used to contain multiple solutions (QueenStacks)
        /// and display these as a generic IDisplayable in Program.cs
        /// The toString() function is overridden here
        /// </summary>
        public override string toString()
        {
            string str = "";
            str += "Number of solutions: " + size().ToString() + "\n";
            for (int i = 0; i < size(); i++)
            {
                str += "Solution " + (i + 1).ToString() + ": \n";
                QueenStack solution = get(i);
                str += solution.toString();
            }
            return str;
        }
    }
}
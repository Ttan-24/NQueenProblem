using GenericStackLibrary;

namespace NQueenProblem
{
    class SolutionStack : GenericStackClass<QueenStack>
    {
        // displaying all the solutions from the SolutionFinder 
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
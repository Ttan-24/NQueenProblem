using GenericStackLibrary;
using System;

namespace NQueenProblem
{


    /// <summary>
    ///  This class is used to find solutions for a given grid of queens.
    ///  
    /// This data is provided in the placeOrBacktrack function, and recursively
    /// processed using backtracking to find valid solutions for the problem
    /// 
    /// It is also given a reference to a stack of IDisplayable objects, which
    /// can be populated with various IDisplayable types to be displayed
    /// to the user once the recursive function is finished.
    /// 
    /// Process:
    /// Keep incrementing X until a valid position is found
    /// If a valid position is found, then place the queen and increment Y and reset X
    /// If no good position is found, Y is backtracked and X is reset, and the last queen from the stack is removed
    /// If Y is backtracked to -1, then the function fails and is returned 
    /// </summary>
    class SolutionFinder
    {
        public static int solutionCount;
        public static int validityCheckCount;
        public static SolutionStack solutionStack = new SolutionStack();
        public static void placeOrBacktrack(QueenStack queenGrid, int xstart, int y, bool showValidityCheck, GenericStackClass<IDisplayable> displayStack)
        {
            // Exit when at very end
            if (xstart == queenGrid.gridSize && y == 0)
            {
                return;
            }

            // Add solution if at end of rows
            if (y == queenGrid.gridSize) // Reached end
            {
                if (showValidityCheck)
                {
                    displayStack.push(new StringStack("Solution found!"));
                }
                solutionCount++;
                solutionStack.push(new QueenStack(queenGrid)); // Add this solution // copy constructor

                // Backtrack again to find more solutions
                int previousX = queenGrid.top().x;
                queenGrid.pop();
                placeOrBacktrack(queenGrid, previousX + 1, y - 1, showValidityCheck, displayStack);
                return;
            }

            // Check to place queen
            for (int x = xstart; x < queenGrid.gridSize; x++) //x
            {
                validityCheckCount++;
                if (queenGrid.canPutQueen(x, y))
                {
                    queenGrid.addQueen(x, y);
                    if (showValidityCheck)
                    {
                        displayStack.push(new QueenStack(queenGrid));
                    }

                    placeOrBacktrack(queenGrid, 0, y + 1, showValidityCheck, displayStack); // Progress
                    return;
                }
            }

            // Backtrack if could not place queen
            int previousx = queenGrid.top().x; // Remember last queen's X
            queenGrid.pop(); // Remove last queen
            placeOrBacktrack(queenGrid, previousx + 1, y - 1, showValidityCheck, displayStack); // Try place new queen in previous place
            //displayGrid(gridSize, gridSize);

            // Return
            return;
        }
    }
}
using GenericStackLibrary;
using System;

namespace NQueenProblem
{
    //Data:
    //- X position
    //- Y position
    //- List of queens(they all know their attack positions)

    //Functions:
    //- Add queen(adds to stack and sets their attack positions)
    //- Check position(check if no one can attack it)

    //Process:
    //- Keep incrementing Y until you find a good position
    //- IF you find a good position then you place a queen and increment X and reset Y
    //- IF you find no good positions, you backtrack Y and remove the last queen from the stack
    //- If Y gets backtracked to -1, then the program fails
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
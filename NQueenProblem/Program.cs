using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStackLibrary;

namespace NQueenProblem
{
    interface IDisplayable
    {
        void Display();
    }

    class Position
    {
        public int x;
        public int y;
    }

    class Queen : Position
    {
        public GenericStackClass<Position> attackPositionStack = new GenericStackClass<Position>();
        public Queen(int paramX, int paramY, int gridSize)
        {
            x = paramX;
            y = paramY;

            SetAttackPositions(gridSize);
        }

        public void SetAttackPositions(int gridSize)
        {
            // Horizontal
            for (int i = 0; i < gridSize; i++)
            {
                Position p = new Position();
                p.x = i;
                p.y = y;
                attackPositionStack.push(p);
            }

            // Vertical
            for (int i = 0; i < gridSize; i++)
            {
                Position p = new Position();
                p.y = i;
                p.x = x;
                attackPositionStack.push(p);
            }

            // Diagonal
            // Up left
            int x1 = x;
            int y1 = y;
            while (x1 >= 0 && y1 >= 0)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1--;
                y1--;
                attackPositionStack.push(p);
            }
            // Down right
            x1 = x;   //reset the position
            y1 = y;
            while (x1 < gridSize && y1 < gridSize)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1++;
                y1++;
                attackPositionStack.push(p);
            }
            // Down left
            x1 = x;
            y1 = y;
            while (x1 >= 0 && y1 < gridSize)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1--;
                y1++;
                attackPositionStack.push(p);
            }
            // Up right
            x1 = x;
            y1 = y;
            while (x1 < gridSize && y1 >= 0)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1++;
                y1--;
                attackPositionStack.push(p);
            }
        }
    }

    class QueenStack : GenericStackClass<Queen>, IDisplayable
    {
        public int gridSize;
        public QueenStack() { }
        public QueenStack(QueenStack stackToCopyFrom)
        {
            // Copy stack
            for (int i = 0; i < maxSize; i++)
            {
                if (stackToCopyFrom.get(i) != null)
                {
                    push(stackToCopyFrom.get(i));
                }
            }

            // Copy size
            gridSize = stackToCopyFrom.gridSize;
        }
        public void Display()
        {
            for (int i = 0; i < gridSize; i++)
            {

                for (int j = 0; j < gridSize; j++)
                {
                    bool queenIsHere = false;
                    for (int k = 0; k < size(); k++)
                    {
                        Queen q = get(k);
                        if (q.x == j && q.y == i)
                        {
                            queenIsHere = true;
                        }
                    }

                    if (queenIsHere)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class SolutionStack : GenericStackClass<QueenStack>, IDisplayable
    {
        public void Display()
        {
            Console.WriteLine("Number of solutions: " + size());
            for (int i = 0; i < size(); i++)
            {
                Console.WriteLine("Solution {0}: ", i + 1);
                QueenStack solution = get(i);
                solution.Display();
            }
        }
    }

    class Program
    {
        static int gridSize;    // 16 cannot happen due to stack overflow. my recursion is too deep to the point it dies :(
        static QueenStack queenStack = new QueenStack();
        static SolutionStack solutionStack = new SolutionStack();
        static int solutionCount = 0;
        static int validityCheckCount = 0;

        static void addQueen(int x, int y)
        {
            Queen Q = new Queen(x, y, gridSize);
            queenStack.push(Q);
        }

        //tells you if it is an okay place or not
        static bool canPutQueen(int x, int y)
        {
            // check all the positions
            for (int i = 0; i < queenStack.size(); i++)
            {
                Queen Q = queenStack.get(i);
                for (int j = 0; j < Q.attackPositionStack.size(); j++)
                {
                    Position p = Q.attackPositionStack.get(j);
                    if (x == p.x && y == p.y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
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

        static void PlaceOrBacktrack(int xstart, int y, bool showValidityCheck)
        {
            // Exit when at very end
            if (xstart == gridSize && y == 0)
            {
                return;
            }

            // Add solution if at end of rows
            if (y == gridSize) // Reached end
            {
                if (showValidityCheck)
                {
                    Console.WriteLine("Solution found!");
                    Console.WriteLine();
                }
                solutionCount++;
                solutionStack.push(new QueenStack(queenStack)); // Add this solution // copy constructor

                // Backtrack again to find more solutions
                int previousX = queenStack.top().x;
                queenStack.pop();
                PlaceOrBacktrack(previousX + 1, y - 1, showValidityCheck);
                return;
            }

            // Check to place queen
            for (int x = xstart; x < gridSize; x++) //x
            {
                validityCheckCount++;
                if (canPutQueen(x, y))
                {
                    addQueen(x, y);
                    if (showValidityCheck)
                    {
                        queenStack.Display();
                    }
                    
                    PlaceOrBacktrack(0, y + 1, showValidityCheck); // Progress
                    return;
                }
            }

            // Backtrack if could not place queen
            int previousx = queenStack.top().x; // Remember last queen's X
            queenStack.pop(); // Remove last queen
            PlaceOrBacktrack(previousx + 1, y - 1, showValidityCheck); // Try place new queen in previous place
            //displayGrid(gridSize, gridSize);

            // Return
            return;
        }


        static void Main(string[] args)
        {
            bool correctInput = false;
            while (correctInput == false)
            {
                try
                {
                    // Get grid size
                    Console.WriteLine("Input size: ");
                    gridSize = Int32.Parse(Console.ReadLine());
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

            // Start recursive system to find solutions
            PlaceOrBacktrack(0, 0, false);

            // Display all solutions
            solutionStack.Display();

            // Prompt user for validity checks
            Console.WriteLine("Show validity checks? (y/n): ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Validity Check Count: {0}", validityCheckCount);
                PlaceOrBacktrack(0, 0, true);
            }
            

            // Pause so user can read
            Console.ReadLine();
        }
    }
}
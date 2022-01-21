using GenericStackLibrary;

namespace NQueenProblem
{
    class QueenStack : GenericStackClass<Queen>
    {
        /// Member Variables ///
        private int gridSize;

        public void setGridSize(int _gridSize) 
        {
            gridSize = _gridSize;
        }

        public int getGridSize()
        {
            return gridSize;
        }

        /// Constructors ///
        // Default Constructor
        public QueenStack() { }
        // Copy constructor - used for copying QueenStacks when used as saved valid solutions in SolutionFinder
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


        /// Member Functions ///
        // Adds a queen to the stack (the constructor of which will create new attack positions)
        public void addQueen(int x, int y)
        {
            Queen Q = new Queen(x, y, gridSize);
            push(Q);
        }

        // Returns if a queen can be placed at the designated coordinates when checked against the listed attack positions
        public bool canPutQueen(int x, int y)
        {
            // check all the positions
            for (int i = 0; i < size(); i++)
            {
                Queen Q = get(i);
                for (int j = 0; j < Q.getAttackPositions().size(); j++)
                {
                    Position p = Q.getAttackPositions().get(j);
                    if (x == p.x && y == p.y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Display function to override the IDisplayable function inherited in GenericStackLibrary. Used to display as a solution
        public override string toString()
        {
            string str = "";
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
                        str += "Q ";
                    }
                    else
                    {
                        str += "- ";
                    }
                }
                str += "\n";
            }
            str += "\n";
            return str;
        }
    }
}
using GenericStackLibrary;

namespace NQueenProblem
{
    class Queen : Position
    {
        /// <summary>
        /// The Queen class is used to represent queens on grids
        /// and their positions, as well as their potential attack positions.
        /// 
        /// This data is stored and used to determine where other queens can
        /// be placed during the SolutionFinder function.
        /// 
        /// It inherits from Position so that the X and Y values can be used,
        /// and also uses Position to store the different attack positions.
        /// </summary>
        
        /// Member Variables ///
        private GenericStackClass<Position> attackPositionStack = new GenericStackClass<Position>();


        /// Constructors ///
        // The only constructor needed is this which will set the X and Y as well as set all attack positions relevant to those coordinates
        public Queen(int paramX, int paramY, int gridSize)
        {
            x = paramX;
            y = paramY;

            setAttackPositions(gridSize);
        }

        public GenericStackClass<Position> getAttackPositions()
        {
            return attackPositionStack;
        }

        /// Member Functions ///
        // Stores all relevant attack positions to be iterated through when checking future positions on a QueenStack
        private void setAttackPositions(int gridSize)
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
}
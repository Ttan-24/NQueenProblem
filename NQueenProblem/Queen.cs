using GenericStackLibrary;

namespace NQueenProblem
{
    class Queen : Position
    {
        public GenericStackClass<Position> attackPositionStack = new GenericStackClass<Position>();
        public Queen(int paramX, int paramY, int gridSize)
        {
            x = paramX;
            y = paramY;

            setAttackPositions(gridSize);
        }

        public void setAttackPositions(int gridSize)
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
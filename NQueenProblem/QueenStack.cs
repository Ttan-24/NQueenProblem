using GenericStackLibrary;

namespace NQueenProblem
{
    class QueenStack : GenericStackClass<Queen>
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

        public void addQueen(int x, int y)
        {
            Queen Q = new Queen(x, y, gridSize);
            push(Q);
        }

        //tells you if it is an okay place or not
        public bool canPutQueen(int x, int y)
        {
            // check all the positions
            for (int i = 0; i < size(); i++)
            {
                Queen Q = get(i);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStackLibrary;

namespace NQueenProblem
{
    class Queen
    {
        public int x;
        public int y;
        public GenericStackClass<Position> attackPositionStack = new GenericStackClass<Position>();
    }

    class Position
    {
        public int x;
        public int y;
    }

    class Program
    {
        int x_position;
        int y_position;
        static GenericStackClass<Queen> queenStack = new GenericStackClass<Queen>();

        static void displayGrid(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                
                for (int j = 0; j < x; j++)
                {
                    bool queenIsHere = false;
                    for (int k = 0; k < queenStack.size(); k++)
                    {
                        Queen q = queenStack.get(k);
                        if (q.x == j && q.y == i)
                        {
                            queenIsHere = true;
                        }
                    }

                    if (queenIsHere)
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void addQueen(int x, int y)
        {
            Queen Q = new Queen();
            Q.x = x;
            Q.y = y;
            queenStack.push(Q);

            // Horizontal
            for (int i = 0; i <= 3; i++)
            {
                Position p = new Position();
                p.x = i;
                p.y = Q.y;
                Q.attackPositionStack.push(p);
            }

            // Vertical
            for (int i = 0; i <= 3; i++)
            {
                Position p = new Position();
                p.y = i;
                p.x = Q.x;
                Q.attackPositionStack.push(p);
            }

            // Diagonal
            int x1 = Q.x;
            int y1 = Q.y;
            while (x1 > 0 && y1 > 0)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1--;
                y1--;
                Q.attackPositionStack.push(p);
            }
            x1 = Q.x;   //reset the position
            y1 = Q.y;
            while (x1 < 4 && y1 < 4)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1++;
                y1++;
                Q.attackPositionStack.push(p);
            }
            x1 = Q.x;
            y1 = Q.y;
            while (x1 > 0 && y1 < 4)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1--;
                y1++;
                Q.attackPositionStack.push(p);
            }
            x1 = Q.x;
            y1 = Q.y;
            while (x1 < 4 && y1 > 0)
            {
                Position p = new Position();
                p.x = x1;
                p.y = y1;
                x1++;
                y1--;
                Q.attackPositionStack.push(p);
            }
        }

        //tells you if it is an okay place or not
        static bool canPutQueen (int x, int y)
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


        static void Main(string[] args)
        {
            addQueen(2, 0);
            for (int i = 0; i < 4; i++) //y
            {
                for (int j = 0; j < 4; j++) //x
                {
                    if (canPutQueen(j, i))
                    {
                        addQueen(j, i);
                        displayGrid(4, 4);
                    }
                }

            }
            displayGrid(4, 4);
            Console.ReadLine();
        }
    }
}

using GenericStackLibrary;

namespace NQueenProblem
{
    class StringStack : GenericStackClass<char>
    {
        public StringStack(string inString)
        {
            foreach (char character in inString)
            {
                push(character);
            }
        }
    }
}
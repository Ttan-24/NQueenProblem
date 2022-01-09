using GenericStackLibrary;

namespace NQueenProblem
{
    /// <summary>
    /// String stack used for being displayed as a
    /// generic IDisplayable in Program.cs when
    /// solutions have been found
    /// </summary>
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
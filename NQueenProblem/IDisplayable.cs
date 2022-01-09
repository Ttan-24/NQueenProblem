namespace GenericStackLibrary
{
    interface IDisplayable
	{
		/// <summary>
		/// This interface is used to define displayable
		/// classes, which can be stored as generic 
		/// displayable objects which implement toString(), 
		/// so that the data can be displayed to the user 
		/// in a generic collection of IDisplayables after
		/// SolutionFinder has finished finding solutions.
		/// </summary>

		string toString();
	}
}

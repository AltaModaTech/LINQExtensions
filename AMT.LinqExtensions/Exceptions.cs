namespace AMT.LinqExtensions
{
	public class AllElementsExcluded : System.Exception
	{
		public AllElementsExcluded(string message = DEFAULT_MESSAGE) : base(message) {}


		private const string DEFAULT_MESSAGE = "No unexcluded elements remain.";
	}
}
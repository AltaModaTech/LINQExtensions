using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace AMT.LinqExtensions
{
	
	///<summary>Randomized operations for LINQ.</summary>
	public static class LinqRandomizer
	{
		private static System.Random _randomizer = new System.Random(DateTime.Now.Millisecond);


		#region Public LINQ methods

		///<summary>Returns a random element from a collection</summary>
		///<typeparam name="T">The element type of the collection</typeparam>
		///<param cref="elements">An ICollection of the specified type <seealso cref="T" /></param>
		///<exception cref="System.ArgumentOutOfRangeException">Thrown when the list is empty</exception>
		public static T Random<T> (this ICollection<T> elements)
		{
			return elements.ElementAt(_randomizer.Next(0, elements.Count - 1));
		}

		#endregion Public LINQ methods
	}

}

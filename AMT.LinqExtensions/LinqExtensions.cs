using System;
using System.Collections.Generic;
using System.Linq;


namespace AMT.LinqExtensions
{
	
	///<summary>Randomized operations for LINQ.</summary>
	public static class LinqRandomizer
	{
		private static System.Random _randomizer = new System.Random(DateTime.Now.Millisecond);


		#region Public LINQ methods

		///<summary>Returns a random element from a collection.</summary>
		///<typeparam name="T">The element type of the collection.</typeparam>
		///<param cref="elements">An ICollection of the specified type <seealso cref="T" />.</param>
		///<exception cref="System.ArgumentOutOfRangeException">Thrown if the ICollection is empty.</exception>
		///<exception cref="AMT.LinqExtensions.AllElementsExcluded">Thrown if all elements have been excluded.</exception>
		public static T Random<T> (this ICollection<T> elements, IEnumerable<T> exclusions = null)
		{
			// Delegate to overload taking IEnumerable 
			return Random<T>(elements as IEnumerable<T>, exclusions);
		}


		///<summary>Returns a random element using an enumerable.</summary>
		///<typeparam name="T">The element type of the enumerable.</typeparam>
		///<param cref="elements">An IEnumerable of the specified type <seealso cref="T" />.</param>
		///<exception cref="System.ArgumentOutOfRangeException">Thrown if the IEnumerable is empty.</exception>
		///<exception cref="AMT.LinqExtensions.AllElementsExcluded">Thrown if all elements have been excluded.</exception>
		public static T Random<T>(this IEnumerable<T> elements, IEnumerable<T> exclusions = null)
		{
			exclusions ??= new List<T>();

			T result;
			int iterations = 0;
			do
			{
				result = elements.ElementAt(_randomizer.Next(0, elements.Count() - 1));
				++iterations;
			} while (exclusions.Contains<T>(result) && iterations < elements.Count());

			// TODO: this approach assumes that each element has been considered. If the randomizer
			//	repeats some values, not all elements will be considered.
			
			// Reached the end of the collection (possibly) without finding an element that is not excluded.
			if (iterations == elements.Count() && exclusions.Contains(result))
			{
				throw new AllElementsExcluded();
			}

			return result;
		}


		#endregion Public LINQ methods
	}

}

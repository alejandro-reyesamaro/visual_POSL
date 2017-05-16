using System;

namespace POSL.Data
{
	/*!
	 * \class ElementsChangeIterator
	 * \brief Interface to represent an iterator
	 * \author Alejandro Reyes
 	 * \date 2017-05-16
	 */
	public class ElementsChangeIterator : IPOSL_Iterator
	{
		private Neighborhood neighborhood;
		private int current;

		//! Main constructor.
		/*!
            \param _n The neigjborhood to iterate with
         */
		public ElementsChangeIterator(Neighborhood _n)
		{
			neighborhood = _n;
			current = 0;
		}
		//! From <IPOSL_Iterator>
		public int[] GetNext()
		{
			return neighborhood[current ++];
		}
		//! From <IPOSL_Iterator>
		public bool SomeNext()
		{
			return current < neighborhood.Size;
		}
		//! From <IPOSL_Iterator>
		public void Reset()
		{
			current = 0;
		}
	}
}


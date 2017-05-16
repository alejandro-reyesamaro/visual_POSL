using System;

namespace POSL.Data
{
	/*!
	 * \class POSL_Iterator
	 * \brief Interface to represent iterators
	 * \author Alejandro Reyes
 	 * \date 2017-05-16
	 */
	public interface IPOSL_Iterator
	{
		//! Returns the next element in the iteration
		int[] GetNext();
		//! Whether there is a new element in the next iteration
		bool SomeNext();
		//! Resets the iterator
		void Reset();
	}
}


using System;

namespace POSL
{
	/*!
	 * \class Domain 
	 * \brief Class to represent the domain of a variable
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
	 */
	public abstract class Domain
	{
		//! Returns the domain of the a given variable
		/*!
            \param variable Index of the variable
            \return The domain of the given variable
         */
		public abstract int[] GetValues(int variable);
		//! Returns minimun of the domain of a given variable
		/*!
            \param variable Index of the variable
            \return The minimum value
         */
		public abstract int minimum(int variable);
		//! Returns maximum of the domain of a given variable
		/*!
            \param variable Index of the variable
            \return The maximum value
         */
		public abstract int maximum(int variable);
	}
}
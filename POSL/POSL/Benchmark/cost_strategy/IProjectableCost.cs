using System;

namespace POSL.Benchmarks
{
	/*!
	 * \class IProjectableCost
	 * \brief Interface to represent the a class that can projec the cost of a variable
	 * \author Alejandro Reyes
 	 * \date 2017-05-13
	 */
	public interface IProjectableCost
	{
		//! Computes the projected cost of a variable.
		/*!
            \param variable_index Index of a variable.
            \return Projected cost of a given variable.
         */
		int costOnVariable(int variable_index);
	}
}


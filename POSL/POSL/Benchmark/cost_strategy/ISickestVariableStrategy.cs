using System;

/**
 * POSL
 *
 * \brief Interface to represent a strategy to return the variable with the highest projected cost
 * \author Alejandro Reyes
 * \date 2017-05-13
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class ISickestVariableStrategy
	 * \brief Interface to represent a strategy to compute the variable with the highest projected cost
	 */
	public interface ISickestVariableStrategy
	{
		//! Returns the variable with the highest projected cost
		/*!
    		\return The index of the variable with the highest projected cost.
     	*/
		int sickestVariable();
	}
}


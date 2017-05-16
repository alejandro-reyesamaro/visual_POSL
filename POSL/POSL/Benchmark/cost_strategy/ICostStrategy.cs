using System;
using POSL.Data;

/**
 * POSL
 *
 * \brief Interface to represent an absolute solution cost strategy
 * \author Alejandro Reyes
 * \date 2016-05-13
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class ICostStrategy
	 * \brief Interface to represent an absolute solution cost strategy
	 */
	public interface ICostStrategy
	{
		//! Computes the cost of a configuration.
		/*!
        \param _configuration A configuration (solution).
        \return Cost of the given configuration.
     	*/
		int solutionCost(Solution solution);
	}
}


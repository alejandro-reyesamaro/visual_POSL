using System;
using POSL.Data;

/**
 * POSL
 *
 * \brief Interface to represent the way a problem shows its result (solution)
 * \author Alejandro Reyes
 * \date 2017-05-14
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class IShowStrategy 
	 * \brief Interface to represent the way a problem shows its result (solution)
	 */
	public interface IShowStrategy
	{
		//! Default constructor.
		/*!
            \param solution A solution to some problem.
            \return String to show
         */
		string showSolution(Solution solution);
	}
}


using System;
using POSL.Data;

namespace POSL.Benchmarks
{
	/*!
	 * \class IShowStrategy 
	 * \brief Interface to represent the way a problem shows its result (solution)
	 * \author Alejandro Reyes
     * \date 2017-05-14
	 */
	public interface IShowStrategy
	{
		//! Main constructor.
		/*!
            \param solution A solution to some problem.
            \return String to show
         */
		string showSolution(Solution solution);
	}
}


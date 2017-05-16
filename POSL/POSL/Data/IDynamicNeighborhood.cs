using System;
using POSL.Solver;

namespace POSL.Data
{
	/*!
	 * \class Neighborhood 
	 * \brief (Interface to represent a dynamic neighborhood of a configuration
	 * \author Alejandro Reyes
 	 * \date 2017-05-16
	 */
	public interface IDynamicNeighborhood
	{
		void init(PSP psp, int[] _configuration);
	}
}


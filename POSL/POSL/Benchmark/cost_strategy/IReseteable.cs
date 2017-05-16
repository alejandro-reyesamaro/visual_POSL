using System;

namespace POSL.Benchmarks
{
	/*!
	 * \class IReseteable
	 * \brief Interface to represent a relative solution cost strategy
	 * \author Alejandro Reyes
 	 * \date 2017-05-13
	 */
	public interface IReseteable
	{
		//! Performs a reset w.r.t. the current configuration
		/*!
            \return A <i>reseted</i> configuration.
         */
		int[] reset();
	}
}


using System;

/**
 * POSL
 *
 * \brief Interface to represent a class that performs a reset
 * \author Alejandro Reyes
 * \date 2017-05-13
 */
namespace POSL.Benchmark
{
	/*!
	 * \class Reseteable reseteable.h
	 * \brief Interface to represent a relative solution cost strategy
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


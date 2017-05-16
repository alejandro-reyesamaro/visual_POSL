using System;

namespace POSL.Data
{
	/*!
	 * \class ComputationData
	 * \brief (Abstract) Class to represent all types of I/O in POSL
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
	 */
	public abstract class ComputationData
	{
		//public abstract FactoryPacker BuildPacker();
		public abstract string Tag();

		//! Compare this object with other, given a function (criteria)
		/*!
            \param other The ComputationData to compare with.
            \param criteria A function (criteria).
            \return -1 if THIS is lower, 1 if THIS is bigger, 0 if equals
         */
		public abstract int comapareTo(ComputationData other, Func<ComputationData, int> criteria);
	}
}


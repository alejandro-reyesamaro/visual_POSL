using System;

namespace POSL
{
	/*!
	 * \class Domain domain.h
	 * \brief Class to represent the domain of a variable
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
	 */
	public abstract class Domain
	{
		public abstract int[] GetValues(int variable);
		public abstract int minimum(int variable);
		public abstract int maximum(int variable);
	}
}
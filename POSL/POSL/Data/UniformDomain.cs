using System;
using POSL.Tools;

namespace POSL.Data
{
	/*!
	 * \class UniformDomain
	 * \brief Class to represent the domain of a variable (uniform)
	 * \author Alejandro Reyes
 	 * \date 2017-05-16
	 */
	public class UniformDomain : Domain
	{
		private int min_value; 
		private int max_value;

		//! Main costructor
		/*!
            \param _min_value Minimum value of all domains (all are the same)
            \param _max_value Maximum value of all domains (all are the same)
         */
		public UniformDomain(int _min_value, int _max_value)
		{
			min_value = _min_value;
			max_value = _max_value;
		}
		//! From <Domain>
		public override int[] GetValues(int variable)
		{
			return PoslTools.generateMonotony(min_value, max_value);
		}
		//! From <Domain>
		public override int minimum(int variable)
		{
			return min_value;
		}
		//! From <Domain>
		public override int maximum(int variable)
		{
			return max_value;
		}
	}
}


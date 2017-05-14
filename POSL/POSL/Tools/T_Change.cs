using System;

/**
 * POSL
 *
 * \brief Interface to represent the a class that can projec the cost of a variable
 * \author Alejandro Reyes
 * \date 2017-05-13
 */
namespace POSL.Tools
{
	public struct T_Changes
	{
		//! Index in the configuration vector
		private int[] positions;
		public int[] Positions { get{ return this.positions; } }

		//! New values
		private int[] new_values;
		public int[] NewValues { get{ return this.new_values; } }

		//! Number of changes
		private int dim;
		public int Dimension { get{ return this.dim; } }

		public T_Changes (int[] positions, int[] new_values)
		{
			if (positions.Length != new_values.Length)
				throw new InvalidOperationException ("POSL_Execption: not possible to create T_Change");
			this.positions = positions;
			this.new_values = new_values;
			this.dim = new_values.Length;
		}
	}
}


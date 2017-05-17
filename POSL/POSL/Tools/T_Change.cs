using System;

namespace POSL.Tools
{
	/*!
	 * \class RandomGenerator 
	 * \brief Class changes performes into a configuration w.r.t. other
	 * \author Alejandro Reyes
 	 * \date 2017-05-17
	 */
	public struct T_Changes
	{
		private int[] positions; /*!< Indexes in the configuration vector */
		//! (Property) Returns indexes in the configuration vector
		public int[] Positions { get{ return this.positions; } }

		private int[] new_values; /*!< New values */
		//! (Property) Returns the new values of the configuration vector
		public int[] NewValues { get{ return this.new_values; } }

		private int dim; /*!<Number of changes */
		//! (Property) Returns the number of performed changes
		public int Dimension { get{ return this.dim; } }

		//! Main costructor
		/*!
            \param positions Indexes in the configuration vector
            \param new_values The new values of the configuration vector
         */
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


using System;

namespace POSL.Data
{
	/*!
	 * \class Neighborhood 
	 * \brief (Abstract) Class to represent a neighborhood of a configuration
	 * \author Alejandro Reyes
 	 * \date 2017-05-15
	 */
	public abstract class Neighborhood : ComputationData
	{
		private int[] current_configuration;
		public int[] CurrentConfiguration{ get{ return current_configuration; } }

		//! Main costructor
		/*!
            \param _current_configuration Current solution (configuration)
         */
		public Neighborhood(int[] _current_configuration)
		{
			current_configuration = _current_configuration;
		}

		//! Constructor to build an "empty" neighborhood
		/*!
            \param _conf_size The size of the configuration
         */
		public Neighborhood(int _config_size)
		{
			current_configuration = new int[_config_size];
		}

		//! From <ComputationData>
		public override string Tag { get { return "cd_N"; } }

		//! (Property) Returns the packing ID (ID for the communication)
		public string SolutionPackingID { get { return "658203" ;} } 

		//! From <ComputationData>
		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag == Tag) // TAGNEIGHBORHOOD
			{
				int ranking_this = Size;
				int ranking_other = ((Neighborhood)other).Size;
				int difference = ranking_this - ranking_other;
				return (difference == 0) ? 0 : difference / Math.Abs(difference);
			}
			else throw new Exception("(POSL Exception) Not compearing allowed (Neighborhood::comapareTo)");
		}

		//! Returns an iterator to the elements of the neighborhood (configurations)
		/*!
            \return An instance of a class derived from IPOSL_Iterator
         */
		public abstract IPOSL_Iterator getIterator();

		//! Abstract property to return the number of configurations in the neighborhood
		/*!
            \return Neighborhood size
         */
		public abstract int Size { get; }

		//! Default property: the i-th configuration
		/*!
            \return The i-th configuration
         */
		public abstract int[] this[int i] { get; }
	}
}


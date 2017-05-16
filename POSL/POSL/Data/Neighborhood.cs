using System;

/**
 * POSL
 *
 * \brief (Abstract) Class to represent a neighborhood of a configuration
 * \author Alejandro Reyes
 * \date 2017-05-15
 */
namespace POSL.Data
{
	/*!
	 * \class Neighborhood neighborhood.h
	 * \brief (Abstract) Class to represent a neighborhood of a configuration
	 */
	public abstract class Neighborhood : ComputationData
	{
		private int[] current_configuration;
		public int[] CurrentConfiguration{ get{ return current_configuration; } }

		public Neighborhood(int[] _current_configuration)
		{
			current_configuration = _current_configuration;
		}

		public Neighborhood(int _config_size)
		{
			current_configuration = new int[_config_size];
		}

		public override string Tag() { return "cd_N"; }
		public string SolutionPackingID { get { return "658203" ;} } 

		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag() == Tag()) // TAGNEIGHBORHOOD
			{
				int ranking_this = Size;
				int ranking_other = ((Neighborhood)other).Size;
				int difference = ranking_this - ranking_other;
				return (difference == 0) ? 0 : difference / Math.Abs(difference);
			}
			else throw new Exception("(POSL Exception) Not compearing allowed (Neighborhood::comapareTo)");
		}

		public abstract IPOSL_Iterator getIterator();
		public abstract int Size { get; }
		public abstract int[] this[int index] { get; }
	}
}


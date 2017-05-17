using System;
using POSL.Tools;

namespace POSL.Data
{
	/*!
	 * \class DecisionPair
	 * \brief Class to represent a couple of solutions (current and new found)
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
	 */
	public class DecisionPair : ComputationData
	{
		private Solution current;
		//! (Property) Returns the current solution
		public Solution GetCurrent { get{ return current; } }

		private Solution found;
		//! (Property) Returns the found solution
		public Solution GetFound{ get{ return found; } }

		//! From <ComputationData>
		public override string Tag { get { return "cd_DP"; } }

		//! (Property) Returns the packing ID (ID for the communication)
		public string SolutionPackingID { get { return "658202" ;} } 

		//! Main constructor.
		/*!
            \param _current Current solution
            \param _found Found solution
         */
		public DecisionPair(Solution _current, Solution _found)
		{
			current = _current;
			found = _found;
		}

		//! Updates the object from configurations
		/*!
            \param _current Current solution
            \param _found Found solution
         */
		public void update(int[] _current, int[] _found)
		{
			current.update(_current);
			found.update(_found);
		}

		//! Updates the object from a buffer
		/*!
            \param pack A buffer of integers
         */
		void updateFromPack(int[] pack)
		{
			int conf_size = pack[1];
			int[] config1 = new int[conf_size];
			int[] config2 = new int[conf_size];
			PoslTools.copy (pack, 2, 2 + conf_size, config1, 0);
			//copy(pack + 2, pack + conf_size + 2, config1.begin());
			PoslTools.copy (pack, 2 + conf_size, 2 * conf_size + 2, config2, 0);
			//copy(pack + conf_size + 2, pack + 2 * conf_size + 2, config2.begin());
			current.update(config1);
			found.update(config2);
		}

		//! (Property) Returns whether both configurations are equals
		public bool BothEquals { get{ return current.Equals (found); } }

		//! From <Object>
		public override bool Equals(object other)
		{ 
			if (other is DecisionPair)
			{
				return current.Equals(((DecisionPair)other).GetCurrent) && found.Equals(((DecisionPair)other).GetFound) ; 
			}
			else return false;
		}

		//! From <Object>
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		//std::shared_ptr<FactoryPacker> DecisionPair::BuildPacker(){ return std::make_shared<FactoryDecisionPairPacker>(shared_from_this()); }

		//! From <ComputationData>
		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag == this.Tag)
			{
				int ranking_this = criteria(found);
				int ranking_other = criteria(((DecisionPair)other).GetFound);
				int difference = ranking_this - ranking_other;
				return (difference == 0) ? 0 : difference / Math.Abs(difference);
			}
			else throw new Exception("(POSL Exception) Not compearing allowed (DecisionPair::comapareTo)");
		}
	}
}


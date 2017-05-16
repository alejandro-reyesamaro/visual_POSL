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
		public Solution GetCurrent { get{ return current; } }

		private Solution found;
		public Solution GetFound{ get{ return found; } }

		public override string Tag() { return "cd_DP"; }

		public string SolutionPackingID { get { return "658202" ;} } 

		public DecisionPair(Solution _current, Solution _found)
		{
			current = _current;
			found = _found;
		}

		void update(int[] _current, int[] _found)
		{
			current.updateConfiguration(_current);
			found.updateConfiguration(_found);
		}

		void updateFromPack(int[] pack)
		{
			int conf_size = pack[1];
			int[] config1 = new int[conf_size];
			int[] config2 = new int[conf_size];
			PoslTools.copy (pack, 2, 2 + conf_size, config1, 0);
			//copy(pack + 2, pack + conf_size + 2, config1.begin());
			PoslTools.copy (pack, 2 + conf_size, 2 * conf_size + 2, config2, 0);
			//copy(pack + conf_size + 2, pack + 2 * conf_size + 2, config2.begin());
			current.updateConfiguration(config1);
			found.updateConfiguration(config2);
		}

		public bool BothEquals()
		{
			return current.Equals(found);
		}

		public override bool Equals(object other)
		{ 
			if (other is DecisionPair)
			{
				return current.Equals(((DecisionPair)other).GetCurrent) && found.Equals(((DecisionPair)other).GetFound) ; 
			}
			else return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		//std::shared_ptr<FactoryPacker> DecisionPair::BuildPacker(){ return std::make_shared<FactoryDecisionPairPacker>(shared_from_this()); }

		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag() == Tag())
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


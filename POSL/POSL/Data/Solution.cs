using System;
using POSL.Tools;
using System.Collections.Generic;

namespace POSL.Data
{
	/*!
	 * \class Solution solution.h
	 * \brief Class to represent a solution (configuration)
	 * \author Alejandro Reyes
 	 * \date 2017-05-15
	 */
	public class Solution : ComputationData
	{
		private Domain variables_domains;
		private int[] configuration;

		public int[] GetConfByCopy { 
			get { 
				return (int[])configuration.Clone ();
			}
		}

		public int this[int index] 
		{ 
			get { return configuration[index]; } 
			set { configuration [index] = value; }
		}

		public int Length { get { return configuration.Length; } }

		public Domain GetVariablesDomain{ get { return variables_domains; } }

		public override string Tag() { return "cd_S"; }
		public string SolutionPackingID { get { return "658201" ;} } 

		public Solution(Domain _domains, int dimension)
		{
			variables_domains = _domains;
			configuration = new int[dimension];
		}

		public Solution(Domain _domains, int[] conf)
		{
			variables_domains = _domains;
			configuration = new int[conf.Length];
			Array.Copy (conf, configuration, conf.Length);
		}

		public Solution clone ()
		{
			int[] conf = new int[this.configuration.Length];
			Array.Copy (this.configuration, conf, conf.Length);
			return new Solution (this.variables_domains, conf);
		}

		public void updateConfiguration(int[] new_config)
		{
			if(new_config.Length != configuration.Length)
				throw new Exception("(POSL Exception) Configurations sizes missmatch (Solution.UpdateConfiguration)");
			//std::copy(new_config.begin(), new_config.end(), configuration.begin());
			Array.Copy(new_config, configuration, 0);
		}

		public void updateConfigurationFromPack(int[] pack)
		{
			PoslTools.copy(pack, 2, 2 + configuration.Length, configuration, 0);
		}

		public override bool Equals(object other)
		{
			if (!(other is Solution))
				return false;
			return this == ((Solution)other) || PoslTools.equals_vectors(((Solution)other).configuration, this.configuration);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		public override string ToString(){ return PoslTools.configurationToString(configuration); }

		//shared_ptr<FactoryPacker> Solution::BuildPacker(){ return make_shared<FactorySolutionPacker>(shared_from_this()); }

		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag() == Tag()) // TAGSOLUTION
			{
				int ranking_this = criteria(this);
				int ranking_other = criteria((Solution)other);
				int difference = ranking_this - ranking_other;
				return (difference == 0) ? 0 : difference / Math.Abs(difference);
			}
			else throw new Exception("(POSL Exception) Not compearing allowed (Solution::comapareTo)");
		}

		public static T_Changes getChanges(int[] config_before, Solution config_after)
		{
			if (config_after.Length != config_before.Length)
				throw new InvalidOperationException ("(POSL_Exception) sizes mismatches (PoslTools.getChanges)");
			List<int> l_new_values = new List<int> (config_after.Length);
			List<int> l_new_positions = new List<int> (config_after.Length);

			for (int i = 0; i < config_before.Length; i++) {
				if (config_before [i] != config_after [i]){
					l_new_values.Add (config_after [i]);
					l_new_positions.Add (i);
				}
			}
			return new T_Changes (l_new_positions.ToArray (), l_new_values.ToArray());
		}
	}
}


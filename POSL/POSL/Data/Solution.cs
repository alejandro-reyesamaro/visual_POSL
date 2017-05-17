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

		//! (Property) Returns a copy of the current configuration
		/*!
			\return A copy os the current configuration
		 */
		public int[] GetConfByCopy { 
			get { 
				return (int[])configuration.Clone ();
			}
		}

		//! Default property: The value of the i-th variable
		/*!
			\return The value of the i-th variable
		 */
		public int this[int i] 
		{ 
			get { return configuration[i]; } 
			set { configuration [i] = value; }
		}

		//! (Property) Returns the length of the current configuration
		/*!
			\return The length of the current configuration
		 */
		public int Length { get { return configuration.Length; } }

		//! (Property) Returns the domain of the variables
		/*!
			\return The domain of the variables
		 */
		public Domain GetVariablesDomain{ get { return variables_domains; } }

		//! From <ComputationData>
		public override string Tag { get { return "cd_S"; } }

		//! (Property) Returns the packing ID (ID for the communication)
		public string SolutionPackingID { get { return "658201" ;} } 

		//! Constructor to build a Solution with domain and the length of the configuration
		/*!
            \param _domains The domain of the variables
            \param dimension The length of the configuration
         */
		public Solution(Domain _domains, int dimension)
		{
			variables_domains = _domains;
			configuration = new int[dimension];
		}

		//! Constructor to build a Solution with domain and a configuration
		/*!
            \param _domains The domain of the variables
            \param dimension The configuration
         */
		public Solution(Domain _domains, int[] conf)
		{
			variables_domains = _domains;
			configuration = new int[conf.Length];
			Array.Copy (conf, configuration, conf.Length);
		}

		//! Returns a copy of the solution
		/*!
            \return A copy of the solution
         */
		public Solution clone ()
		{
			int[] conf = new int[this.configuration.Length];
			Array.Copy (this.configuration, conf, conf.Length);
			return new Solution (this.variables_domains, conf);
		}

		//! Updates the object from a configuration
		/*!
            \param _new_config New configuration
         */
		public void update(int[] new_config)
		{
			if(new_config.Length != configuration.Length)
				throw new Exception("(POSL Exception) Configurations sizes missmatch (Solution.update)");
			//std::copy(new_config.begin(), new_config.end(), configuration.begin());
			Array.Copy(new_config, configuration, 0);
		}

		//! Updates the object from a buffer
		/*!
            \param pack A buffer of integers
         */
		public void updateConfigurationFromPack(int[] pack)
		{
			PoslTools.copy(pack, 2, 2 + configuration.Length, configuration, 0);
		}

		//! From <Object>
		public override bool Equals(object other)
		{
			if (!(other is Solution))
				return false;
			return this == ((Solution)other) || PoslTools.equals_vectors(((Solution)other).configuration, this.configuration);
		}

		//! From <Object>
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		//! From <Object>
		public override string ToString(){ return PoslTools.configurationToString(configuration); }

		//shared_ptr<FactoryPacker> Solution::BuildPacker(){ return make_shared<FactorySolutionPacker>(shared_from_this()); }

		//! From <ComputationData>
		public override int comapareTo(ComputationData other, Func<ComputationData, int> criteria)
		{
			if(other.Tag == Tag) // TAGSOLUTION
			{
				int ranking_this = criteria(this);
				int ranking_other = criteria((Solution)other);
				int difference = ranking_this - ranking_other;
				return (difference == 0) ? 0 : difference / Math.Abs(difference);
			}
			else throw new Exception("(POSL Exception) Not compearing allowed (Solution::comapareTo)");
		}

		//! Returns performed changes to a configurations w.r.t. other
		/*!
            \param config_before The initial configuration
            \param config_before The changed configuration
            \return Performed changes
         */
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


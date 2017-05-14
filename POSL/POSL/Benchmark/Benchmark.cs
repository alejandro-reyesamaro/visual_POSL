using System;
using POSL.Data;
using POSL.Tools;

namespace POSL.Benchmark
{
	/*!
	 * \class Benchmark
	 * \brief (Abstract) Class to represent an instance of a problem
	 */
	public abstract class Benchmark
	{
		protected int problem_dimension;
		protected Domain domain;
		protected int[] configuration;
		protected int[] default_configuration;

		//! STRATEGIES
		protected ICostStrategy cost_strategy;
		protected IRelativeCostStrategy relative_cost_strategy;
		protected IShowStrategy show_strategy;

		public Benchmark(int _dimension, Domain _domain,
		                 ICostStrategy _cost_strategy,
		                 IRelativeCostStrategy _relative_cost_strategy,
		                 IShowStrategy _show_strategy)
		{
			problem_dimension = _dimension;
			domain = _domain;
			configuration = new int[_dimension];
			default_configuration = new int[_dimension];
			cost_strategy = _cost_strategy;
			relative_cost_strategy = _relative_cost_strategy;
			show_strategy = _show_strategy;
		}

		public int Dimension{ get { return problem_dimension; } }
		public Domain Variable_Domain{ get { return domain; } }

		// ----- METHODS
		public int solutionCost(Solution sol)
		{
			return solutionCost(sol.GetConfByRef);
		}
		public int relativeSolutionCost(int[] configuration)
		{
			return relative_cost_strategy.relativeSolutionCost(configuration);
		}
		public int relativeSolutionCost(int[] new_config, T_Changes changes)
		{
			return relative_cost_strategy.relativeSolutionCost(new_config, changes);
		}
		public int solutionCost(int[] configuration)
		{
			return cost_strategy.solutionCost(configuration);
		}
		public int currentCost()
		{
			return relative_cost_strategy.currentCost();
		}
		public string ShowSolution(Solution solution)
		{
			return show_strategy.showSolution(solution);
		}
		public Solution GetSolution()
		{
			return new Solution(domain, configuration);
		}
		void SetDefaultConfiguration(int[] _default_configuration)
		{
			Array.Copy (_default_configuration, default_configuration, default_configuration.Length);
		}
		int[] GetDefaultConfiguration()
		{
			return default_configuration;
		}
		// ----- 


		// ----- Projected Cost (AS)
		public int costOnVariable(int index)
		{
			return relative_cost_strategy.costOnVariable(index);
		}
		public int sickestVariable()
		{
			return relative_cost_strategy.sickestVariable();
		}
		// -----


		// ----- VIRTUAL
		public virtual int[] Reset()
		{
			return configuration;
		}
		// -----


		// ----- ABSTRACT 
		public abstract string showInstance ();
		// -----


		// ----- PROTECTED
		protected void UpdateSolution(int[] config)
		{    
			relative_cost_strategy.updateConfiguration(config);
			Array.Copy (config, configuration, configuration.Length);
		}
		protected void InitializeCostData(int[] config)
		{
			relative_cost_strategy.initializeCostData(config, solutionCost(config));
			Array.Copy (config, configuration, configuration.Length);
		}
		// ----- 
	}
}


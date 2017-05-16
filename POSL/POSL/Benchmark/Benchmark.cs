using System;
using POSL.Data;
using POSL.Tools;

namespace POSL.Benchmarks
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
		public int relativeSolutionCost(Solution solution)
		{
			return relative_cost_strategy.relativeSolutionCost(solution);
		}
		public int relativeSolutionCost(Solution new_solution, T_Changes changes)
		{
			return relative_cost_strategy.relativeSolutionCost(new_solution, changes);
		}
		public int solutionCost(Solution solution)
		{
			return cost_strategy.solutionCost(solution);
		}
		public int CurrentCost
		{
			get { return relative_cost_strategy.currentCost (); }
		}
		public string ShowSolution(Solution solution)
		{
			return show_strategy.showSolution(solution);
		}
		public Solution GetSolution
		{
			get { return new Solution (domain, configuration); }
		}
		void SetDefaultConfiguration(int[] _default_configuration)
		{
			Array.Copy (_default_configuration, default_configuration, default_configuration.Length);
		}
		int[] GetDefaultConfiguration
		{
			get{ return default_configuration; }
		}
		public void InitializeCostData(Solution solution)
		{
			relative_cost_strategy.initializeCostData(solution, solutionCost(solution));
			configuration = solution.GetConfByCopy;
		}
		public void UpdateSolution(Solution solution)
		{    
			relative_cost_strategy.updateConfiguration(solution);
			configuration = solution.GetConfByCopy;
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

		// ----- 
	}
}


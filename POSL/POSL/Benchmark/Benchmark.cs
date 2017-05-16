using System;
using POSL.Data;
using POSL.Tools;

namespace POSL.Benchmarks
{
	/*!
	 * \class Benchmark
	 * \brief (Abstract) Class to represent an instance of a problem
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
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

		//! Main constructor.
		/*!
            \param _dimention Number of variables (groups x players x weeks)
            \param _domain The variables domain
            \param _cost_strategy An instance of the strategy to compute the cost
            \param _relative_cost_strategy An instance of the strategy to compute the relative cost
            \param _show_strategy An instance of the strategy to print the solution
         */
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

		//! (Propertie) Returns the dimension of the problem
		/*!
            \return The problem dimension
         */
		public int Dimension{ get { return problem_dimension; } }
		//! (Propertie) Returns the variables domain
		/*!
            \return The variables domain
         */
		public Domain Variable_Domain{ get { return domain; } }

		// ----- METHODS

		//! Computes the cost of a configuration relative to the current configuration.
		/*!
		\param solution A configuration (solution).
		\return Cost of the given configuration.
		*/
		public int relativeSolutionCost(Solution solution)
		{
			return relative_cost_strategy.relativeSolutionCost(solution);
		}
		//! Computes the cost of a configuration relative to the current configuration.
		/*!
		\param new_solution A configuration (solution).
		\param _change The performed changes w.r.t the current configuration
		\return Cost of the given configuration.
		*/
		public int relativeSolutionCost(Solution new_solution, T_Changes changes)
		{
			return relative_cost_strategy.relativeSolutionCost(new_solution, changes);
		}
		//! Computes the cost of a configuration relative to the current configuration.
		/*!
		\param solution A configuration (solution).
		\return Cost of the given configuration.
		*/
		public int solutionCost(Solution solution)
		{
			return cost_strategy.solutionCost(solution);
		}
		//! Returns the current configuration cost
		/*!
		\return Cost of the given configuration.
		*/
		public int CurrentCost
		{
			get { return relative_cost_strategy.currentCost (); }
		}
		//! Print the solution information
		/*!
		\param solution A configuration (solution).
		\return A string to print
		*/
		public string ShowSolution(Solution solution)
		{
			return show_strategy.showSolution(solution);
		}
		//! Returns the current configuration
		/*!
		\return A solution containing the current configuration 
		*/
		public Solution GetSolution
		{
			get { return new Solution (domain, configuration); }
		}
		//! Sets a default configuration
		/*!
		\param _default_configuration The new default configuration
		*/
		public void SetDefaultConfiguration(int[] _default_configuration)
		{
			Array.Copy (_default_configuration, default_configuration, default_configuration.Length);
		}
		//! Gets the default configuration
		/*!
		\return The default configuration
		*/
		public int[] GetDefaultConfiguration
		{
			get{ return default_configuration; }
		}
		//! Compute the initial information about the state of the solution
		/*!
		\param solution The initial solution
		*/
		public void InitializeCostData(Solution solution)
		{
			relative_cost_strategy.initializeCostData(solution, solutionCost(solution));
			configuration = solution.GetConfByCopy;
		}
		//! Updates the information about the state of the solution
		/*!
		\param solution The solution
		*/
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


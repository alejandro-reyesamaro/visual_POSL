using System;
using POSL.Tools;
using POSL.Data;

namespace POSL.Benchmarks
{
	/*!
	* \class IRelativeCostStrategy
	* \brief Interface to represent a relative solution cost strategy
	* \author Alejandro Reyes
 	* \date 2016-05-13
	*/
	public interface IRelativeCostStrategy
	{
		//! Computes the cost of a configuration relative to the current configuration.
		/*!
		\param solution A configuration (solution).
		\return Cost of the given configuration.
		*/
		int relativeSolutionCost(Solution solution);

		//! Initialize the information related to the cost.
		/*!
		\param _configuration A configuration (solution).
		\param _initial_cost The initial cost of the configuration.
		*/
		void initializeCostData(Solution solution, int _initial_cost);

		//! Computes the cost of a configuration relative to the current configuration.
		/*!
		\param _configuration A configuration (solution).
		\param _change The performed changes w.r.t the current configuration
		\return Cost of the given configuration.
		*/
		int relativeSolutionCost(Solution solution, T_Changes _change);

		//! Updates the current configuration.
		/*!
		\param new_config A configuration (solution).
		*/
		void updateConfiguration(Solution new_solution);

		//! Returns the current cost.
		/*!
		\return Current cost.
		*/
		int currentCost();

		//! Computes the projected cost of a variable.
		/*!
		\param variable_index Index of a variable.
		\return The projected cost of the variable with index <i>variable_index</i>.
		*/
		int costOnVariable(int variable_index);

		//! Returns the variable with the highest projected cost.
		/*!
		\return The projected cost of the variable with highest projected cost.
		*/
		int sickestVariable();
	};
}


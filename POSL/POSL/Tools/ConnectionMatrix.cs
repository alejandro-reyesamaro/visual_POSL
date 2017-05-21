using System;

namespace POSL.Tools
{
	/*!
	 * \class ConnectionMatrix 
	 * \brief Calss to represent connections between "objects" through a triangular matrix
	 * \author Alejandro Reyes
 	 * \date 2017-05-21
	 */
	public class ConnectionMatrix
	{
		private int[][] connections; /*!< Matrix of connections */
		private int N; /*!< Connection matrix dimension */

		//! Factory method to initialize the connection matrix
		/*!
            \param n Number of objects to "connect"
         */
		private void buildConnectios(int n)
		{
			N = n;
			connections = new int[n][];
			for(int i = 0; i < n ; i++)
				connections[i] = new int[i];
		}

		//! Default constructor.
		/*!
            \param n Number of objects to "connect"
         */
		public ConnectionMatrix(int n)
		{
			buildConnectios (n);
		}

		//! Inserts a new connection between indexes a and b
		//   -- (see C++ implementation for lost details)
		/*!
            \param a A 1-based index 
            \param b A 1-based index
         */
		public void add_connection(int a, int b)
		{
			if (a < 0 || a >= N || b < 0 || b >= N)
				PoslTools.p_throw ("not valid indexes", "ConnectionMatrix", "add_connection");
			if(a == b) return;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			connections[pa][pb]++;
		}

		//! Returns whether indexes a and b are connected
		/*!
            \param a A 1-based index 
            \param b A 1-based index
            \return True if a and b are connected, false otherwise
         */
		public bool are_connected(int a, int b)
		{
			if (a < 0 || a >= N || b < 0 || b >= N)
				PoslTools.p_throw ("not valid indexes", "ConnectionMatrix", "are_connected");
			if(a == b) return true;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return connections[pa][pb] > 1;
		}

		//! Returns whether indexes a and b would be connected after a removal
		/*!
            \param a A 1-based index 
            \param b A 1-based index
            \return True if a and b would be connected connected after removing one connection from them
         */
		public bool would_be_disconnected(int a, int b)
		{
			if (a < 0 || a >= N || b < 0 || b >= N)
				PoslTools.p_throw ("not valid indexes", "ConnectionMatrix", "would_be_disconected");
			if(a == b) return false;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return connections[pa][pb] - 1 > 1;
		}

		//! Remove the connection between indexes a et b
		//   -- (see C++ implementation for lost details)
		/*!
            \param a A 1-based index 
            \param b A 1-based index
         */
		public void remove_connection(int a, int b)
		{
			if (a < 0 || a >= N || b < 0 || b >= N)
				PoslTools.p_throw ("not valid indexes", "ConnectionMatrix", "remove_connection");
			if(a == b) return;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			connections[pa][pb] = Math.Max(0, connections[pa][pb]-1);
		}

		//! Returns the number of connections between a and b
		/*!
            \param a An 1-based index 
            \param b An 1-based index
            \return The number of connections between a and b
         */
		public int get_connections(int a, int b)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return connections[pa][pb];
		}

		//! Returns the total number of variables that index is connected with (RANKING)
		/*!
            \param index A 0-based index
            \return The total number of variables that index is connected with (RANKING)
         */
		public int ranking_cost_of_index(int index)
		{
			int sum = 0;
			for(int i = 0; i < connections[index].Length; i++)
				sum += PoslTools.identity(connections[index][i]);
			for(int i = index + 1; i < connections.Length; i++)
				sum += PoslTools.identity(connections[i][index]);
			return sum;
		}

		//! Returns the projected cost of a w.r.t. b
		/*!
            \param a An 1-based index
            \param b An 1-based index
            \return The projected cost of a w.r.t. b
         */
		public int projected_cost(int a, int b)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return (connections[pa][pb] < 2) ? 0 : (connections[pa][pb] - 1) * 2;
		}

		//! Clears the connection matrix
		public void clear()
		{
			for(int i = 0; i < connections.Length ; i++)
				PoslTools.fill(connections[i], 0);
		}
	}
}


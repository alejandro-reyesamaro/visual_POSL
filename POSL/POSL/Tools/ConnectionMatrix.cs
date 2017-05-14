using System;

namespace POSL.Tools
{
	public class ConnectionMatrix
	{
		private int[][] connections;

		private int[][] buildConnectios(int n)
		{
			int[][] connections = new int[n][];
			for(int i = 0; i < n ; i++)
				connections[i] = new int[i];
			return connections;
		}

		public ConnectionMatrix(int n)
		{
			connections = buildConnectios (n);
		}

		public int add_connection(int a, int b, bool updating)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			if(updating)
			{
				connections[pa][pb]++;
				// RETURNS cost modification factor
				return (connections[pa][pb] > 1) ? 2 : 0;
			}
			else
				return (connections[pa][pb] + 1 > 1) ? 2 : 0;
		}

		public int remove_connection(int a, int b, bool updating)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			if (updating)
			{
				connections[pa][pb] = Math.Max(0, connections[pa][pb]-1);
				// RETURNS cost modification factor
				return (connections[pa][pb] > 0) ? -2 : 0;
			}
			else
				return (connections[pa][pb] - 1 > 0) ? -2 : 0;
		}

		public int get_connectios(int a, int b)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return connections[pa][pb];
		}

		public int ranking_cost_of_variable(int variable_index)
		{
			int sum = 0;
			for(int i = 0; i < connections[variable_index].Length; i++)
				sum += PoslTools.identity(connections[variable_index][i]);
			for(int i = variable_index + 1; i < connections.Length; i++)
				sum += PoslTools.identity(connections[i][variable_index]);
			return sum;
		}

		public int projected_cost(int a, int b)
		{
			if(a == b) return 0;
			int pa = Math.Max(a, b)-1;
			int pb = Math.Min(a, b)-1;
			return (connections[pa][pb] < 2) ? 0 : (connections[pa][pb] - 1) * 2;
		}

		public void clear()
		{
			for(int i = 0; i < connections.Length ; i++)
				PoslTools.fill(connections[i], 0);
		}
	}
}


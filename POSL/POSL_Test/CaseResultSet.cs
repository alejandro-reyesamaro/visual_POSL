using System;
using System.Collections.Generic;

namespace POSL_Test
{
	public class CaseResultSet<T_test, T_result>
	{
		private List<T_test> cases;
		private List<T_result> results;

		public CaseResultSet()
		{
			cases = new List<T_test> ();
			results = new List<T_result> ();
		}

		public int Count { get { return cases.Count; } }

		public T_test GetCase(int index) 
		{ 
			if (index < 0 || index >= cases.Count)
				throw new InvalidOperationException ("POSL uTest: invalid index");
			return cases[index];
		}

		public T_result GetResult(int index) 
		{ 
			if (index < 0 || index >= results.Count) 
				throw new InvalidOperationException ("POSL uTest: invalid index");
			return results[index];
		}

		public void addTest(T_test _case, T_result result)
		{
			this.cases.Add (_case);
			this.results.Add (result);
		}
	}
}


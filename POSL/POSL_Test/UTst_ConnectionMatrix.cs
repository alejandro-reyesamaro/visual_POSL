using NUnit.Framework;
using System;
using POSL.Tools;

namespace POSL_Test
{
	[TestFixture()]
	public class UTst_ConnectionMatrix
	{
		[Test()]
		public void TestCase ()
		{
			int[][] cm = new int[4][]; 
			cm[0] = new int[0];
			cm[1] = new int[]{2};
			cm[2] = new int[] { 1, 1 };
			cm[3] = new int[] { 2, 0, 3};

			ConnectionMatrix CM1 = new ConnectionMatrix (cm);
			ConnectionMatrix CM2 = new ConnectionMatrix (4);
			CM2.add_connection (2, 1);CM2.add_connection (1, 2);
			CM2.add_connection (3, 1);CM2.add_connection (3, 2);
			CM2.add_connection (4, 1);CM2.add_connection (4, 1);
			CM2.add_connection (4, 3);CM2.add_connection (4, 3);CM2.add_connection (4, 3);
			bool eq = CM1.Equals (CM2);
			Assert.That (eq, Is.EqualTo(true));
		}
	}
}


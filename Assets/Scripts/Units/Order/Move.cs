using UnityEngine;

namespace StrategyGame.Orders
{
	public class Move : Order
	{
		internal readonly Vector3 Destination;

		public Move(Vector3 destination)
		{
			Destination = destination;
		}
	}
}
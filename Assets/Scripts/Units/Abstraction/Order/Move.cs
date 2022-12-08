using System;
using UnityEngine;

namespace StrategyGame.Commands
{
	public class Move : Command
	{
		internal readonly Vector3 Destination;

		public Move(Vector3 destination)
		{
			Destination = destination;
		}

		public override string ToString()
		{
			return $"Destination: {Destination}";
		}
	}
}
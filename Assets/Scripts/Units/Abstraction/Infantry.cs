using StrategyGame.Commands;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace StrategyGame.Units
{
	public abstract class Infantry : Unit
	{
		protected override IEnumerator Co_Move()
		{
			while (!HasReachedDestination())
			{
				yield return _navMeshCalculationDelay;
			}
			Debug.Log($"unit <color=yellow>{name}</color> <color=green><b> has reached </b></color> to destination: {_agent.destination}.");

			_command = null;
		}
	}
}
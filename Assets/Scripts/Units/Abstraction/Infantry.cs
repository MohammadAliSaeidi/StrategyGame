using StrategyGame.Commands;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace StrategyGame.Units
{
	public abstract class Infantry : Unit
	{
		public override void Command(Command command)
		{
			if (command is Move moveCommand)
			{
				StartCoroutine(Co_Move(moveCommand));
			}
		}

		private IEnumerator Co_Move(Move moveCommand)
		{

			yield return new WaitWhile(() => _agent.pathPending);

			var path = new NavMeshPath();
			_agent.CalculatePath(moveCommand.Destination, path);

			if (path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial)
			{
				Debug.Log($"unit <color=yellow>{name}</color> <color=red><b>couldn't find path</b></color> to reach destination.");
				yield break;
			}

			if (path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial)
			{
				Debug.Log($"unit <color=yellow>{name}</color> path to destination is <color=red><b>invalid.</b></color>");
				yield break;
			}

			_agent.path = path;

			var wait = new WaitForSeconds(0.25f);
			while (!HasReachedDestination())
			{
				yield return wait;
			}
			Debug.Log($"unit <color=yellow>{name}</color> <color=green><b> has reached </b></color> to destination: {moveCommand.Destination}.");

			_command = null;
		}
	}
}
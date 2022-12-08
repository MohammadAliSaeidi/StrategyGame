using UnityEngine;

namespace StrategyGame.Commands
{
	public class Attack : Command
	{
		internal readonly Transform _targetTransfom;
		internal readonly Vector3? _targetPosition;

		public Attack(Transform targetTransfom)
		{
			_targetTransfom = targetTransfom;
		}

		public Attack(Vector3? targetPosition)
		{
			_targetPosition = targetPosition;
		}
	}
}
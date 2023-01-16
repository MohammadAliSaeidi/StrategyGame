using StrategyGame.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame
{
	/// <summary>
	/// Spawns beginning base for player
	/// </summary>
	public class BaseSpawnController : MonoBehaviour
    {
        [SerializeField]
        private CommandCenter _commandBase;

        [SerializeField]
        private LayerMask _groundDetectionLayerMask;

		private void Start()
		{
			SpawnBase();
		}

		public void SpawnBase()
		{
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo, 50, _groundDetectionLayerMask))
			{
                var baseInstance = Instantiate(_commandBase, hitInfo.point, Quaternion.Euler(0,-45,0));
                baseInstance.SetPlacementState(true);
            }
		}
    }
}
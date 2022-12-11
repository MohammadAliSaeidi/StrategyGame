using UnityEngine;

namespace StrategyGame.Structures
{
	[RequireComponent(typeof(StructureBuildingUI))]
	public class StructureBuilding : MonoBehaviour
	{
		private StructureBuildingUI _uImanager;

		private void Awake()
		{
			_uImanager = GetComponent<StructureBuildingUI>();
		}

	}
}

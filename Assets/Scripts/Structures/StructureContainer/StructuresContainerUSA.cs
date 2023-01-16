using UnityEngine;

namespace StrategyGame.Structures
{
	[System.Serializable]
	public class StructuresContainerUSA
	{
		[field: SerializeField]
		public CommandCenterUSA CommandCenter { get; private set; }

		[field: SerializeField]
		public BarracksUSA Barracks { get; private set; }
	}
}

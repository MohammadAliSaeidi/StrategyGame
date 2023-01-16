using UnityEngine;

namespace StrategyGame.Structures
{
	[CreateAssetMenu(fileName = "Structures", menuName = "Structure Container", order = 50)]
	public class StructuresContainer : ScriptableObject
	{
		[field: SerializeField]
		public StructuresContainerUSA UsaStructures { get; private set; }
	}
}

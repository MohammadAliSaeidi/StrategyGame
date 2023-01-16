using UnityEngine;

namespace StrategyGame.Structures
{
	[CreateAssetMenu(fileName = "StructureData", menuName = "Structure Data", order = 50)]
	public class StructureData : ScriptableObject
	{
		[field: SerializeField]
		public int BuildCost { get; private set; }
	}
}

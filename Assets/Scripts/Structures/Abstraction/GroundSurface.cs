using UnityEngine;

namespace StrategyGame.Structures
{
	public abstract partial class Structure
	{
		[System.Serializable]
		protected class GroundSurface
		{
			public Transform[] RayOriginTrArray;
			public LayerMask RayLayerMask;
			public float RayMaxDist = 0.2f;
			public Ray Ray = new();
		}
	}
}

using UnityEngine;

namespace StrategyGame.Units
{
	public abstract partial class Tank
	{
		[System.Serializable]
		protected class SurfaceNormal
		{
			[HideInInspector] public Vector3 NormalVector = new();
			public Ray Ray = new();
			public LayerMask LayerMask;
			public Transform RayOriginTr;
			public float RaycastMaxDistance = 2;
		}
	}
}
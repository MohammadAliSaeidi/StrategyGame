using System.Collections;
using UnityEngine;

namespace StrategyGame.Structures
{
	public abstract partial class Structure : MonoBehaviour
	{

		[SerializeField]
		protected GroundSurface _gourndSurfaceChecking;

		public bool AllowPlacing { get; protected set; }
		public bool IsPlaced { get; protected set; }



		private void Start()
		{
			StartCoroutine(Co_CheckAllowPlacing());
		}

		protected IEnumerator Co_CheckAllowPlacing()
		{
			while (!IsPlaced)
			{
				AllowPlacing = true;
				foreach (var surfaceCheck in _gourndSurfaceChecking.RayOriginTrArray)
				{
					_gourndSurfaceChecking.Ray.origin = surfaceCheck.position;
					_gourndSurfaceChecking.Ray.direction = -surfaceCheck.up;
					if (!Physics.Raycast(_gourndSurfaceChecking.Ray, _gourndSurfaceChecking.RayMaxDist, _gourndSurfaceChecking.RayLayerMask))
					{
						AllowPlacing = false;
						break;
					}
				}
				yield return new WaitForSeconds(0.2f);
				yield return null;
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (_gourndSurfaceChecking.RayOriginTrArray != null)
			{
				foreach (var surfaceCheck in _gourndSurfaceChecking.RayOriginTrArray)
				{
					if (surfaceCheck != null)
					{
						Gizmos.color = Color.red;
						Gizmos.DrawLine(surfaceCheck.position, surfaceCheck.position + new Vector3(0, -_gourndSurfaceChecking.RayMaxDist, 0));
					}
				}
			}
		}
	}
}

using System.Collections;
using UnityEngine;

namespace StrategyGame.Structures
{

	public abstract partial class Structure : MonoBehaviour, ISelectable, IDamagable
	{

		[SerializeField]
		protected GroundSurface _gourndSurfaceChecking;

		[SerializeField]
		protected GameObject _selectedEffect;

		[SerializeField]
		protected StructureData _structureData;

		public bool AllowPlacing { get; protected set; }
		public bool IsPlaced { get; protected set; }
		public bool IsSelected { get; protected set; }

		protected Coroutine _checkAllowPlacingCoroutine;

		public void SetPlacementState(bool isPlaced)
		{
			if (isPlaced == false)
			{
				if (_checkAllowPlacingCoroutine != null)
				{
					StopCoroutine(_checkAllowPlacingCoroutine);
				}
				_checkAllowPlacingCoroutine = StartCoroutine(Co_CheckAllowPlacing());
			}

			IsPlaced = isPlaced;
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
				yield return null;
			}
		}

		public void Select()
		{
			if (!IsSelected)
			{
				_selectedEffect.SetActive(true);

				IsSelected = true;
			}
		}

		public void Deselect()
		{
			if (IsSelected)
			{
				_selectedEffect.SetActive(false);

				IsSelected = false;
			}
		}

		public void SetDamage(int damageAmount)
		{
			throw new System.NotImplementedException();
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

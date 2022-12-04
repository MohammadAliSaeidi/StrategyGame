using StrategyGame.Orders;
using System.Collections;
using UnityEngine;

namespace StrategyGame.Units
{
	public abstract class Infantry : Unit
	{
		[SerializeField]
		private LayerMask _groundLayer;

		protected override void PerformOrder(Order order)
		{
			if (order is Move moveOrder)
			{
				StartCoroutine(Co_Move(moveOrder));
			}
		}

		private IEnumerator Co_Move(Move moveOrder)
		{
			_agent.SetDestination(moveOrder.Destination);

			var wait = new WaitForSeconds(0.25f);
			while (!HasReachedDestination())
			{
				yield return wait;
			}

			_order = null;
		}

		// TODO: This is for test. Remove it later
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, _groundLayer))
				{
					PerformOrder(new Move(hitInfo.point));
				}
			}
		}
	}
}
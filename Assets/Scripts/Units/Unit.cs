using StrategyGame.Orders;
using UnityEngine;
using UnityEngine.AI;

namespace StrategyGame.Units
{
	public abstract class Unit : MonoBehaviour, IDamagable
	{
		protected NavMeshAgent _agent;
		protected Order _order;
		protected int _health;

		protected abstract void PerformOrder(Order order);

		public void SetDamage(int damageAmount)
		{
			_health -= damageAmount;

			if (_health <= 0)
			{
				KillUnit();
			}
		}

		internal void KillUnit()
		{
			throw new System.NotImplementedException();
		}

		protected bool HasReachedDestination()
		{
			if (_agent.pathStatus == NavMeshPathStatus.PathComplete 
				&& _agent.remainingDistance != Mathf.Infinity
				&& _agent.remainingDistance <= _agent.stoppingDistance)
			{
				return true;
			}

			return false;
		}
	}
}
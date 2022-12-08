using StrategyGame.Commands;
using UnityEngine;
using UnityEngine.AI;

namespace StrategyGame.Units
{
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class Unit : MonoBehaviour, IDamagable
	{
		[SerializeField]
		protected GameObject _selectedEffect;

		protected NavMeshAgent _agent;
		protected Command _command;
		protected int _health;
		public bool IsSelected { get; private set; }

		protected virtual void Awake()
		{
			_selectedEffect.SetActive(false);
			IsSelected = false;
			_agent = GetComponent<NavMeshAgent>();
		}

		public abstract void Command(Command command);

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

		public void OnUnitSelected()
		{
			if (!IsSelected)
			{
				_selectedEffect.SetActive(true);

				IsSelected = true;
			}
		}

		public void OnUnitDeselected()
		{
			if (IsSelected)
			{
				_selectedEffect.SetActive(false);

				IsSelected = false;
			}
		}
	}
}
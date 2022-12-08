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

		public bool IsSelected { get; private set; }

		protected NavMeshAgent _agent;
		protected Command _command;
		protected int _health;
        protected readonly WaitForSeconds _navMeshCalculationDelay = new WaitForSeconds(0.25f);

        protected virtual void Awake()
		{
			_selectedEffect.SetActive(false);
			IsSelected = false;
			_agent = GetComponent<NavMeshAgent>();
		}

		internal virtual void Command(Command command)
		{
            if (command is Move moveCommand)
            {
                StartCoroutine(Co_Move(moveCommand));
            }
        }

		internal void SetDamage(int damageAmount)
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

		internal void OnUnitSelected()
		{
			if (!IsSelected)
			{
				_selectedEffect.SetActive(true);

				IsSelected = true;
			}
		}

        internal void OnUnitDeselected()
		{
			if (IsSelected)
			{
				_selectedEffect.SetActive(false);

				IsSelected = false;
			}
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

		protected IEnumerator Co_InitiateMoveCommand(Move moveCommand)
		{
            yield return new WaitWhile(() => _agent.pathPending);

            var path = new NavMeshPath();
            _agent.CalculatePath(moveCommand.Destination, path);

            if (path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial)
            {
                Debug.Log($"unit <color=yellow>{name}</color> <color=red><b>couldn't find path</b></color> to reach destination.");
                yield break;
            }

            if (path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial)
            {
                Debug.Log($"unit <color=yellow>{name}</color> path to destination is <color=red><b>invalid.</b></color>");
                yield break;
            }

            _agent.path = path;

			yield return Co_Move();
        }

		protected abstract IEnumerator Co_Move();
	}
}
using System.Collections;
using UnityEngine;

namespace StrategyGame.Units
{
	public abstract partial class Tank : Unit
	{
		[Tooltip("Visual 3d model that aligns with the surface normal")]
		[SerializeField]
		protected Transform _body;

		[SerializeField]
		protected SurfaceNormal _surfaceNormal;

		[SerializeField]
		private float _rotationSpeed = 10;

		private const float MIN_DIST_TO_REVERSE_GEAR = 5;
		private const float ROTATING_THRESHOLD = 1;

		private Quaternion _lookRotation;
		private float _transformAngleToTarget;

		private void FixedUpdate()
		{
			// Align to surface normal
			_surfaceNormal.Ray.origin = _surfaceNormal.RayOriginTr.position;
			_surfaceNormal.Ray.direction = -Vector3.up;
			if (Physics.Raycast(_surfaceNormal.Ray, out RaycastHit hitInfo, _surfaceNormal.RaycastMaxDistance, _surfaceNormal.LayerMask))
			{
				_surfaceNormal.NormalVector = hitInfo.normal;
			}
			var qNorm = Quaternion.FromToRotation(Vector3.up, _surfaceNormal.NormalVector);
			var qLook = Quaternion.LookRotation(transform.forward, _surfaceNormal.NormalVector);

			_body.transform.rotation = Quaternion.Slerp(_body.transform.rotation, qNorm * qLook, Time.fixedDeltaTime * _rotationSpeed);
		}

		protected override IEnumerator Co_Move()
		{
			_lookRotation = transform.rotation;
			while (!HasReachedDestination())
			{
				var nextCorner = _agent.steeringTarget;

				if (Vector3.Distance(transform.position, nextCorner) > MIN_DIST_TO_REVERSE_GEAR)
				{
					var direction = _agent.steeringTarget - transform.position;
					direction.y = 0;
					if (direction.magnitude > 0.1f)
					{
						_lookRotation = Quaternion.LookRotation(direction, Vector3.up);
					}

					_transformAngleToTarget = Quaternion.Angle(transform.rotation, _lookRotation);
					// first face to the target
					if (_transformAngleToTarget >= ROTATING_THRESHOLD)
					{
						_agent.isStopped = true;
						_agent.updateRotation = false;
						yield return new WaitWhile(() => _agent.velocity.magnitude >= 0.1f);
						transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * _rotationSpeed / _transformAngleToTarget);
					}
					// then move towards it
					else
					{
						_agent.isStopped = false;
						_agent.updateRotation = true;
					}
				}

				//yield return _navMeshCalculationDelay;
				yield return null;
			}
			Debug.Log($"unit <color=yellow>{name}</color> <color=green><b> has reached </b></color> to destination: {_agent.destination}.");

			_command = null;
		}

		private void OnDrawGizmos()
		{
			// Gizmos.DrawRay(transform.position, transform.forward);
		}
	}
}
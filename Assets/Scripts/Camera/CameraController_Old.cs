using UnityEngine;
using static StrategyGame.PlayerInputManager;
using static UnityEngine.InputSystem.InputAction;

namespace StrategyGame
{
	public class CameraController_Old : MonoBehaviour
	{
		[SerializeField]
		private Transform _virtualCameraTr;

		[Header("Sphere cast")]
		[SerializeField]
		private float _sphereCastRadius = 1;

		[SerializeField]
		private LayerMask _sphereCastLayerMask;

		[SerializeField]
		private float _minDistanceToSphereCast = 4;

		[SerializeField]
		private float _maxDistanceToSphereCast =100;

		[Header("Camera movement")]
		[SerializeField]
		private float _zoomSmoothing = 2;
		[SerializeField]
		private float _scrollSpeed = 5;

		[SerializeField]
		private float _movementSmoothing = 3;
		[SerializeField]
		private float _movementSpeed = 5;

		private Ray _cameraRay = new();
		private Vector3 _targetPosition;
		private Vector2 _cameraMovementInputValue;
		private Vector3 _sphereCastHitPoint;
		private bool _isMoving = false;
		private float _cameraDistToSphereCast;

		private void Start()
		{
			Application.targetFrameRate = 60;

			_targetPosition = _virtualCameraTr.position;
			_isMoving = false;

			Inputs.InGame.CameraMovement.performed += delegate { _isMoving = true; };
			Inputs.InGame.CameraMovement.canceled += delegate { _isMoving = false; };
			Inputs.InGame.Scrolling.performed += Scrolling;
		}

		private void Update()
		{
			// Init Ray
			_cameraRay.origin = _targetPosition;
			_cameraRay.direction = _virtualCameraTr.forward;

			if (Physics.SphereCast(_cameraRay,
						  radius: _sphereCastRadius,
						  hitInfo: out RaycastHit hitInfo,
						  maxDistance: Mathf.Infinity,
						  layerMask: _sphereCastLayerMask))
			{
				var sphereCastCenter = hitInfo.point + _sphereCastRadius * hitInfo.normal;
				_sphereCastHitPoint = sphereCastCenter;
				_cameraDistToSphereCast = Vector3.Distance(_targetPosition, sphereCastCenter);
				if (_cameraDistToSphereCast < _minDistanceToSphereCast)
				{
					_targetPosition = sphereCastCenter + _minDistanceToSphereCast * -(_virtualCameraTr.forward);
				}
				else if (_cameraDistToSphereCast > _maxDistanceToSphereCast)
				{
					_targetPosition = sphereCastCenter + _maxDistanceToSphereCast * -(_virtualCameraTr.forward);
				}
			}
			_virtualCameraTr.position = Vector3.Lerp(a: _virtualCameraTr.position,
													b: _targetPosition,
													t: Time.deltaTime * _movementSmoothing);
		}

		private void LateUpdate()
		{
			if (_isMoving)
			{
				_cameraMovementInputValue = Inputs.InGame.CameraMovement.ReadValue<Vector2>().normalized;

				var rightOrLeft = (_virtualCameraTr.right * _cameraMovementInputValue.x).normalized;
				var forwardOrBackward = Vector3.Scale(_virtualCameraTr.forward * _cameraMovementInputValue.y, new Vector3(1, 0, 1)).normalized;
				var moveVector = (rightOrLeft + forwardOrBackward).normalized;
				_targetPosition += _movementSpeed * Time.deltaTime * moveVector;
			}
		}

		private void Scrolling(CallbackContext callbackContext)
		{
			if (_cameraDistToSphereCast >= _minDistanceToSphereCast && _cameraDistToSphereCast <= _maxDistanceToSphereCast)
			{
				var scrollingDelta = callbackContext.ReadValue<float>();
				_targetPosition += scrollingDelta * _scrollSpeed * _virtualCameraTr.forward;
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(_sphereCastHitPoint, _sphereCastRadius);
			Gizmos.DrawSphere(_targetPosition, 0.2f);
		}
	}
}

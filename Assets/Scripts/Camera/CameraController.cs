using UnityEngine;
using static StrategyGame.PlayerInputManager;
using static UnityEngine.InputSystem.InputAction;

namespace StrategyGame
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private Transform _mainVirtualCamera;

		[SerializeField]
		private float _scrollSpeed = 0.1f;

		[Header("Camera looking point raycast")]
		[SerializeField]
		private Transform _rayOriginTr;

		[SerializeField]
		private float _rayOriginDistance = 150;

		[SerializeField]
		private Vector2 _cameraRotation = new(45, 45);

		[SerializeField]
		private LayerMask _raycastLayerMask;

		[SerializeField]
		private Transform _cameraTargetPositionTr;

		[Header("Camera zooming")]
		[SerializeField]
		private float _cameraStartDistanceToGround = 50;

		[SerializeField]
		private float _minCameraDistance = 10;

		[SerializeField]
		private float _maxCameraDistance = 100;

		[SerializeField]
		private float _movementSmoothing = 10;

		[Header("Camera movement")]
		[SerializeField]
		private float _movementSpeed = 50;

		public float DistanceToPivotPoint { get; private set; }

		private Ray _cameraRay = new();
		private bool _isMoving = false;
		private Vector2 _movementInputValue;

		private void Start()
		{
			_rayOriginTr.localPosition = new Vector3(0, 0, -_rayOriginDistance);
			transform.rotation = Quaternion.Euler(_cameraRotation);
			_mainVirtualCamera.forward = transform.forward;

			_cameraTargetPositionTr.localPosition = new Vector3(0, 0, -_cameraStartDistanceToGround);
			DistanceToPivotPoint = -_cameraTargetPositionTr.localPosition.z;

			InitiateInputs();
		}

		private void InitiateInputs()
		{
			Inputs.InGame.CameraMovement.performed += delegate { _isMoving = true; };
			Inputs.InGame.CameraMovement.canceled += delegate { _isMoving = false; };
			Inputs.InGame.Scrolling.performed += OnScrolling;
		}

		public void Update()
		{
			if (_cameraTargetPositionTr.localPosition.z > -_minCameraDistance)
			{
				_cameraTargetPositionTr.localPosition = new Vector3(0,0, -_minCameraDistance);
			}
			else if (_cameraTargetPositionTr.localPosition.z < -_maxCameraDistance)
			{
				_cameraTargetPositionTr.localPosition = new Vector3(0,0, -_maxCameraDistance);
			}

			_mainVirtualCamera.transform.position = Vector3.Lerp(_mainVirtualCamera.transform.position, _cameraTargetPositionTr.position, Time.deltaTime * _movementSmoothing);

			_cameraRay.origin = _rayOriginTr.position;
			_cameraRay.direction = _rayOriginTr.forward;
			if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo, Mathf.Infinity, _raycastLayerMask))
			{
				transform.position = hitInfo.point;
			}
		}

		private void LateUpdate()
		{
			if (_isMoving)
			{
				_movementInputValue = Inputs.InGame.CameraMovement.ReadValue<Vector2>().normalized;

				var rightOrLeft = (transform.right * _movementInputValue.x).normalized;
				var forwardOrBackward = Vector3.Scale(transform.forward * _movementInputValue.y, new Vector3(1, 0, 1)).normalized;
				var moveVector = (rightOrLeft + forwardOrBackward).normalized;
				transform.position += _movementSpeed * Time.deltaTime * moveVector;
			}
		}

		private void OnScrolling(CallbackContext inputInfo)
		{
			if (_mainVirtualCamera)
			{
				if (_cameraTargetPositionTr.localPosition.z <= -_minCameraDistance &&
					_cameraTargetPositionTr.localPosition.z >= -_maxCameraDistance)
				{
					var scrollingDelta = inputInfo.ReadValue<float>();
					_cameraTargetPositionTr.localPosition = new Vector3(0, 0, _cameraTargetPositionTr.localPosition.z + scrollingDelta * _scrollSpeed);
					DistanceToPivotPoint = -_cameraTargetPositionTr.localPosition.z;
				}
			}
		}
	}
}
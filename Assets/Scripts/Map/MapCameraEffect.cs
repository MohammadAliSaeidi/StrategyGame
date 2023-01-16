using UnityEngine;

namespace StrategyGame
{
	public class MapCameraEffect : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private CameraController _cameraController;

		[SerializeField]
		private LineRenderer _lineRendererTemplate;

		private LineRenderer _leftBoundLR;
		private LineRenderer _rightBoundLR;
		private LineRenderer _backBoundLR;
		private LineRenderer _frontBoundLR;

		private Vector3[] _cameraViewBounds = new Vector3[4];
		private float _cameraFOV;

		private void OnValidate()
		{
			if (_cameraController == null)
			{
				Debug.LogError($"<color=yellow>Camera Controller</color> field of {gameObject.name} is Empty!");
			}
		}

		private void Start()
		{
			_leftBoundLR = Instantiate(_lineRendererTemplate);
			_rightBoundLR = Instantiate(_lineRendererTemplate);
			_backBoundLR = Instantiate(_lineRendererTemplate);
			_frontBoundLR = Instantiate(_lineRendererTemplate);

			_lineRendererTemplate.gameObject.SetActive(false);

			_cameraFOV = _camera.fieldOfView;
		}

		private void Update()
		{
			if (_camera && _cameraController)
			{
				var cameraHorizontalForward = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
				transform.position = _camera.transform.position;
				transform.forward = cameraHorizontalForward;

				_cameraViewBounds[0] = (_cameraController.DistanceToPivotPoint * (Quaternion.AngleAxis(-_cameraFOV / 2, Vector3.up) * cameraHorizontalForward)) + transform.position; // front-left
				_cameraViewBounds[1] = (_cameraController.DistanceToPivotPoint * (Quaternion.AngleAxis(+_cameraFOV / 2, Vector3.up) * cameraHorizontalForward)) + transform.position; // front-right
				_cameraViewBounds[2] = transform.position + transform.right; // back-right
				_cameraViewBounds[3] = transform.position - transform.right; // back-left

				_leftBoundLR.SetPositions(new Vector3[] { _cameraViewBounds[3], _cameraViewBounds[0] });
				_rightBoundLR.SetPositions(new Vector3[] { _cameraViewBounds[2], _cameraViewBounds[1] });
				_backBoundLR.SetPositions(new Vector3[] { _cameraViewBounds[2], _cameraViewBounds[3] });
				_frontBoundLR.SetPositions(new Vector3[] { _cameraViewBounds[0], _cameraViewBounds[1] });
			}
		}
	}
}
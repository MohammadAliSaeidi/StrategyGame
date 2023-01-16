using StrategyGame.Structures;
using UnityEngine;
using UnityEngine.InputSystem;
using static StrategyGame.PlayerInputManager;

namespace StrategyGame
{
	public class StructureSelector : MonoBehaviour
	{
		[SerializeField]
		private LayerMask _structureLayerMask;

		[Header("Camera")]
		[SerializeField]
		private bool _findMainCameraAtStart = true;

		[SerializeField]
		private Camera _camera;

		public bool EnableBehaviour = true;

		private Ray _cameraRay;
		private Structure _selectedStructure;

		private void Start()
		{
			if (_findMainCameraAtStart)
			{
				_camera = Camera.main;
			}

			Inputs.InGame.Select.canceled += CheckBuildingSelection;
		}

		private void CheckBuildingSelection(InputAction.CallbackContext inputInfo)
		{
			if (EnableBehaviour && _camera)
			{
				_cameraRay = _camera.ScreenPointToRay(Inputs.InGame.MousePosition.ReadValue<Vector2>());
				if (Physics.Raycast(_cameraRay, out RaycastHit hitInfo, _structureLayerMask) && hitInfo.collider.TryGetComponent(out Structure structure))
				{
					SelectStruecture(structure);
				}
			}
		}

		private void SelectStruecture(Structure structure)
		{
			if (_selectedStructure)
			{
				if (_selectedStructure == structure)
				{
					return;
				}
				else
				{
					_selectedStructure.Deselect();
				}
			}
			structure.Select();
		}
	}
}

using StrategyGame.Commands;
using System.Linq;
using UnityEngine;
using static StrategyGame.PlayerInputManager;

namespace StrategyGame.Units
{

	[RequireComponent(typeof(UnitsContainer))]
	public partial class UnitsCommander : MonoBehaviour
	{
		[SerializeField]
		private MouseIcons _mouseIcons;

		[SerializeField]
		private LayerMask _groundLayer;

		public bool EnableCommanding { get; private set; }

		private UnitSelector _unitSelector;
		private Camera _camera;
		public readonly CommandTypeContainer CommandTypeContainer = new();

		private void Awake()
		{
			_unitSelector = GetComponent<UnitSelector>();
			EnableCommanding = true;
			Cursor.visible = false;
			_camera = Camera.main;
		}

		private void Start()
		{
			InitiateInputs();
			_mouseIcons.SwitchMouseIconToNormal();
			CommandTypeContainer.SetType<Move>();
		}

		private void InitiateInputs()
		{
			Inputs.InGame.AttackMode.performed += delegate
			{
				SetCommandMode<Attack>();
			};

			Inputs.InGame.CancelCommanding.performed += delegate
			{
				SetCommandMode<Move>();
			};

			Inputs.InGame.Command.canceled += delegate
			{
				if (EnableCommanding)
				{
					CommandToSelectedUnits();
				}
			};
		}

		private void SetCommandMode<T>() where T : Command
		{
			EnableCommanding = true;

			_mouseIcons.SwitchMouseIcon<T>();
			CommandTypeContainer.SetType<T>();
		}

		private void CommandToSelectedUnits()
		{
			if (!_unitSelector.SelectedUnits.Any()) return;

			if (CommandTypeContainer != null)
			{
				if (CommandTypeContainer.commandType == typeof(Move))
				{
					foreach (var unit in _unitSelector.SelectedUnits)
					{
						if (Physics.Raycast(GetMousePositionRay(), out RaycastHit hitInfo, _groundLayer))
						{
							var destination = hitInfo.point;
							var moveCommand = new Move(destination);
							Debug.Log($"Commanding to units. Command: <color=green>{moveCommand}</color>");
							unit.Command(moveCommand);
						}
					}
				}
			}
		}

		private Ray GetMousePositionRay()
		{
			return _camera.ScreenPointToRay(Inputs.InGame.MousePosition.ReadValue<Vector2>());
		}
	}
}

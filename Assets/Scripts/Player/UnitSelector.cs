using Chromium.UILibrary;
using System.Collections.Generic;
using UnityEngine;
using static StrategyGame.PlayerInputManager;

namespace StrategyGame.Units
{
	[RequireComponent(typeof(UnitsContainer))]
	public partial class UnitSelector : MonoBehaviour
	{
		[SerializeField]
		private DragAndSelectUI _dragAndSelectUI;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private float _dragThreshold = 5f;

		[SerializeField]
		private LayerMask _unitsLayerMask;

		public bool EnableBehaviour = true;
		public readonly List<Unit> SelectedUnits = new();

		private List<Unit> _units;
		private Vector2 _startDragingPos;
		private Vector2 _endDragingPos;
		private Rect _rect = new();
		private bool _isAdditiveSelection;
		private bool _isDragging;

		private void OnValidate()
		{
			if (!_dragAndSelectUI)
			{
				Debug.LogError($"<color=yellow>Drag And Select UI</color> field of {gameObject.name} is Empty!");
			}

			if (!_camera)
			{
				Debug.LogError($"<color=yellow>Camera</color> field of {gameObject.name} is Empty!");
			}
		}

		private void Awake()
		{
			_units = GetComponent<UnitsContainer>().UnitsList;
		}

		private void Start()
		{
			Inputs.InGame.Select.performed += delegate { OnDrag(); };
			Inputs.InGame.Select.canceled += delegate { OnEndDrag(); };

			Inputs.InGame.MultipleSelection.performed += delegate
			{
				_isAdditiveSelection = true;
			};

			Inputs.InGame.MultipleSelection.canceled += delegate
			{
				_isAdditiveSelection = false;
			};
		}

		private void Update()
		{
			if (EnableBehaviour && _isDragging)
			{
				_dragAndSelectUI.OnDrag(MousePositionInputAction.ReadValue<Vector2>());
			}
		}

		private void OnDrag()
		{
			if (EnableBehaviour)
			{
				_isDragging = true;
				_startDragingPos = MousePositionInputAction.ReadValue<Vector2>();

				_dragAndSelectUI.gameObject.SetActive(true);
				_dragAndSelectUI.OnBeginDrag(_startDragingPos);

				Debug.Log($"<color=yellow>↓</color>Start drag at <color=yellow>{Inputs.InGame.MousePosition.ReadValue<Vector2>()}</color>");
			}
			else
			{
				_dragAndSelectUI.gameObject.SetActive(false);
			}
		}

		private void OnEndDrag()
		{
			_isDragging = false;
			if (EnableBehaviour)
			{
				Debug.Log($"<color=yellow>↑</color>End drag at <color=yellow>{MousePositionInputAction.ReadValue<Vector2>()}</color>");

				_endDragingPos = MousePositionInputAction.ReadValue<Vector2>();
				_dragAndSelectUI.OnEndDrag();

				if (!_isAdditiveSelection)
				{
					foreach (var selectedUnit in SelectedUnits)
					{
						selectedUnit.OnUnitDeselected();
					}
					SelectedUnits.Clear();
				}

				if (Vector2.Distance(_startDragingPos, _endDragingPos) > _dragThreshold)
				{
					MultipleSelection();
				}
				else
				{
					SingleSelection();
				}
			}
		}

		private void MultipleSelection()
		{
			Debug.Log("<color=yellow>Selection Type: </color> Multiple selection");
			foreach (var unit in _units)
			{
				if (IsInsideSelectionBoxRect(unit.transform.position))
				{
					Debug.Log("Selected unit: " + unit.gameObject.name);

					unit.OnUnitSelected();
					SelectedUnits.Add(unit);
				}
				else
				{
					unit.OnUnitDeselected();
				}
			}
		}

		private void SingleSelection()
		{
			Debug.Log("<color=yellow>Selection Type: </color> Single selection");
			if (Physics.Raycast(_camera.ScreenPointToRay(MousePositionInputAction.ReadValue<Vector2>()), out RaycastHit hitInfo, Mathf.Infinity, _unitsLayerMask))
			{
				if (hitInfo.collider.TryGetComponent(out Unit unit))
				{
					if (!unit.IsSelected)
					{
						SelectedUnits.Add(unit);
						unit.OnUnitSelected();
					}
					else if (_isAdditiveSelection)
					{
						SelectedUnits.Remove(unit);
						unit.OnUnitDeselected();
					}
				}
			}
		}

		private bool IsInsideSelectionBoxRect(Vector3 position)
		{
			float rectPosX;
			float rectPosY;
			// Get rect bottom left corner position
			{
				if (_startDragingPos.x <= _endDragingPos.x)
					rectPosX = _startDragingPos.x;
				else
					rectPosX = _endDragingPos.x;

				if (_startDragingPos.y <= _endDragingPos.y)
					rectPosY = _startDragingPos.y;
				else
					rectPosY = _endDragingPos.y;
			}

			_rect.Set(rectPosX, rectPosY, Mathf.Abs(_endDragingPos.x - _startDragingPos.x), Mathf.Abs(_endDragingPos.y - _startDragingPos.y));

			if (_rect.Contains(_camera.WorldToScreenPoint(position)))
				return true;

			return false;
		}
	}
}

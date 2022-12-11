using StrategyGame.Units;
using UnityEngine;
using static StrategyGame.PlayerInputManager;

namespace StrategyGame
{
	[RequireComponent(typeof(UnitsCommander), typeof(InGameUISystem), typeof(UnitSelector))]
	public class Player : MonoBehaviour
	{
		private UnitsCommander _unitCommander;
		private UnitSelector _unitSelector;
		private InGameUISystem _inGameUISystem;

		private void Awake()
		{
			_unitCommander = GetComponent<UnitsCommander>();
			_inGameUISystem = GetComponent<InGameUISystem>();
			_unitSelector = GetComponent<UnitSelector>();
		}

		private void Start()
		{
			//Application.targetFrameRate = 60;

			_inGameUISystem.SwitchTo(_inGameUISystem.s_game);
			_inGameUISystem.e_OnGameScreenOpened.AddListener(() => OnGameScreenOpened());
			InitiateInputs();
		}

		private void InitiateInputs()
		{
			Inputs.InGame.OpenMenu.performed += delegate
			{
				if (_unitCommander.CommandTypeContainer.commandType == typeof(Commands.Move))
				{
					OpenMenu();
				}
			};
		}

		private void OpenMenu()
		{
			_inGameUISystem.SwitchTo(_inGameUISystem.s_menu);
			_unitSelector.EnableBehaviour = false;
		}

		internal void OnGameScreenOpened()
		{
			_unitSelector.EnableBehaviour = true;
		}
	}
}

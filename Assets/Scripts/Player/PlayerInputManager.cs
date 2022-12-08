using UnityEngine;
using Chromium.Utilities.Singleton;
using UnityEngine.InputSystem;

namespace StrategyGame
{
	public class PlayerInputManager : SingletonMonoBehaviour<PlayerInputManager>
	{
		public static StrategyGameInputAction Inputs { get; private set; }
		public static InputAction MousePositionInputAction { get; private set; }

		private void Awake()
		{
			Inputs = new StrategyGameInputAction();
			MousePositionInputAction = Inputs.InGame.MousePosition;
		}

		private void OnEnable()
		{
			Inputs.Enable();
		}

		private void OnDisable()
		{
			Inputs.Disable();
		}
	}
}

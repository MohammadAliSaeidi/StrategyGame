using UnityEngine;
using UnityEngine.Events;

namespace StrategyGame
{
	public class InGameUISystem : Chromium.UILibrary.UISystem
	{
		internal UnityEvent e_OnGameScreenOpened = new();

		[field: Header("Screens")]
		[field: SerializeField] public InGameScreen s_game { get; private set; }
		[field: SerializeField] public InGameMenuScreen s_menu { get; private set; }

		protected override void GetAllScreens()
		{
			_screensList.Add(s_game);
			_screensList.Add(s_menu);
		}

		protected override void InitUI()
		{
			s_menu.InitiateUI(this);

			s_game.OnScreenStart.AddListener(() => e_OnGameScreenOpened?.Invoke());
		}
	}
}
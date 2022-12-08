using System;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame
{
	public class InGameMenuScreen : Chromium.UILibrary.UIScreen
	{
		[SerializeField]
		private Button b_Resume;

		[SerializeField]
		private Button b_Settings;

		[SerializeField]
		private Button b_Exit;

		internal void InitiateUI(InGameUISystem uIManager)
		{
			b_Resume.onClick.AddListener(() => uIManager.SwitchTo(uIManager.s_game));
		}
	}
}

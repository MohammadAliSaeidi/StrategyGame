using StrategyGame.Commands;
using UnityEngine;

namespace StrategyGame.Units
{
	public partial class UnitsCommander
	{
		[System.Serializable]
		public class MouseIcons
		{
			[field: SerializeField] public GameObject Normal { get; private set; }
			[field: SerializeField] public GameObject Attack { get; private set; }
			[field: SerializeField] public GameObject Move { get; private set; }

			private GameObject _currentMouseIcon;

			public void SwitchMouseIconToNormal()
			{
				if (_currentMouseIcon && _currentMouseIcon != Normal)
				{
					_currentMouseIcon.SetActive(false);
				}
				Normal.SetActive(true);
				_currentMouseIcon = Normal;
			}

			public void SwitchMouseIcon<T>() where T : Command
			{
				GameObject commandMouseIcon = null;

				if (typeof(T) == typeof(Move))
					commandMouseIcon = Move;

				else if (typeof(T) == typeof(Attack))
					commandMouseIcon = Attack;

				else
				{
					Debug.LogError($"type of <color=red><b>{typeof(T)}</b></color> command is not implemented for mouse icons");
					return;
				}

				if (_currentMouseIcon && _currentMouseIcon != commandMouseIcon)
				{
					_currentMouseIcon.SetActive(false);
				}
				commandMouseIcon.SetActive(true);
				_currentMouseIcon = commandMouseIcon;
			}
		}
	}
}

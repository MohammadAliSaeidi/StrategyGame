using UnityEngine;
using System.Collections.Generic;

namespace StrategyGame.Units
{
	public class UnitsContainer : MonoBehaviour
	{
		[SerializeField]
		private bool _getUnitsFromSceneAtStart = true;

		public List<Unit> UnitsList { get; private set; } = new List<Unit>();

		private void Start()
		{
			if (_getUnitsFromSceneAtStart)
			{
				GetAllUnits();
			}
		}

		private void GetAllUnits()
		{
			var unitGOs = GameObject.FindGameObjectsWithTag("Unit");
			foreach (var unitGO in unitGOs)
			{
				UnitsList.Add(unitGO.GetComponent<Unit>());
			}
		}
	}
}

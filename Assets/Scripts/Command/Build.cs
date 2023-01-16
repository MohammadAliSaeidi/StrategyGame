using StrategyGame.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyGame.Commands
{
    public class Build : Command
	{
		public readonly Structure Structure;

		public Build(Structure structure)
		{
			Structure = structure;
		}


		//[SerializeField]
		//private StructuresContainer _structuresContainer;
	}
}

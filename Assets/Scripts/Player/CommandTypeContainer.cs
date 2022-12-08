using StrategyGame.Commands;
using System;

namespace StrategyGame.Units
{
	public class CommandTypeContainer
	{
		public Type commandType;

		public void SetType<T>() where T : Command
		{
			commandType = typeof(T);
		}
	}
}

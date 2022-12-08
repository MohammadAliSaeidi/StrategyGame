namespace StrategyGame.Units
{
    public abstract class Tank : Unit
    {
        protected override IEnumerator Co_Move()
        {
            _agent

            while (!HasReachedDestination())
            {
                yield return _navMeshCalculationDelay;
            }
            Debug.Log($"unit <color=yellow>{name}</color> <color=green><b> has reached </b></color> to destination: {_agent.destination}.");

            _command = null;
        }
    }
}
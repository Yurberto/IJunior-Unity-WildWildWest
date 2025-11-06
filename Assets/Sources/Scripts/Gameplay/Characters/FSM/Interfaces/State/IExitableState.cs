public interface IExitableState
{
    public void SetStateChanger(IStateChanger stateChanger);
    public void Exit();
}

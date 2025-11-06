public interface IStateChanger
{
    public void ChangeState<T>() where T : IExitableState;
}

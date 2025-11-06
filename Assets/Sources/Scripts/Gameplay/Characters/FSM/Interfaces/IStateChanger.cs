public interface IStateChanger
{
    public void ChangeState<T>() where T : IState;
}

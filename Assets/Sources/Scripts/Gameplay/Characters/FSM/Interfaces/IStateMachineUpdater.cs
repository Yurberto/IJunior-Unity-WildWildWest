public interface IStateMachineUpdater
{
    public void FixedUpdateState();
    public void UpdateState();
    public void LateUpdateState(); 
}

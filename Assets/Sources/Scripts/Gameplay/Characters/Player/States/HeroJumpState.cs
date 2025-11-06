public class HeroJumpState : IEnterableState, IExitableState, IUpdatableState
{
    private const float Epsilon = 0.01f;

    private readonly IGroundDetector _groundDetector;
    private readonly IJumper _jumper;
    private readonly IHeroView _heroView;

    private IStateChanger _stateChanger;

    private bool _hasLeftGround = false;

    public HeroJumpState(IGroundDetector groundDetector, IJumper jumper, IHeroView heroView)
    {
        _groundDetector = groundDetector;
        _jumper = jumper;
        _heroView = heroView;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        _jumper.Jump(_heroView.PlayerSetting.JumpForce);
    }

    public void Exit()
    {
        _hasLeftGround = false;
    }

    public void Update()
    {
        if (_hasLeftGround == false)
        {
            if (_jumper.Velocity.y >= Epsilon)
                _hasLeftGround = true;
        }

        if (_hasLeftGround && _groundDetector.IsGrounded() && _jumper.Velocity.y <= Epsilon)
        {
            if (_jumper.Velocity.x > Epsilon || _jumper.Velocity.z > Epsilon)
                ChangeToMoveState();
            else
                ChangeToIdleState();
        }
    }

    private void ChangeToMoveState()
    {
        _stateChanger.ChangeState<HeroMoveState>();
    }

    private void ChangeToIdleState()
    {
        _stateChanger.ChangeState<HeroIdleState>(); 
    }
}

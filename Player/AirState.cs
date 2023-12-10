using Godot;

public partial class AirState : State
{
    [Export]
    private State landingState;
    private bool hasDoubleJumped = false;
    private float dobuleJumpVelocity = -500.0f;

    public override void stateProcess(double delta)
    {
        this.isLandingMethod();

        if (!character.IsOnFloor() && isLanding)
        {
            this.nextState = landingState;
        }

    }

    public override void onExit()
    {
        if (nextState == landingState) {
            playback.Travel("fall");
            hasDoubleJumped = false;
        }
    }

    public override void stateInput(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("jump") && !hasDoubleJumped)
            this.doubleJump();
    }

    private void doubleJump()
    {
        Vector2 velocity = this.character.Velocity;
        velocity.Y = this.dobuleJumpVelocity;
        this.character.Velocity = velocity;
        playback.Travel("double_jump");
        hasDoubleJumped = true;
    }

}

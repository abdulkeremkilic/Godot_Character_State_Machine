using Godot;

public partial class LandingState : State
{
    [Export]
    private State groundState;

    public override void stateProcess(double delta)
    {        
        this.can_move = true;
        
        if (character.IsOnFloor())
        {
            this.nextState = groundState;
        }
    }

    public override void onExit()
    {
        playback.Travel("move");
    }
}

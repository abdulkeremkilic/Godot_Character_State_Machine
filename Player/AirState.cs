using Godot;

public partial class AirState : State
{
    [Export]
    private State landingState;

    public override void stateProcess(double delta)
    {
        this.isLandingMethod();

        if (!character.IsOnFloor() && isLanding) 
        {
            this.nextState = landingState;
        }
        
    }

}

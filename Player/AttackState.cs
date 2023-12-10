using Godot;
using System;

public partial class AttackState : State
{

	[Export]
	public State groundState;

    public override void stateProcess(double delta)
    {
		if(this.character.IsOnFloor() && !Input.IsActionJustReleased("attack")) {
			this.nextState = groundState;
			// will overlap with landing state
		}
    }


    public override void onExit()
    {
        playback.Travel("move");
    }

}

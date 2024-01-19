using Godot;
using System;
using System.Threading;

public partial class AttackState : State
{

  [Export]
  public State groundState;

    public override void stateProcess(double delta)
  {
    if (this.character.IsOnFloor() && !Input.IsActionJustReleased("attack"))
    {
      this.nextState = groundState;
    }
  }


  public override void onExit()
  {
    playback.Travel("move");
  }

  private bool onAnimationFinished(String name) {
		if(this.playback.GetCurrentNode() == name)
			return true;
		else 
			return false;
	}

}

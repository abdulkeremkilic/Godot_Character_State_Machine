using Godot;
using System;

public partial class StateLabel : Label
{
	[Export]
	public CharacterStateMachine stateMachine;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Text = "State: " + this.stateMachine.currentState.Name;
	}
}

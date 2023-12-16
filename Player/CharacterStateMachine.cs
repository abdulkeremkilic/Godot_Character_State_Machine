using Godot;

public partial class CharacterStateMachine : Node
{
	[Export]
	public State currentState;
	[Export]
	public CharacterBody2D character;
	[Export]
	public AnimationTree animationTree;
	[Export]
	public Godot.Collections.Array<State> stateList;


	public override void _Ready()
	{
		foreach (State state in stateList)
		{
			state.playback = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		currentState.character = this.character;
		if (currentState.nextState != null)
		{
			this.switchState(currentState.nextState);
		}
		else
		{
			currentState.stateProcess(delta);
		}
	}

	public void switchState(State newState)
	{
		if (currentState != null)
		{
			currentState.onExit();
			currentState.nextState = null;
		}

		currentState.onEnter();
		currentState = newState;
	}

	public bool checkIfCanMove()
	{
		return this.currentState.can_move;
	}

	public override void _UnhandledInput(InputEvent @event) //detects if there is an input
	{
		currentState.stateInput(@event);
	}
}

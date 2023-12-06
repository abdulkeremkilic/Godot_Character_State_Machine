using Godot;

public partial class State : Node
{
	[Export] 
	public bool can_move = true;
	public CharacterBody2D character; 
	public State nextState;
    public bool isLanding = false;


	virtual public void isLandingMethod() {
		if(this.character.Velocity.Y > 0)
			isLanding = true;
		else if(this.character.Velocity.Y < 0)
			isLanding =	false;
	}

    virtual public void stateProcess(double delta) {
		return;
	}

	virtual public void stateInput(InputEvent inputEvent) {
		return;
	}

	virtual public void onEnter() {
		return;
	}

	virtual public void onExit() {
		return;
	}
}

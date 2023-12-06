using Godot;

public partial class GroundState : State
{
	[Export]
	private float jumpVelocity = -450;
	[Export]
	private State airState;

	public override void stateProcess(double delta) {

		this.isLandingMethod();

		if(!character.IsOnFloor() && !isLanding) {
			this.nextState = airState;
		}

	}
	
	public override void stateInput(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("jump"))
		{
			this.jump();
		}
	}

	public void jump()
	{
		Vector2 velocity = this.character.Velocity;
		velocity.Y = jumpVelocity;
		this.character.Velocity = velocity;
		GD.Print(character.Velocity.X);
		nextState = airState;
	}
}


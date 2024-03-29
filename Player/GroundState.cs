using Godot;

public partial class GroundState : State
{
	[Export]
	private float jumpVelocity = -450;
	[Export]
	private State airState;
	[Export]
	private State attactState;

	public override void stateProcess(double delta)
	{

		//GD.Print(playback.GetCurrentNode()); // this brings which node you are playing
		this.isLandingMethod();

		if (!character.IsOnFloor() && !isLanding)
		{
			this.nextState = airState;
		}

	}

	public override void stateInput(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("jump"))
		{
			this.jump();
		}

		if (inputEvent.IsActionPressed("attack"))
		{
			this.attack();
		}

		// if attact_1 is playing and actionPressed(attack)
		//play attack_2 
	}

	public void jump()
	{
		Vector2 velocity = this.character.Velocity;
		velocity.Y = jumpVelocity;
		this.character.Velocity = velocity;
		nextState = airState;
		playback.Travel("jump");
	}

	public void attack()
	{
		GD.Print(playback.GetCurrentNode());
		playback.Travel("attack_2");
		nextState = attactState;
		//will need to stay in attack state during the animation.
	}

}


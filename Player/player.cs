using Godot;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public AnimationTree animationTree;
	public AnimatedSprite2D animatedSprite2D;
	private CharacterStateMachine stateMachine;
	private Vector2 direction;

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		stateMachine = GetNode<CharacterStateMachine>("CharacterStateMachine");
		animationTree.Active = true;
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction.X != 0 && stateMachine.checkIfCanMove())
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		this.updateAnimationParameters();
		this.updateFacingDirection();
		MoveAndSlide();
	}

	private void updateFacingDirection() {
		if (direction.X > 0)
			animatedSprite2D.FlipH = false;
		else if(direction.X < 0)
			animatedSprite2D.FlipH = true;
	}

	private void updateAnimationParameters() {
		animationTree.Set("parameters/move/blend_position", direction.X);
	}
}

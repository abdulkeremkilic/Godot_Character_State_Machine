using Godot;

public partial class world : Node2D
{
	[Export]
	public player player;
	[Export]
	public Camera2D playerCamera;
	
    public override void _PhysicsProcess(double delta)
	{
		this.handleCameraZoom();
		this.handleTimeSlow();
	}

	private void handleCameraZoom()
	{
		Vector2 naturalPosition = new Vector2();
		naturalPosition.X = 2;
		naturalPosition.Y = 2;

		Vector2 zoomVector = new Vector2();
		zoomVector.X = 2.1f;
		zoomVector.Y = 2.1f;

		if (player.stateMachine.currentState.Name == "Attack")
			this.playerCamera.Zoom = zoomVector;
		else
			this.playerCamera.Zoom = naturalPosition;

	}

	private void handleTimeSlow()
	{
		if (Input.IsActionPressed("slowTime"))
			Engine.TimeScale = 0.5;
		else
			Engine.TimeScale = 1;
	}
}

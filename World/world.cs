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
        this.handleCameraPozition();
    }

    private void handleCameraPozition()
    {
        Vector2 offsetValue = new Vector2();
        offsetValue.X = 90;
        offsetValue.Y = -25;

        this.playerCamera.Offset = offsetValue;
        this.playerCamera.LimitLeft = -60;
        this.playerCamera.LimitRight = 3250;
    }

    private void handleCameraZoom()
	{
		Vector2 naturalPosition = new Vector2();
		naturalPosition.X = 4;
		naturalPosition.Y = 4;

		Vector2 zoomVector = new Vector2();
		zoomVector.X = 4.1f;
		zoomVector.Y = 4.1f;

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

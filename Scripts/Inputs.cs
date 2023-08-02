using Godot;
using System;

public partial class Inputs : Node2D
{
    [Signal]
    public delegate void ImpulsoEventHandler(int impulsoLeft, int impulsoRight);

    (int left, int right) _impulso = (0, 0);

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _impulso = (0, 0);
        if (Input.IsActionPressed("A"))
        {
            _impulso.left = 1;
        }
        if (Input.IsActionPressed("Z"))
        {
            _impulso.left = -1;
        }
        if (Input.IsActionPressed("K"))
        {
            _impulso.right = 1;
        }
        if (Input.IsActionPressed("M"))
        {
            _impulso.right = -1;
        }
        if (Input.IsActionPressed("QUIT"))
        {
            GetTree().Quit();
        }
        EmitSignal(SignalName.Impulso, _impulso.left, _impulso.right);
    }
}

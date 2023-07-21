using Godot;
using System;

public partial class roda : Node2D
{
    private int _impulso = 0;
    private float _velocity = 0;

    private void OnImpulso(int left, int right)
    {
        _impulso = left;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public override void _PhysicsProcess(double delta)
    {
        Rotation += _impulso * (float)delta;
        Position += new Vector2(_impulso * _velocity, 0);
    }
}

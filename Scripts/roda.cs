using Godot;
using System;

public partial class roda : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Position = new Vector2(300, 0);
    }

    public override void _Process(double delta) { }
}

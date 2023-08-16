using Godot;
using System;

public partial class UI : CanvasLayer
{
    [Export]
    private RichTextLabel[] _textos;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        for (int i = 0; i < _textos.Length; i++)
        {
            GD.Print(_textos.Length);
            _textos[i].Position = new Vector2(2000, 50f * i);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}

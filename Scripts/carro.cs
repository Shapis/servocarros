using Godot;
using System;

public partial class carro : Node2D
{
    private void OnImpulso(int left, int right)
    {
        // GD.Print("Impulso: ", left, " ", right);
    }

    [Export]
    private float _diameter = 1;

    [Export]
    private float _distanciaEntreRodas = 1;

    [Export]
    private float _pesoDoCarro = 1;

    [Export]
    private float _velocidadeMaxima = 1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(GetNode("roda_esquerda"));
        GD.Print(GetNode("roda_direita"));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}

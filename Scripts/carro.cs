using Godot;
using System;

public partial class carro : Node2D
{
    #region Inputs
    private void OnImpulso(int left, int right)
    {
        // GD.Print("Impulso: ", left, " ", right);
    }
    #endregion

    #region Exports
    [Export]
    private float _diameter = 1;

    [Export]
    private float _distanciaEntreRodas = 250;

    [Export]
    private float _pesoDoCarro = 1;

    [Export]
    private float _velocidadeMaxima = 1;
    #endregion

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Sprite2D>("roda_esquerda").Position = new Vector2(0, -_distanciaEntreRodas / 2);
        GetNode<Sprite2D>("roda_direita").Position = new Vector2(0, _distanciaEntreRodas / 2);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}

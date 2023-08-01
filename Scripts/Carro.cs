using Godot;
using System;

public partial class Carro : Node2D
{
    #region Inputs
    Roda _RodaEsquerda = new Roda();
    Roda _RodaDireita = new Roda();

    private void OnImpulso(int left, int right)
    {
        _RodaEsquerda.Impulso = left;
        _RodaDireita.Impulso = right;
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

    private float _sumVelocity = 0;
    private float _diffVelocity = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Sprite2D>("roda_esquerda").Position = new Vector2(0, -_distanciaEntreRodas / 2);
        GetNode<Sprite2D>("roda_direita").Position = new Vector2(0, _distanciaEntreRodas / 2);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public override void _PhysicsProcess(double delta)
    {
        _RodaEsquerda.Speed = 0f;
        _RodaDireita.Speed = 1;

        _sumVelocity = (_RodaEsquerda.Speed + _RodaDireita.Speed) / 2f;
        _diffVelocity = (-_RodaDireita.Speed + _RodaEsquerda.Speed);

        Rotation += _diffVelocity * (float)delta;

        float cos = (float)Math.Cos(Rotation);
        float sin = (float)Math.Sin(Rotation);

        Position += new Vector2(_sumVelocity * cos, _sumVelocity * sin) * (float)delta;

        GD.Print(Position);
    }
}

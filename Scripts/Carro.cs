using Godot;
using System;

public partial class Carro : Node2D, ICarroDiagnosticos
{
    public event EventHandler<DiagnosticosInfo> OnCarroUpdateEvent;

    #region Inputs
    Roda _RodaEsquerda = new Roda();
    Roda _RodaDireita = new Roda();

    private void OnImpulso(int left, int right)
    {
        if (!_autopilot)
        {
            _RodaEsquerda.Impulso = left;
            _RodaDireita.Impulso = right;
        }
    }
    #endregion

    #region Exports
    [Export]
    private float _diametroDaRoda = 1;

    [Export]
    private float _distanciaEntreRodas = 200;

    [Export]
    private float _pesoDoCarro = 1000; // Gramas

    [Export]
    private float _velocidadeMaxima = 1; // mm/s

    [Export]
    private float _tempoDeAceleracao = 500; // milisegundos
    #endregion

    private bool _autopilot = false;
    private float _sumVelocity = 0;
    private float _diffVelocity = 0;
    private double _timeElapsed = 0;
    private double _deltaTime = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Sprite2D>("roda_esquerda").Position = new Vector2(0, -_distanciaEntreRodas / 2);
        GetNode<Sprite2D>("roda_direita").Position = new Vector2(0, _distanciaEntreRodas / 2);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Position.X >= 2600)
        {
            Position = new Vector2(-6700, Position.Y);
        }
        else if (Position.X <= -6700)
        {
            Position = new Vector2(2600, Position.Y);
        }
        else if (Position.Y <= -3850)
        {
            Position = new Vector2(Position.X, 4150);
        }
        else if (Position.Y >= 4150)
        {
            Position = new Vector2(Position.X, -3850);
        }
        _deltaTime = delta;
        _timeElapsed += delta;
        // _RodaDireita.RadialSpeed = -100f * 2f * (float)Math.PI;
        // _RodaEsquerda.RadialSpeed = 100f * 2f * (float)Math.PI;
        _RodaDireita.Update((float)delta, _pesoDoCarro, _velocidadeMaxima, _tempoDeAceleracao);
        _RodaEsquerda.Update((float)delta, _pesoDoCarro, _velocidadeMaxima, _tempoDeAceleracao);
        // _RodaEsquerda.Speed = 100f * (float)Math.PI * 2f;
        // _RodaDireita.Speed = -100f * (float)Math.PI * 2f;

        _sumVelocity = (_RodaEsquerda.RadialSpeed + _RodaDireita.RadialSpeed) / 2f;
        _diffVelocity =
            (_RodaDireita.RadialSpeed - _RodaEsquerda.RadialSpeed) / (_distanciaEntreRodas);

        Rotation -= _diffVelocity * (float)delta;

        Position +=
            new Vector2(
                _sumVelocity * (float)Math.Cos(Rotation),
                _sumVelocity * (float)Math.Sin(Rotation)
            ) * (float)delta;

        if (Rotation >= 2f * (float)Math.PI)
        {
            Rotation -= 2f * (float)Math.PI;
            GD.Print(_timeElapsed);
        }

        // GD.Print("Posicao: " + Position);
        // GD.Print(Position);
        OnCarroUpdate(
            this,
            new DiagnosticosInfo
            {
                DiametroDaRoda = _diametroDaRoda,
                DistanciaEntreRodas = _distanciaEntreRodas,
                PesoDoCarro = _pesoDoCarro,
                VelocidadeMaxima = _velocidadeMaxima,
                VelocidadeAtual = _sumVelocity,
                Posicao = Position,
                VelocidadeRadial = new Vector2(_RodaEsquerda.RadialSpeed, _RodaDireita.RadialSpeed),
                VelocidadeAngular = _diffVelocity,
            }
        );
    }

    public void OnCarroUpdate(object sender, DiagnosticosInfo e)
    {
        OnCarroUpdateEvent?.Invoke(this, e);
    }
}

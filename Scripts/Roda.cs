using System;

public class Roda
{
    public int Impulso { get; set; }
    public float RadialSpeed { get; set; } = 0;
    public float Speed => RadialSpeed;

    public void Update(
        float delta,
        float pesoDoCarro,
        float velocidadeMaxima,
        float tempoDeAceleracao
    )
    {
        RadialSpeed += delta * velocidadeMaxima * (1000f / tempoDeAceleracao) * Impulso;

        if (RadialSpeed > velocidadeMaxima)
        {
            RadialSpeed = velocidadeMaxima;
        }
        else if (RadialSpeed < -velocidadeMaxima)
        {
            RadialSpeed = -velocidadeMaxima;
        }
    }
}

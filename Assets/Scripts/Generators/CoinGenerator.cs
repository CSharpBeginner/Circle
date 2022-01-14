using UnityEngine;

public class CoinGenerator : Generator
{
    [SerializeField] private int _lineLength;
    [SerializeField] private Spawner _coinsSpawner;
    [SerializeField] private Generator _randomObjectGenerator;

    private int _iterationsAmount = 1;

    public override Generator Generate(Vector2 point)
    {
        _coinsSpawner.Spawn(point);
        _iterationsAmount++;

        if (_iterationsAmount == _lineLength)
        {
            _iterationsAmount = 1;
            return _randomObjectGenerator;
        }

        return this;
    }
}

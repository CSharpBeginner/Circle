using UnityEngine;

public class RandomObjectGenerator : Generator
{
    [SerializeField] private Spawner _obstaclesSpawner;
    [SerializeField] private Spawner _coinsSpawner;
    [SerializeField] private Generator _coinGenerator;

    public override Generator Generate(Vector2 point)
    {
        if (_obstaclesSpawner.TrySpawn(point))
        {
            return this;
        }
        else if (_coinsSpawner.TrySpawn(point))
        {
            return _coinGenerator;
        }

        return this;
    }
}

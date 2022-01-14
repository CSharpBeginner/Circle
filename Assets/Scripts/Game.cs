using UnityEngine.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _groundSpawner;
    [SerializeField] private Transform _camera;
    [SerializeField] private Grid _grid;
    [SerializeField] private Generator _firstGenerator;
    [SerializeField] private int _groundLevel;
    [SerializeField] private int _spawnedOffsetX;

    private Generator _currentGenerator;
    private Vector2Int _center;

    private void Awake()
    {
        _center = _grid.WorldToGridPosition(_camera.position);

        for (int i = -_spawnedOffsetX + 1; i <= _spawnedOffsetX; i++)
        {
            _groundSpawner.Spawn(_grid.GridToWorldPosition(_center + new Vector2Int(i, _groundLevel)));
        }

        _currentGenerator = _firstGenerator;
    }

    private void OnEnable()
    {
        _player.Dead += BackToMainMenu;
    }

    private void OnDisable()
    {
        _player.Dead -= BackToMainMenu;
    }

    private void Update()
    {
        if (TrySetNewCenter())
        {
            Vector2Int groundTile = _center + new Vector2Int(_spawnedOffsetX, _groundLevel);
            Vector2 groundSpawnPoint = _grid.GridToWorldPosition(groundTile);
            _groundSpawner.Spawn(groundSpawnPoint);
            Vector2 onGroundSpawnPoint = _grid.GridToWorldPosition(groundTile + Vector2Int.up);
            _currentGenerator = _currentGenerator.Generate(onGroundSpawnPoint);
        }
    }

    private bool TrySetNewCenter()
    {
        Vector2Int newCenter = _grid.WorldToGridPosition(_camera.position);

        if (_center != newCenter)
        {
            _center = newCenter;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(ScenesNames.Menu);
    }
}

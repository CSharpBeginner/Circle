using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolLength;
    [SerializeField] private float _chance;

    private GameObject[] _pool;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _pool = new GameObject[_poolLength];

        for (int i = 0; i < _poolLength; i++)
        {
            _pool[i] = Instantiate(_prefab, transform);
        }
    }

    public bool TrySpawn(Vector2 point)
    {
        if (_chance > Random.Range(0f, 1f))
        {
            if (Spawn(point) == null)
            {
                return false;
            }

            return true;
        }

        return false;
    }

    public GameObject Spawn(Vector2 point)
    {
        GameObject spawnedGameObject = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);

        if (spawnedGameObject != null)
        {
            spawnedGameObject.transform.position = point;
            spawnedGameObject.SetActive(true);
            return spawnedGameObject;
        }

        return null;
    }
}

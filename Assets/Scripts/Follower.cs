using UnityEngine;
using UnityEngine.Events;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _offsetX;
    private Vector2 _previousPosition;

    public event UnityAction<Vector2> WorldPositionChanged;

    private void Awake()
    {
        _offsetX = transform.position.x - _player.transform.position.x;
        _previousPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + _offsetX, transform.position.y, transform.position.z);

        if (_previousPosition != new Vector2(transform.position.x, transform.position.y))
        {
            _previousPosition = transform.position;
            WorldPositionChanged?.Invoke(_previousPosition);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private RaycastHit2D[] _results = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody2D;

    public event UnityAction Dead;

    public void Die()
    {
        Dead?.Invoke();
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsOnSurface())
        {
            Jump();
        }

        Move();
    }

    private bool IsOnSurface()
    {
        int count = _rigidbody2D.Cast(Vector2.down, _results, 0.1f);
        return count > 0;
    }

    private void Jump()
    {
        _rigidbody2D.velocity += Vector2.up * _jumpForce;
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }
}

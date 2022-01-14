using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private float _cellSize;

    public Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x * _cellSize, gridPosition.y * _cellSize);
    }

    public Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int((int)(worldPosition.x / _cellSize), (int)(worldPosition.y / _cellSize));
    }
}

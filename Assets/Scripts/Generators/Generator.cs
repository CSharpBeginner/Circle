using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    public abstract Generator Generate(Vector2 point);
}

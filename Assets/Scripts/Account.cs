using UnityEngine;
using UnityEngine.Events;

public class Account : MonoBehaviour
{
    private int _value;

    public event UnityAction<int> Changed;

    public void Increase(int value)
    {
        _value += value;
        Changed?.Invoke(_value);
    }
}

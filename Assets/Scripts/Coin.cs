using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Account>(out Account account))
        {
            account.Increase(_value);
            gameObject.SetActive(false);
        }
    }
}

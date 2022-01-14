using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Shower : MonoBehaviour
{
    [SerializeField] private Account _account;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _account.Changed += Show;
    }

    private void OnDisable()
    {
        _account.Changed -= Show;
    }

    private void Show(int value)
    {
        _text.text = value.ToString();
    }
}

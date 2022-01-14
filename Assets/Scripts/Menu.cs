using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(ScenesNames.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

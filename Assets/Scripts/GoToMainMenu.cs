using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Menu";

    public void GoToMenu()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}

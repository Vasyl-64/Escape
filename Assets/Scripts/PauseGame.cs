using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private CursorToggle _cursor;
    [SerializeField] private string _sceneToLoad = "Game";

    private bool _isPaused;
    private bool _isEscaped;

    private void Awake()
    {
        _isPaused = false;

        _pausePanel.SetActive(_isPaused);

        _cursor.ShowCursor(_isPaused);

        Time.timeScale = 1.0f;
    }

    public void Escaped() { _isEscaped = true; }

    public void TogglePause()
    {
        if (!_isEscaped)
        {
            _isPaused = !_isPaused;

            _pausePanel.SetActive(_isPaused);

            _cursor.ShowCursor(_isPaused);

            Time.timeScale = _isPaused ? 0.0f : 1.0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}

using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private CursorToggle _cursor;
    [SerializeField] private PauseGame _pauseGame;

    private bool _isEscaped = true;

    public void ShowWin()
    {
        _winPanel.SetActive(true);

        _cursor.ShowCursor(true);

        _pauseGame.Escaped();

        Time.timeScale = 0.0f;
    }

    public bool IsEscaped() { return _isEscaped; }
}

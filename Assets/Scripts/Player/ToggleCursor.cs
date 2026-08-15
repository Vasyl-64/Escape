using UnityEngine;

public class CursorToggle : MonoBehaviour
{
    private void Start()
    {
        ShowCursor(false);
    }

    public void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

using UnityEngine;
using System.Collections.Generic;

public class EndKeypad : Interactable
{
    [SerializeField] private List<Enemy> _areEnemies;
    [SerializeField] private WinGame _win;
    
    private bool _openDoor;

    protected override void Interact()
    {
        if (!IsAnyEnemy())
        {
            promptMessage = "Kill all enemies and try open again";
            return;
        }
        
        promptMessage = "Escape";
        _openDoor = true;
    }

    public void TryOpen()
    {
        if (!_openDoor)
            Interact();
        else
            _win.ShowWin();
    }

    private bool IsAnyEnemy()
    {
        return _areEnemies.Count == 0;
    }
}

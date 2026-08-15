using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator _animator;

    public void Uncover()
    {
        _animator.SetBool("Open", true);
        promptMessage = "";
    }
}

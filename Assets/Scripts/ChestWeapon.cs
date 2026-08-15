using UnityEngine;

public class ChestWeapon : MonoBehaviour
{
    [SerializeField] private PlayerShooting _player;

    public void PickWeapon()
    {
        gameObject.SetActive(false);
        _player.PickWeapon();
    }
}

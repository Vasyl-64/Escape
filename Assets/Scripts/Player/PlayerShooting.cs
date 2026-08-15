using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _fireRate;

    private float _shootTimer;
    private bool _canShoot;
    private bool _isWeapon;

    private void Update()
    {
        if (!_canShoot && _isWeapon)
        {
            _shootTimer += Time.deltaTime;
            
            if (_shootTimer > _fireRate)
                _canShoot = true;
        }
    }

    public void PickWeapon()
    {
        _weapon.SetActive(true);
        _isWeapon = true;
        _canShoot = true;
    }

    private void ProgressShooting()
    {
        Transform gunbarrel = _gunBarrel;

        GameObject bulletObj = Instantiate(_bulletPrefab, _gunBarrel.position + _gunBarrel.forward * 0.2f, _gunBarrel.rotation);
        bulletObj.transform.parent = null;
        bulletObj.GetComponent<Bullet>().Initialize(_gunBarrel.forward);

        _shootTimer = 0;
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            ProgressShooting();
            _canShoot = false;
        }
    }
}

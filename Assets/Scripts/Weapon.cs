using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    public WeaponSO weaponSO;

    private int _ammoInMagazine;
    public int ammoInMagazine
    {
        get { return _ammoInMagazine; }
        set { _ammoInMagazine = value;}
    }
    private int _damage;
    public int damage => _damage;
    private int _magazineSize;
    public int magazineSize => _magazineSize;
    private int _maxAmmo;
    public int maxAmmo => _maxAmmo;
    private int _spawnAmmo;
    public int spawnAmmo => _spawnAmmo;
    private Muzzle _muzzle;
    private Shoot _shoot;
    [Inject] PlayerAction playerAction;
    public PlayerInventorySO _playerInventorySO;

    private void Awake()
    {
        _shoot = gameObject.GetComponent<Shoot>();

        _ammoInMagazine = 10;
        _damage = weaponSO.damage;
        _magazineSize = weaponSO.magazineSize;
        _maxAmmo = weaponSO.ammoCapacity;
        _spawnAmmo = weaponSO.spawnAmmo;
        _muzzle = GetComponentInChildren<Muzzle>();
    }

    public void Shoot()
    {
        StartCoroutine(_shoot.ShootProjectile());
        _ammoInMagazine -= 1;
        ActivateMuzzle();
    }

    private void ActivateMuzzle()
    {
        _muzzle.MuzzleEffect();
    }

    public void Reload()
    {
        if (_playerInventorySO.currentAmmo < weaponSO.ammoCapacity) 
        {
            if (_playerInventorySO.currentAmmo > 0 && _ammoInMagazine < 10)
            {
                int ammoNeeded = 10 - _ammoInMagazine;
                int ammoToReload = Mathf.Min(ammoNeeded, _playerInventorySO.currentAmmo);

                _ammoInMagazine += ammoToReload;
                _playerInventorySO.currentAmmo -= ammoToReload;
            }

        }

        else
        {
            int ammoNeeded = 10 - _ammoInMagazine;

            _ammoInMagazine += ammoNeeded;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    public WeaponSO pistol;

    private int _ammoInMagazine;
    public int ammoInMagazine => _ammoInMagazine;
    private int _damage;
    public int damage => _damage;
    private int _magazineSize;
    public int magazineSize => _magazineSize;
    private int _maxAmmo;
    public int maxAmmo => _maxAmmo;
    private float _fireRate;
    public float fireRate => _fireRate;
    private int _spawnAmmo;
    public int spawnAmmo => _spawnAmmo;
    private Muzzle _muzzle;
    [Inject] Shoot shoot;
    [Inject] PlayerAction playerAction;
    public PlayerInventorySO _playerInventorySO;

    private void Awake()
    {
        _ammoInMagazine = 10;
        _damage = pistol.damage;
        _magazineSize = pistol.magazineSize;
        _maxAmmo = pistol.ammoCapacity;
        _fireRate = pistol.fireRate;
        _spawnAmmo = pistol.spawnAmmo;
        _muzzle = GetComponentInChildren<Muzzle>();
    }

    public void Shoot()
    {
        StartCoroutine(shoot.ShootProjectile());
        _ammoInMagazine -= 1;
        ActivateMuzzle();
    }

    private void ActivateMuzzle()
    {
        _muzzle.MuzzleEffect();
    }

    public void Reload()
    {
        if (_playerInventorySO.currentAmmo > 0 && _ammoInMagazine < 10)
        {
            int ammoNeeded = 10 - _ammoInMagazine;
            int ammoToReload = Mathf.Min(ammoNeeded, _playerInventorySO.currentAmmo);

            _ammoInMagazine += ammoToReload;
            _playerInventorySO.currentAmmo -= ammoToReload;
        }
    }

}

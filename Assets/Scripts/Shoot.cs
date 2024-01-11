using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shoot : MonoBehaviour
{
    [Inject] Projectile projectile;
    [Inject] PlayerAction playerAction;
    [Inject] Weapon weapon;
    private float _bulletSpeed = 300f;
    private Transform _bulletSpawnTransform;

    private void Update()
    {
        _bulletSpawnTransform = weapon.gameObject.transform;

    }
    public IEnumerator ShootProjectile()
    {
        Vector3 force = _bulletSpawnTransform.forward * _bulletSpeed;
        GameObject bullet = projectile.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _bulletSpawnTransform.position;
            bullet.transform.rotation = _bulletSpawnTransform.rotation;
            bullet.SetActive(true);
            bullet.transform.GetComponent<Rigidbody>().velocity = force;
            yield return new WaitForSeconds(5f);
            bullet.SetActive(false);
        }
    }
}

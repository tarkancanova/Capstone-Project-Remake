using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shoot : MonoBehaviour
{
    [Inject] Projectile projectile;
    private float _bulletSpeed = 300f;
    private Transform _bulletSpawnTransform;
    private float _bulletDeactivationTime = 2.5f;

    private void Update()
    {
        _bulletSpawnTransform = gameObject.transform;
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
            yield return new WaitForSeconds(_bulletDeactivationTime);
            bullet.SetActive(false);
        }
    }
}

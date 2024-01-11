using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletInteraction : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponScriptableObject;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
        {
            healthSystem.TakeDamage(weaponScriptableObject.damage);
        }
        
    }
}

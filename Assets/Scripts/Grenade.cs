using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Grenade : MonoBehaviour
{
    public GrenadeSO grenadeSO;
    private int _grenadeDamage;
    private int _grenadeRadius;
    private Collider[] _hitColliders = new Collider[9999];
    private Rigidbody _rigidBody;
    private float _bombMoveTime = 1f;
    private float _timeRequiredForExplosion = 3f;


    private void Awake()
    {
        _grenadeDamage = grenadeSO.grenadeDamage;
        _grenadeRadius = grenadeSO.grenadeRadius;
        
        _rigidBody = gameObject.AddComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(StopBomb());
        StartCoroutine(Explode());
        StartCoroutine(ExplosionEffects());
    }

    private IEnumerator StopBomb()
    {
        yield return new WaitForSeconds(_bombMoveTime);
        _rigidBody.velocity = Vector3.zero;
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(_timeRequiredForExplosion);
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _grenadeRadius, _hitColliders);
        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                if (_hitColliders[i].TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
                {
                    healthSystem.currentHealth -= _grenadeDamage;
                }
            }
        }        
    }

    private IEnumerator ExplosionEffects()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}

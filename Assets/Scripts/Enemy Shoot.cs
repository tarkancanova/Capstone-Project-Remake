using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyShoot : MonoBehaviour
{
    Transform playerTransform;
    [Inject] PlayerAction playerAction;
    Weapon weapon;
    bool isShooting;

    private void Awake()
    {
        playerTransform = playerAction.gameObject.transform;
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform.position);


        if ((playerTransform.position.z - transform.position.z <= 0.3f || playerTransform.position.z - transform.position.z >= 0.3f) && isShooting == false)
        {
            weapon.Shoot();
            isShooting = true;
            StartCoroutine(Falsification());
        }
    }

    IEnumerator Falsification()
    {
        yield return new WaitForSeconds(0.3f);
        isShooting = false;
    }
}

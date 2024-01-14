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
    private float _reloadCompletionTime = 1f;

    private void Awake()
    {
        playerTransform = playerAction.gameObject.transform;
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAction != null)
        {
            transform.LookAt(playerTransform.position);


            if ((playerTransform.position.z - transform.position.z <= 1f && playerTransform.position.z - transform.position.z >= -1f) && isShooting == false && weapon.ammoInMagazine > 0)
            {
                weapon.Shoot();
                isShooting = true;
                StartCoroutine(Falsification());
            }

        }

        if (weapon.ammoInMagazine == 0)
        {
            StartReload();
        }


    }

    IEnumerator Falsification()
    {
        yield return new WaitForSeconds(0.3f);
        isShooting = false;
    }

    private void StartReload()
    {
        Invoke("CompleteReload", _reloadCompletionTime);
    }

    private void CompleteReload()
    {
        weapon.Reload();
    }
}

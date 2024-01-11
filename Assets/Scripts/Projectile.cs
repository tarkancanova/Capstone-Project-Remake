using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    public List<GameObject> projectilePool;
    public int amountToPool;



    void Start()
    {
        projectilePool = new List<GameObject>();
        GameObject tempBullet;
        for (int i = 0; i < amountToPool; i++)
        {
            tempBullet = Instantiate(projectile);
            tempBullet.SetActive(false);
            projectilePool.Add(tempBullet);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }

}

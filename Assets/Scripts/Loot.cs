using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private GameObject _magazine;
    [SerializeField] private GameObject _grenade;

    public void DropLoot(Vector3 position)
    {
        int dropDecider = Random.Range(1, 10);
        if (dropDecider < 3)
            Instantiate(_grenade, position, Quaternion.identity);
        if (dropDecider >= 3 && dropDecider < 6)
            Instantiate(_magazine, position, Quaternion.identity);
        else
            return;
    }
}

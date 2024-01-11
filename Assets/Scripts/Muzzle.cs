using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    private const float _muzzleLifetime = 0.1f;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void MuzzleEffect()
    {
        ActivateMuzzle();
        StartCoroutine(DeactivateMuzzle());
    }

    private void ActivateMuzzle()
    {
        this.gameObject.SetActive(true);
    }

    IEnumerator DeactivateMuzzle()
    {
        yield return new WaitForSeconds(_muzzleLifetime);
        this.gameObject.SetActive(false);
    }
}

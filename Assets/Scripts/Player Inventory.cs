using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : MonoBehaviour
{
    public WeaponSO pistolSO;
    public PlayerInventorySO _playerInventorySO;
    public GrenadeSO grenadeSO;


    private void Awake()
    {
        _playerInventorySO.currentAmmo = pistolSO.spawnAmmo;
        _playerInventorySO.currentGrenade = grenadeSO.grenadesAtSpawn;
    }
}

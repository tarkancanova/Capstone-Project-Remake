using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : MonoBehaviour
{
    public WeaponSO pistol;
    public PlayerInventorySO _playerInventorySO;


    private void Awake()
    {
        _playerInventorySO.currentAmmo = pistol.spawnAmmo;
        //_playerInventorySO.currentGrenade = grenade.grenadeAmountAtSpawn;
    }
}

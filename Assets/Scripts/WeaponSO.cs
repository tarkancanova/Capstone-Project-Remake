using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Pistol/Generic")]
public class WeaponSO : ScriptableObject
{
    //This S.O. can be interpreted for any other guns.
    private int _AMMOCAPACITY = 100; 
    private int _DAMAGE = 1; // This will be sent to bullet interaction script which is a component of bullet. So, if another type of bullet added to the game (for example bigger and more damaging ones for machine gun), they can be implemented easily.
    private int _MAGAZINESIZE = 10;
    private int _SPAWNAMMO = 30;


    public int ammoCapacity => _AMMOCAPACITY;
    public int damage => _DAMAGE;
    public int magazineSize => _MAGAZINESIZE;
    public int spawnAmmo => _SPAWNAMMO;

}

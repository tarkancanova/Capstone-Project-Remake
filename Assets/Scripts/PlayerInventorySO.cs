using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(menuName = "Player/Inventory")]
public class PlayerInventorySO : ScriptableObject
{
    //It was initially named PlayerInventorySO because I had no idea I was going to use inventories for enemies as well.
    public int currentAmmo;
    public int currentGrenade;

    
}

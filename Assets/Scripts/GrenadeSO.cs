using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Throwable/Grenade")]
public class GrenadeSO : ScriptableObject
{
    private int _maxGrenadePlayerCanCarry = 3;
    private int _grenadeDamage = 10;
    private int _grenadeRadius = 5;
    private int _grenadesAtSpawn = 1;

    public int maxGrenadePlayerCanCarry => _maxGrenadePlayerCanCarry;
    public int grenadeDamage => _grenadeDamage;
    public int grenadeRadius => _grenadeRadius;
    public int grenadesAtSpawn => _grenadesAtSpawn;
}

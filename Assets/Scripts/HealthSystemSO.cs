using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health System/Database")]
public class HealthSystemSO : ScriptableObject
{
    private const int _PLAYERMAXHEALTH = 20;
    private const int _ENEMYMAXHEALTH = 3;
    private const int _LOOTBOXMAXHEALTH = 1;

    public int playerMaxHealth => _PLAYERMAXHEALTH;
    public int enemyMaxHealth => _ENEMYMAXHEALTH;
    public int lootboxMaxHealth => _LOOTBOXMAXHEALTH;

}

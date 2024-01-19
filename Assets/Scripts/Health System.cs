using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class HealthSystem : MonoBehaviour
{
    public HealthSystemSO healthSystemDatabase;
    public int currentHealth;
    private int _maxHealth;
    public bool alive = true;
    [Inject] private Loot _loot;


    private void Awake()
    {
        SetSpawnHealth();

    }

    private void Update()
    {
        Die();
    }

    private void SetSpawnHealth()
    {
        if (gameObject.CompareTag("Player"))
            currentHealth = healthSystemDatabase.playerMaxHealth;
        else if (gameObject.CompareTag("Enemy"))
            currentHealth = healthSystemDatabase.enemyMaxHealth;
        else if (gameObject.CompareTag("Lootbox"))
            currentHealth = healthSystemDatabase.lootboxMaxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                //SceneManager.LoadScene(1);
            }
            else if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Lootbox"))
            {
                _loot.DropLoot(new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z));
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _UIText;
    public PlayerInventorySO playerInventorySO;
    [Inject] private PlayerAction _playerAction;
    private int _currentHealth;
    private Weapon _weapon;

    private void Awake()
    {
        _weapon = _playerAction.gameObject.GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        _currentHealth = _playerAction.gameObject.GetComponent<HealthSystem>().currentHealth;
        _UIText.text = ("Weapon ammo: " + _weapon.ammoInMagazine + "/" + playerInventorySO.currentAmmo + "\n" + "Grenade: " + playerInventorySO.currentGrenade + "\n" + "Player Health: " + _currentHealth);
    }
}

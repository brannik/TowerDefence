using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Player buffs, equip/unequip weapon, mod HP,Armor etc
    [Header("Player UI")]
    [SerializeField] public GameObject playerUI;
    [Header("Attributes")]
    [SerializeField] public float Health = 100f;
    [SerializeField] public float MaxHealth = 100f;
    [SerializeField] public int Armor = 0;
    [SerializeField] public int MaxArmor = 200;
    [Header("Buffs")]
    [SerializeField] public string[] playerBuffs; // create class Buff instead of string and make it List<Buff> playerBuffs
    [SerializeField] public InputAction action;
    private WeaponController weaponController; // gain access to weapun

    private void OnEnable() {
        action.Enable();
        action.performed += Fire;
    }
    private void OnDisable() {
        action.performed -= Fire;
        action.Disable();
    }
    private void Start() {
        weaponController = gameObject.GetComponent<WeaponController>();
    }
    private void Fire(InputAction.CallbackContext context){
        //Debug.Log("Fire!!!");
        weaponController.WeaponFire();
    }
    private void FixedUpdate() {
        UpdateUI();
    }
    // implement item/buff pickup
    // implement TakeDamageFromEnemy function

    private void UpdateUI(){

    }
}

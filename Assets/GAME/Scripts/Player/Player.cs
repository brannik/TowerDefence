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
    
    [Header("Weapon")]
    [SerializeField] public  WeaponController EquippedWeapon;
    [SerializeField] public GameObject WeaponPosition;
    [SerializeField] public GameObject WeaponUI;
     // gain access to weapun

    
    private void Start() {
        EquipWeapon();
    }
    
    private void FixedUpdate() {
        UpdateUI();
        
    }
    // implement item/buff pickup
    // implement TakeDamageFromEnemy function

    private void UpdateUI(){

    }
    private void EquipWeapon(){
        if(EquippedWeapon != null){
            var a = Instantiate(EquippedWeapon.weaponObject.prefab,WeaponPosition.transform.position,WeaponPosition.transform.rotation);
            a.transform.parent = WeaponPosition.transform;
            a.GetComponent<WeaponController>().SetUI(WeaponUI);
        }
    }
}

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
    
    private void FixedUpdate() {
        UpdateUI();
    }
    // implement item/buff pickup
    // implement TakeDamageFromEnemy function
    private void Fire(InputAction.CallbackContext context){
        //Debug.Log("Fire!!!");
        weaponController.WeaponFire();
    }
    private void UpdateUI(){

    }
    private void PlayerAddHealth(float _value){

    }
    private void PlayerAddArmor(float _value){

    }
    private void PlayerAddAmmo(int _value){

    }
    private void PlayerAddBuff(/* buff object ? */){

    }
    public void TakeDamage(){
        // take damage from enemy
    }
    private void PickupItem(GameObject _itemToPick){
        // pickup items here and redirect to representing function
        if(_itemToPick.CompareTag("PickupItem")){
            // pickup the item
            // Destroy()
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(true){
            // if item can be picked up
            PickupItem(other.gameObject);
        }
    }

}


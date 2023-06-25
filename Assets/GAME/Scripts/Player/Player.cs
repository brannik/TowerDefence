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
<<<<<<< HEAD
        EquipWeapon();
=======
        weaponController = gameObject.GetComponent<WeaponController>();
>>>>>>> 8b0b66e25e288b65015ebba9c17ec809e7a5ecc4
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
<<<<<<< HEAD
    private void EquipWeapon(){
        if(EquippedWeapon != null){
            var a = Instantiate(EquippedWeapon.weaponObject.prefab,WeaponPosition.transform.position,WeaponPosition.transform.rotation);
            a.transform.parent = WeaponPosition.transform;
            a.GetComponent<WeaponController>().SetUI(WeaponUI);
        }
    }
=======
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

>>>>>>> 8b0b66e25e288b65015ebba9c17ec809e7a5ecc4
}


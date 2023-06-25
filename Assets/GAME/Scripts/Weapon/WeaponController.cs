using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// attached to weapon prefab
public class WeaponController : MonoBehaviour
{
    // controll weapon behaviour - add/remove dmg, fire projectile , add ammo or remove ammo on fire etc
    [SerializeField] public WeaponObject weaponObject;
    [SerializeField] public InputAction action;
    [Header("Animation")]
    [SerializeField] public ParticleSystem MuzzleFlash;
    [SerializeField] public GameObject HitEffect;
    // weapon data
    private string _Name;
    private int _MaxAmmo = 0;
    private int _MagazineAmmo = 0;
    private GameObject WeaponUI;

    private Camera _camera;
    private Ray _ray;
    public RaycastHit _hit;
    private GameObject _target;

    private void OnEnable() {
        action.Enable();
        action.performed += Fire;
    }
    private void OnDisable() {
        action.performed -= Fire;
        action.Disable();
    }
    private void Fire(InputAction.CallbackContext context){
        Debug.Log("Fire!!!");
        if(_MagazineAmmo > 0 && _MaxAmmo > 0){
            Fire();  
        }
        
    }
    private void Start() {
        _camera = Camera.main;
    }
    private void FixedUpdate() {
        // rotate weapon to target
        _Name = weaponObject.Name;
        _MaxAmmo = weaponObject.MaxAmmo;
        _MagazineAmmo = weaponObject.MagazineAmmo;
        
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out _hit))
        {
            _target = _hit.transform.gameObject;  
        } 

        UpdateUI();
        RotateWeapon();
    }

    private void Fire(){ 
        // ajust fire rates
        int _bPerSec = weaponObject.BulletsPerSecond;

        if(_MagazineAmmo == 0 && _MaxAmmo >= weaponObject.MagazineAmmo){
            _MagazineAmmo = weaponObject.MagazineAmmo;
            _MaxAmmo -= _MagazineAmmo;
        }
        if(_MagazineAmmo == 0 && _MaxAmmo < weaponObject.MagazineAmmo){
            _MagazineAmmo = _MaxAmmo;
            _MaxAmmo = 0;
        }
        SendBulletAndDoDamage();
        UpdateUI();
    }
    public void AddAmmo(int _amount){
        if(_MagazineAmmo == weaponObject.MagazineAmmo && _MaxAmmo == weaponObject.MaxAmmo) return;
        if(_MagazineAmmo == weaponObject.MagazineAmmo && _MaxAmmo < weaponObject.MaxAmmo){
            // add to total amount ammo
            if((_MaxAmmo + _amount) >= weaponObject.MaxAmmo){
                _MaxAmmo += weaponObject.MaxAmmo - _amount;
                UpdateUI();
                return;
            }else{
                _MaxAmmo += _amount;
                UpdateUI();
                return;
            }
        }
        if(_MagazineAmmo < weaponObject.MagazineAmmo && _MaxAmmo == weaponObject.MaxAmmo){
            // add to magazine ammo
            if((_MagazineAmmo + _amount) >= weaponObject.MagazineAmmo){
                _MagazineAmmo += weaponObject.MagazineAmmo - _amount;
                UpdateUI();
                return;
            }else{
                _MagazineAmmo += _amount;
                UpdateUI();
                return;
            }
        }
        if(_MagazineAmmo < weaponObject.MagazineAmmo && _MaxAmmo < weaponObject.MaxAmmo){
            // add to both ammo
            var leftAmmo = 0;
            if((_MaxAmmo + _amount) >= weaponObject.MaxAmmo){
                leftAmmo = weaponObject.MaxAmmo - _amount;
                _MaxAmmo += weaponObject.MaxAmmo - _amount;
                if((_MagazineAmmo + leftAmmo) >= weaponObject.MagazineAmmo){
                    _MagazineAmmo += weaponObject.MagazineAmmo - leftAmmo;
                    UpdateUI();
                    return;
                }else{
                    _MagazineAmmo += leftAmmo;
                    UpdateUI();
                    return;
                }
            }else{
                _MaxAmmo += _amount;
                UpdateUI();
                return;
            }
        }
        
    }
    public void ModDamage(float _value){

    }
    public void ModRange(float _value){

    }
    public void ModSpeed(float _value){

    }
    public void SetUI(GameObject _ui){
        WeaponUI = _ui;
    }
    private void SendBulletAndDoDamage(){
        // raycast to crosshair target
        if(_target != null){
            Debug.Log("Second -> " + _target.gameObject.name + " deal damage " + weaponObject.BulletDamage);
            // do damage to target
            // animate muzzleflash and hit effect
            //pvar Enemy = _target.gameObject.GetComponentInChildren<Enemy>();
            MuzzleFlash.Play();
        }
        
    }
    
    private void UpdateUI(){
        // display the ammunitions, icon, damage, range, ammo type and name
    }
    private void RotateWeapon(){
        // rotate weapon with camera
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attached to weapon prefab
public class WeaponController : MonoBehaviour
{
    // controll weapon behaviour - add/remove dmg, fire projectile , add ammo or remove ammo on fire etc
    [Header("Equipped Weapon UI")]
    [SerializeField] public GameObject WeaponUI;
    [SerializeField] public WeaponObject weaponObject;
    private CrosshairController crosshair;
    

    // weapon data
    private string _Name;
    private int _MaxAmmo = 0;
    private int _MagazineAmmo = 0;
    private float _bulletRange = 0;
    private float _bulletDamage = 0;
    private Sprite _bulletIcon;
    private 
    void Start()
    {
        crosshair = GameObject.FindAnyObjectByType<CrosshairController>();
        _Name = weaponObject.Name;
        _MaxAmmo = weaponObject.MaxAmmo;
        _MagazineAmmo = weaponObject.MagazineAmmo;
        _bulletRange = weaponObject.bulletController.bulletObject.Range;
        _bulletDamage = weaponObject.bulletController.bulletObject.Damage;
        _bulletIcon = weaponObject.bulletController.bulletObject.Icon;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WeaponFire(){
        // bullet prefab addforce
        if(crosshair.CanFire() == true) {
            if(_MagazineAmmo > 0 || _MaxAmmo > 0){
                _MagazineAmmo --;
                Fire();
            }
            
        }
            
    }
    private void Fire(){ 
        if(_MagazineAmmo == 0 && _MaxAmmo >= weaponObject.MagazineAmmo){
            _MagazineAmmo = weaponObject.MagazineAmmo;
            _MaxAmmo -= _MagazineAmmo;
        }
        if(_MagazineAmmo == 0 && _MaxAmmo < weaponObject.MagazineAmmo){
            _MagazineAmmo = _MaxAmmo;
            _MaxAmmo = 0;
        }
        Debug.Log(weaponObject.weaponType +  " Fire at -> " + crosshair.GetTarget().gameObject.name + " deal damge -> " + _bulletDamage);
        // send pullet prefab
        UpdateUI();
    }
    public void AddAmmo(int _amount){
        if(_MagazineAmmo == weaponObject.MagazineAmmo && _MaxAmmo == weaponObject.MaxAmmo) return;
        if(_MagazineAmmo == weaponObject.MagazineAmmo && _MaxAmmo < weaponObject.MaxAmmo){
            // add to total amount ammo
            if((_MaxAmmo + _amount) >= weaponObject.MaxAmmo){
                _MaxAmmo += weaponObject.MaxAmmo - _amount;
                return;
            }else{
                _MaxAmmo += _amount;
                return;
            }
        }
        if(_MagazineAmmo < weaponObject.MagazineAmmo && _MaxAmmo == weaponObject.MaxAmmo){
            // add to magazine ammo
            if((_MagazineAmmo + _amount) >= weaponObject.MagazineAmmo){
                _MagazineAmmo += weaponObject.MagazineAmmo - _amount;
                return;
            }else{
                _MagazineAmmo += _amount;
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
                    return;
                }else{
                    _MagazineAmmo += leftAmmo;
                    return;
                }
            }else{
                _MaxAmmo += _amount;
                return;
            }
        }
    }
    public void ModDamage(float _amount,bool Add){
        // modify damage here
        if(Add){
            _bulletDamage += _amount;
        }else{
            _bulletDamage -= _amount;
        }
    }
    public void ModRange(float _amount,bool Add){
        // modify range here
        if(Add){
            _bulletRange += _amount;
        }else{
            _bulletRange -= _amount;
        }
    }
    private void UpdateUI(){
        // display the ammunitions, icon, damage, range, ammo type and name
    }
}

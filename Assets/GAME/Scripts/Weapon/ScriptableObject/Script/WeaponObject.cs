using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponType{
    KNIFE,
    MINE,
    CROSSBOW,
    GRENADE,
    PISTOL,
    SHOTGUN,
    RIFLE,
    SNIPER,
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Player/Weapons/Weapon")]
public class WeaponObject : ScriptableObject
{
    [SerializeField] public int ID;
    [SerializeField] public string Name;
    [SerializeField] public WeaponType weaponType;
    [SerializeField] public int MaxAmmo;
    [SerializeField] public int MagazineAmmo;
    [SerializeField] public Sprite Icon;
    [SerializeField] public GameObject prefab;
    [SerializeField] public int BulletsPerSecond = 1;
    [SerializeField] public float BulletRange = 30;
    [SerializeField] public float BulletDamage = 10;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletType{
    PISTOL,
    SHOTGUN,
    RIFLE,
    SNIPER,
}
[CreateAssetMenu(fileName = "Bullet", menuName = "Game/Player/Weapons/Bullet")]
public class BulletObject : ScriptableObject
{
    [SerializeField] public int ID;
    [SerializeField] public BulletType bulletType;
    [SerializeField] public float Damage;
    [SerializeField] public float Range;
    [SerializeField] public Sprite Icon;
    [SerializeField] public GameObject prefab;
}

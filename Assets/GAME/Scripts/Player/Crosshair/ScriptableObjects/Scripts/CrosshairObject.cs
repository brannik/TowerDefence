using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[CreateAssetMenu(fileName = "New Crosshair", menuName = "Game/Player/Crosshair/New Crosshair")]
public class CrosshairObject : ScriptableObject
{
    [SerializeField] public int ID;
    [Header("UI")]
    [SerializeField] public Sprite sprite;
    [SerializeField] public Vector2 normalSize = new Vector2(30f,30f);
    [SerializeField] public Vector2 minSize = new Vector2(20f,20f);
    [SerializeField] public Vector2 maxSize = new Vector2(40f,40f);
    [Space]
    [Header("On Default")]
    [SerializeField] public Color defaultColor = new Color(1,1,1,1);
    [TagField]
    [SerializeField] public string defaultTag;
    [SerializeField] public Vector2 defaultSize  = new Vector2(30f,30f);
    [Space]
    [Header("On Enemy")]
    [SerializeField] public Color enemyColor = new Color(1,0,0,1);
    [TagField]
    [SerializeField] public string enemyTag;
    [SerializeField] public Vector2 enemySize  = new Vector2(20f,20f);
    [Space]
    [Header("On Friendly")]
    [SerializeField] public Color friendlyColor  = new Color(0,1,0,1);
    [TagField]
    [SerializeField] public string friendlyTag;
    [SerializeField] public Vector2 friendlySize = new Vector2(40f,40f);

    
    
}

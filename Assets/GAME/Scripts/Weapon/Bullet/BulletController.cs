using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attacked to BulletPrefab
public class BulletController : MonoBehaviour
{
    // modify bullets stats

    [SerializeField] public BulletObject bulletObject;

private void OnCollisionEnter(Collision other) {
    // do damage to enemy and destroy
}
    
}

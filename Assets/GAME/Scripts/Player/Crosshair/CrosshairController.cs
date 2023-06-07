using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    // player crosshair, getTarget, mdify the crosshair depending of target tag
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    private GameObject _target;
    [SerializeField] public CrosshairObject crosshair;
    [SerializeField] public GameObject UI;
    /*
        get crosshair target with raycast
        return target via function as game object
        update crosshair according conditions - color, size etc
    */
    private void Start() {
        _camera = Camera.main;
        // update crosshair sprite here
    }
    private void FixedUpdate() {
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out _hit))
        {
            _target = _hit.transform.gameObject;
            // format the crosshair depending on target type here 
            //Debug.Log("Clicked on " + _hit.transform.name); 
        } 
        else 
        {
            //Debug.Log("Nothing hit");
        }   
        UpdateCrosshairUI();     
    }
    


    public GameObject GetTarget(){
        return _target;
    }

    public bool CanFire(){
        // check if target is enemy
        return true;
    }
    private void UpdateCrosshairUI(){
        // display target info if needed
    }
}

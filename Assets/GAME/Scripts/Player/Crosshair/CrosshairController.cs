using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class CrosshairController : MonoBehaviour
{
    // player crosshair, getTarget, mdify the crosshair depending of target tag
    private Camera _camera;
    private Ray _ray;
    public RaycastHit _hit;
    private GameObject _target;
    private TextMeshProUGUI _targetText;
    [SerializeField] public CrosshairObject crosshair;
    [SerializeField] public GameObject UI;
    [SerializeField] public Image _image;
    private bool canFire = false;
    /*
        get crosshair target with raycast
        return target via function as game object
        update crosshair according conditions - color, size etc
    */
    private void Start() {
        _camera = Camera.main;
        UI.SetActive(false);
        _targetText = UI.GetComponentInChildren<TextMeshProUGUI>();
        // update crosshair sprite here
    }
    private void FixedUpdate() {
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out _hit))
        {
            _target = _hit.transform.gameObject;  
        }    
        UpdateCrosshairUI();     
        UpdateTargetInfo();
    }

    private void UpdateCrosshairUI(){
        _image.sprite = crosshair.sprite;
        // display target info if needed
        

    }
    private void UpdateTargetInfo(){
        
        if(_target != null && crosshair != null){
            UI.SetActive(true);
            canFire = false;
            if(_target.transform.CompareTag(crosshair.defaultTag)){
                // default target
            }
            if(_target.transform.CompareTag(crosshair.enemyTag)){
                // enemy target
            }
            if(_target.transform.CompareTag(crosshair.friendlyTag)){
                // friendly tag
            }
            // if is enemy or friendly player
            _targetText.SetText(_target.gameObject.name);    
        }
        UI.SetActive(false);
        canFire = false;
    }
    public bool CanFire(){
        return canFire;
    }
    public GameObject GetTarget(){
        return _target;
    }
}

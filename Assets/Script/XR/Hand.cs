using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class Hand : MonoBehaviour
{
    private Animator _animator;
    private SkinnedMeshRenderer _handMesh;

    public float speed;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private static readonly int Grip = Animator.StringToHash("Grip");
    private static readonly int Trigger = Animator.StringToHash("Trigger");

    void Start()
    {
        _animator = GetComponent<Animator>();
       // _handMesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void SetGrip(float val)
    { 
        _gripTarget = val;
    }

    public void SetTrigger(float val)
    {
        _triggerTarget = val;
    }

    public void ToggleVisibility()
    {
        //_handMesh.enabled = !_handMesh.enabled;
        //_rayShoot.enabled = !_rayShoot.enabled;
    }

    private void AnimateHand()
    {
        if (_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * speed);
            _animator.SetFloat(Grip, _gripCurrent);
        }
        
        if (_triggerCurrent != _triggerTarget)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * speed);
            _animator.SetFloat(Trigger, _triggerCurrent);
        }
        
    }
    
    void Update()
    {
        AnimateHand();
    }
    
}

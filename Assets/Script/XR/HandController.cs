using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    private ActionBasedController _controller;
    public Hand _hand;
    void Start()
    {
        _controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        _hand.SetGrip(_controller.activateAction.action.ReadValue<float>());
        _hand.SetTrigger(_controller.selectAction.action.ReadValue<float>());
    }
}

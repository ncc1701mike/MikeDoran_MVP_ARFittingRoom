using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float forwardBackwardTilt = 0;
    [SerializeField] private float sideToSideTilt = 0;
    [SerializeField] private float thrust = 0;
    public HingeJoint thrustLever;
    public Transform joystickKnob;
    public Transform cubeShip;
    
    void Start()
    {
        thrustLever = GetComponent<HingeJoint>();
        cubeShip = GetComponent<Transform>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
        //StartCoroutine(FLightController());
    }

    IEnumerator FLightController()
    {
        MoveShip();
        yield return null;
    }

    private void MoveShip()
    {
        thrust = thrustLever.angle;
        
        //Move craft Up & Down using thrust as speed
        if (thrust > 0 && thrust <= 65)
        {
            Debug.Log("UpThrust " + thrust);
            cubeShip.Translate(Vector3.up * (thrust * 0.001f * Time.deltaTime));
        }
        
        else if (thrust < 0 && thrust >= -65)
        {
            Debug.Log("DownThrust " + thrust);
            cubeShip.Translate(-Vector3.up * (thrust * 0.001f * Time.deltaTime));
        }
        
        
        //Move craft forward & backward using tilt as speed
       /* forwardBackwardTilt = joystickKnob.eulerAngles.x;
        Debug.Log(forwardBackwardTilt);
        if (forwardBackwardTilt < 268 && forwardBackwardTilt > 200)
        {
            //forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward " + forwardBackwardTilt);
            cubeShip.Translate(-Vector3.forward * (forwardBackwardTilt * 0.001f * Time.deltaTime));
        }
        
        else if (forwardBackwardTilt > 270 && forwardBackwardTilt < 340)
        {
            Debug.Log("Forward " + forwardBackwardTilt);
            cubeShip.Translate(Vector3.forward * (forwardBackwardTilt + 0.001f * Time.deltaTime));
        }
        
        //Move craft side to side using tilt as speed
        sideToSideTilt = joystickKnob.rotation.eulerAngles.z;
        Debug.Log(forwardBackwardTilt);
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            Debug.Log("Right " + sideToSideTilt);
            cubeShip.Translate(Vector3.right * (sideToSideTilt * 0.01f * Time.deltaTime));
        }
        
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Right " + sideToSideTilt);
            cubeShip.Translate(Vector3.right * (sideToSideTilt * 0.01f * Time.deltaTime));
        }*/

    }

    void Update()
    {
       MoveShip();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlightController : MonoBehaviour
{
    [SerializeField] private Transform cubeShip;
    [SerializeField] private HingeJoint thrustLever;
    [SerializeField] private ConfigurableJoint impulseLever;
    [SerializeField] private float thrust = 0;
    public Vector3 impulseAngle;
    
    IEnumerator FLightController()
    {
        MoveShip();
        yield return null;
    }
    
    
    private float AngleChange(float v)
    {
        if (v > 180)
        {
            v = v - 360;
        }
        return v;
    }
    
    
    private Vector3 JointRotation(ConfigurableJoint joint)
    {
        Quaternion jointBasis = Quaternion.LookRotation(impulseLever.secondaryAxis, 
                Vector3.Cross(impulseLever.axis, impulseLever.secondaryAxis));
            
        Quaternion jointInverse =Quaternion.Inverse(jointBasis);
            
        var rotation = (jointInverse * Quaternion.Inverse(impulseLever.connectedBody.rotation) *
                            impulseLever.GetComponent<Rigidbody>().transform.rotation * jointBasis).eulerAngles;
            
        impulseAngle = new Vector3(AngleChange(rotation.x), AngleChange(rotation.y), AngleChange(rotation.z));
        
        return impulseAngle;
        }
    

    public void MoveShip()
    {
        //Move craft Up & Down using thrust as speed component
        thrust = thrustLever.angle;
        
        if (thrust > 0 && thrust <= 65)
        {
            //Debug.Log("UpThrust " + thrust);
            cubeShip.Translate(Vector3.up * (thrust * 0.01f * Time.deltaTime));
        }
        
        else if (thrust < 0 && thrust >= -65)
        {
            //Debug.Log("DownThrust " + thrust);
            cubeShip.Translate(-Vector3.down * (thrust * 0.01f * Time.deltaTime));
        }
        
        
        //Move craft forward & backward using impulse as speed component
        JointRotation(impulseLever);
        //Debug.Log(impulseAngle.y);
        
        if (impulseAngle.x > 0 && impulseAngle.x <= 65)
        {
            // Debug.Log("Forward " + impulseAngle.x);
            cubeShip.Translate(Vector3.forward * (impulseAngle.x * 0.01f * Time.deltaTime));
        }
        else if (impulseAngle.x < 0 && impulseAngle.x > -65)
        {
            //Debug.Log("Backward " + impulseAngle.x);
            cubeShip.Translate(-Vector3.back * (impulseAngle.x * 0.01f * Time.deltaTime));
        }
        
        if (impulseAngle.y > 0 && impulseAngle.y <= 65)
        {
            // Debug.Log("Right" + impulseAngle.y);
            cubeShip.Translate(Vector3.right * (impulseAngle.y * 0.01f * Time.deltaTime));
        }
        else if (impulseAngle.y < 0 && impulseAngle.y > -65)
        {
            //Debug.Log("Left " + impulseAngle.y);
            cubeShip.Translate(-Vector3.left * (impulseAngle.y * 0.01f * Time.deltaTime));
        }
    }

    void Update()
    {
       MoveShip();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public Transform theSun;
    public Transform earth;
    public Transform mars;
    
    public Transform sunRotatePoint;
    public Transform earthRotatePoint;
    public Transform marsRotatePoint;
    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theSun.Rotate(0,20*Time.deltaTime,0);
        mars.Rotate(0, 8*Time.deltaTime,0);
        earth.Rotate(0, 12*Time.deltaTime,0);
        
        sunRotatePoint.RotateAround(theSun.position, new Vector3(0,1,0), speed * Time.deltaTime);
        earthRotatePoint.RotateAround(earth.position, new Vector3(0,1,0), speed * Time.deltaTime);
        marsRotatePoint.RotateAround(mars.position, new Vector3(0,1,0), speed * Time.deltaTime);
    }
}

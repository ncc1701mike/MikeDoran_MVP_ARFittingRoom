using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooController : MonoBehaviour
{
   // public GameObject mannequin;
    public GameObject voodooMannequin;
    private float _rotate;

    private void Start()
    {
        
    }

    private void Update()
    {
        //var yRotation = voodooMannequin.transform.rotation.eulerAngles.y;
        //mannequin.transform.Rotate(0, 0,yRotation);
       
         transform.rotation = voodooMannequin.transform.rotation;
    }
    
}

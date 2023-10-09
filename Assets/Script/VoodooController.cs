using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooController : MonoBehaviour
{
   // public GameObject mannequin;
    public GameObject voodooMannequin;
    private Quaternion _previousRotation;
    private AudioSource _audioSource;

private void Start()
    {
        _previousRotation = transform.rotation;
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
         transform.rotation = voodooMannequin.transform.rotation;

         if (_previousRotation != voodooMannequin.transform.rotation)
         {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
         }
         else
         {  
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
         }

            _previousRotation = voodooMannequin.transform.rotation;
    }
    
}

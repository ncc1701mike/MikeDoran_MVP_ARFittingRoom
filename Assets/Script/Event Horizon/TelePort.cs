using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TelePort : MonoBehaviour
{
    public Transform theSun;
    public Transform theEarth;
    public Transform theMars;
    
    public Transform sunRotatePoint;
    public Transform earthRotatePoint;
    public Transform marsRotatePoint;
    public float speed = 10f;
    
    [SerializeField] private Transform cubeShip;
    [SerializeField] private ParticleSystem hyperDrive;
    [SerializeField] private GameObject xrRig;
    
    public AudioSource spokenAudio;
    public AudioSource backgroundAudio;
    public AudioSource soundEffects;
    public AudioClip intro, hyperdrive, arrival, earth, mars, sol;
    public AudioClip marsSounds, sunSounds, earthSounds;

    private void Awake()
    {
        //xrRig.transform.parent = gameObject.transform.parent;
    }

    void Start()
    {
        StartCoroutine(StartAdvemture());
    }

    IEnumerator StartAdvemture()
    {
        yield return new WaitForSeconds (2);
        backgroundAudio.Play();
        spokenAudio.PlayOneShot(intro);
    }

    public void HyperDriveMars()
    {
        StartCoroutine(Teleporter());
    }
    IEnumerator Teleporter()
    {
        spokenAudio.PlayOneShot(hyperdrive);
        soundEffects.PlayDelayed(2.8f);

        yield return new WaitForSeconds(4.5f);
            hyperDrive.Play();

        yield return new WaitForSeconds(3);
            hyperDrive.Stop();

        yield return new WaitForSeconds(1.2f);
        cubeShip.position += marsRotatePoint.position;
        cubeShip.Rotate(0,150,0); 
        spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
            spokenAudio.PlayOneShot(mars);
            soundEffects.PlayOneShot(marsSounds, 0.2f);
            yield return new WaitForSeconds(40f);
            soundEffects.Stop();

            StopCoroutine(Teleporter());
    }
    
    public void HyperDriveSol()
    {
        StartCoroutine(Teleporter1());
    }
    IEnumerator Teleporter1()
    { 
        spokenAudio.PlayOneShot(hyperdrive);
        soundEffects.PlayDelayed(2.8f);

        yield return new WaitForSeconds(4.5f);
        hyperDrive.Play();

        yield return new WaitForSeconds(3);
        hyperDrive.Stop();

        yield return new WaitForSeconds(1.2f);
        cubeShip.position += sunRotatePoint.position;
        cubeShip.Rotate(0,-105,0); 
       // cubeShip.LookAt(theSun);
        spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
        spokenAudio.PlayOneShot(sol);
        soundEffects.PlayOneShot(sunSounds, 0.05f);
        
        yield return new WaitForSeconds(60f);
        soundEffects.Stop();

        StopCoroutine(Teleporter1());
    }
    
    public void HyperDriveEarth()
    {
        StartCoroutine(Teleporter2());
    }
    IEnumerator Teleporter2()
    {
        spokenAudio.PlayOneShot(hyperdrive);
        soundEffects.PlayDelayed(2.8f);

        yield return new WaitForSeconds(4.5f);
        hyperDrive.Play();

        yield return new WaitForSeconds(3);
        hyperDrive.Stop();

        yield return new WaitForSeconds(1.2f);
        cubeShip.position += earthRotatePoint.position;
        cubeShip.Rotate(0, 85, 0);
        //cubeShip.LookAt(theEarth);
        spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
        spokenAudio.PlayOneShot(earth);
        soundEffects.PlayOneShot(earthSounds, 0.1f);
        
        yield return new WaitForSeconds(55f);
        soundEffects.Stop();

        StopCoroutine(Teleporter2());
    }
    
    void Update()
    {
        //xrRig.transform.parent = gameObject.transform.parent;
        
        theSun.Rotate(0,10*Time.deltaTime,0);
        theMars.Rotate(0, 8*Time.deltaTime,0);
        theEarth.Rotate(0, 12*Time.deltaTime,0);
        
       // sunRotatePoint.RotateAround(theSun.position, new Vector3(0,1,0), speed * Time.deltaTime);
       // earthRotatePoint.RotateAround(theEarth.position, new Vector3(0,1,0), speed * Time.deltaTime);
       // marsRotatePoint.RotateAround(theMars.position, new Vector3(0,1,0), speed * Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TelePort : MonoBehaviour
{
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
        xrRig.transform.parent = gameObject.transform.parent;
    }

    void Start()
    {
        StartCoroutine(StartAdvemture());
    }

    IEnumerator StartAdvemture()
    {
        yield return new WaitForSeconds(6);
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
            Teleport();
            spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
            spokenAudio.PlayOneShot(mars);
            soundEffects.PlayOneShot(marsSounds, 0.2f);

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
        Teleport();
        spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
        spokenAudio.PlayOneShot(sol);
        soundEffects.PlayOneShot(sunSounds, 0.2f);

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
        Teleport();
        spokenAudio.PlayOneShot(arrival);

        yield return new WaitForSeconds(3f);
        spokenAudio.PlayOneShot(earth);
        soundEffects.PlayOneShot(earthSounds, 0.2f);

        StopCoroutine(Teleporter2());
    }
    
    private void Teleport()
    {
        cubeShip.position += Vector3.one;
    }
}

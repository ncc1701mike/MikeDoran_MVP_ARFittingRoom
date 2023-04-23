using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    public string headsetMic;
    public AudioSource audioSource;
    public int sampleRate = 44100;
    void Start()
    {
        GetMic();
        StartRecording();
    }

    private void GetMic()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            if (headsetMic == null)
            {
                headsetMic = device;
            }
        }
    }

    private void StartRecording()
    {
        //audioSource.Stop();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(headsetMic, true, 10, sampleRate);
        audioSource.loop = true;

        if (Microphone.IsRecording(headsetMic))
        {
            while (!(Microphone.GetPosition(headsetMic) > 0))
            {
            }

            Debug.Log("Recording started: " + headsetMic);
            audioSource.Play();
        }
        else
        {
            Debug.Log("Recording failed: " + headsetMic);
        }
    }

    private void EndRecording()
    {
        audioSource = GetComponent<AudioSource>();
       // audioSource.clip = Microphone.End();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

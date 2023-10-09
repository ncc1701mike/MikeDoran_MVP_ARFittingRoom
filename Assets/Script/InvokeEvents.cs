using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _executeEvents = new UnityEvent();
    public UnityEvent ExecuteEvents => _executeEvents;
    public ParticleSystem glitterParticleSystem;
    //private bool atEventsInvoked = false;

    public void EventsExecuted()
    {
        /*if (!atEventsInvoked) 
        {
        glitterParticleSystem.Play();
        _executeEvents.Invoke();
        atEventsInvoked = true;
        }
        else
        {
        glitterParticleSystem.Play();
        atEventsInvoked = true;
        }*/

        glitterParticleSystem.Play();
        Debug.Log(glitterParticleSystem.isPlaying);
        _executeEvents.Invoke();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


/// <summary>
/// Attach this script to an image or object target to perform a behavior
/// (a sound, or animation, for example) when the object begins tracking
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class DoStuffOnTracking : MonoBehaviour, ITrackableEventHandler {

    //reference to the vuforia "TrackableBehaviour" script thats on every vuforia trackable image/object
    public TrackableBehaviour trackableBehaviour;

    //for the demo, we're going to play an audio clip when the object begins tracking
    public AudioClip OnAppearClip;

    //to play an audio clip, we need an audio source
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start() {
        _audioSource = GetComponent<AudioSource>();
        
        //we need to register our events with the trackable behaviour script.
        //events are messages that broadcasted when something happens, in this 
        //case, when the image appears or disappears.  By default, vuforia calls
        //OnTrackableStateChanged whenever the state changes
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    //This is what we're interested in - this method is called when we start, or stop, tracking
    //our 
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {

        if (newStatus == TrackableBehaviour.Status.DETECTED ||

            newStatus == TrackableBehaviour.Status.TRACKED ||

            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {

            _audioSource.clip = OnAppearClip;
            _audioSource.Play();
        }
        
    }
    
}

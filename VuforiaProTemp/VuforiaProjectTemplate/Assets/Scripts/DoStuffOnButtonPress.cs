using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(VirtualButtonBehaviour))]
public class DoStuffOnButtonPress : MonoBehaviour, IVirtualButtonEventHandler {

    public AudioSource audioSourceToPlay;

    public AudioClip onButtonPressedClip;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        Debug.Log("button pressed");
        audioSourceToPlay.clip = onButtonPressedClip;
        audioSourceToPlay.Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        Debug.Log("button released");
    }
}

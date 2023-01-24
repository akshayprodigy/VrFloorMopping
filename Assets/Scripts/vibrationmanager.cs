using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrationmanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TriggerVibration(AudioClip vibrationaudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationaudio);

        if (controller==OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }

        else if (controller==OVRInput.Controller.RTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
    }
}

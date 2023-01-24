using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snaptoLocation : MonoBehaviour
{


    bool grabbed;
    bool insidesnapzone;
    public bool snapped;
    public GameObject Rocketpart;
    public GameObject snaprotationreference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Rocketpart.name)
        {
            insidesnapzone = true;

          
        }
    }
	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.name == Rocketpart.name)
        {
            insidesnapzone = false;
        }
    }

    void snapObject()
    {
        if (grabbed == false && insidesnapzone == true) 
        {
            Rocketpart.gameObject.transform.position = this.gameObject.transform.position;
            Rocketpart.gameObject.transform.rotation = snaprotationreference.transform.rotation;
        }
    }


	private void Update()
	{
        grabbed = Rocketpart.GetComponent<OVRGrabbable>().isGrabbed;
        snapObject();
	}
}

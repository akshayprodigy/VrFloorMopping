using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapObject : MonoBehaviour
{
	public GameObject snaplocation;
	public GameObject rocket;
	public bool issnapped;
	public bool objectsnapped;
	public bool grabbed;

	private void Update()
	{
		grabbed = GetComponent<OVRGrabbable>().isGrabbed;
		objectsnapped = snaplocation.GetComponent<snaptoLocation>().snapped;
		if (objectsnapped == true) 
		{
			GetComponent<Rigidbody>().isKinematic = true;
			transform.SetParent(rocket.transform);
			issnapped = true;
		}

		if (objectsnapped == false && grabbed == false) 
		{
			GetComponent<Rigidbody>().isKinematic = false;
		}

	}

}

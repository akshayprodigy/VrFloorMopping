using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passthraycast : MonoBehaviour
{

    public GameObject[] handRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag.Equals("onlymachine"))
            {
                print("Rayishitting");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                handRay[0].SetActive(false);
                handRay[1].SetActive(false);
            }

          
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            handRay[0].SetActive(true);
            handRay[1].SetActive(true);
        }
    }
}

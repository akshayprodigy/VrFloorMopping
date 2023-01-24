using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuarrowicon : MonoBehaviour
{

    public GameObject arrowobject;
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
            if (hit.collider.gameObject.tag.Equals("mainmenu"))
            {
                print("Rayishitting");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");


            }


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private bool hasObject = false;
    private GameObject box;
    private float nextTimetoGrab;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && Time.time >= nextTimetoGrab)
        {
            nextTimetoGrab = Time.time + 1f / 2f;
            {
                if (hasObject)
                {
                    box.transform.parent = null;
                    box.GetComponent<Rigidbody>().useGravity = true;
                    hasObject = false;
                }
                else
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
                    {
                        if (hit.collider.tag == "Grabbable")
                        {
                            box = hit.collider.gameObject;
                            box.AddComponent<BoxRigidbody>();
                    
                            box.transform.parent = transform;

                            hasObject = true;
                        }



                    }

                }


            }
        }

    }
}

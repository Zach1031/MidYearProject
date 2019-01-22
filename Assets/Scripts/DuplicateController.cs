using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateController : MonoBehaviour
{
    public bool dupliacted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable" && (!dupliacted))
        {

            other.transform.parent = null;
            GameObject newBox = Instantiate(other.gameObject);
            newBox.GetComponent<Rigidbody>().useGravity = true;
            dupliacted = true;
        }
    }


        



    }


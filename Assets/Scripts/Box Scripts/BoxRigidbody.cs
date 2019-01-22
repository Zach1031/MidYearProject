using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRigidbody : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTransformParentChanged() 
    {
    
        GetComponent<Rigidbody>().useGravity = false;
      

    }

    private void OnBeforeTransformParentChanged()
    {

    }






}

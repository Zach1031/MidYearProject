using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    public GameObject otherButton;
    public bool permanent;
    public bool trigggered;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {

                var pos = transform.position;
                pos.y -= .25f;
                transform.position = pos;

                var cubePosition = collision.transform.position;
                cubePosition.y -= .25f;
                collision.transform.position = cubePosition;

            if (((otherButton == null) || otherButton.GetComponent<ButtonController>().trigggered))
            {
                var doorPosition = door.transform.position;
                doorPosition.x += 3;
                door.transform.position = doorPosition;

            }
            trigggered = true;




        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable" && !(permanent))
        {
            var pos = transform.position;
            pos.y += .25f;
            transform.position = pos;

            if (((otherButton == null) || otherButton.GetComponent<ButtonController>().trigggered))
            {
                var doorPosition = door.transform.position;
                doorPosition.x -= 3;
                door.transform.position = doorPosition;
            }
          



            trigggered = false;


        }
    }
}
    

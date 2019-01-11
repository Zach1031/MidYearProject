using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour

{
    private bool inAir = false;
    private HingeJoint grabHinge;
    private Rigidbody rb;
    private readonly int speed = 25;
    void GrapplingShot()
    {
        rb.velocity = new Vector3(1, 1, 1) * speed;
        inAir = true;
    }
    private void OnCollisionEnter(Collision col)
    {
        if(inAir)
        {
            rb.velocity = new Vector3(0,0,0);
            inAir = false;
            grabHinge = gameObject.AddComponent<HingeJoint>();
            grabHinge.connectedBody = col.rigidbody;

        }
    }
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKey(KeyCode.E))
            {
                GrapplingShot();
            }
            OnCollisionEnter();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject portal;
    public GameObject portal_a;
    public GameObject portal_orign;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            portal.GetComponent<Transform>().position = portal_orign.GetComponent<Transform>().position;
            portal.AddComponent<ConstantForce>();
            portal.GetComponent<ConstantForce>().force = new Vector3(0, 0, 25);
            portal.AddComponent<GunController>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Portal")
        {
            transform.position = portal_a.GetComponent<Transform>().position;


        }
    }
        
}

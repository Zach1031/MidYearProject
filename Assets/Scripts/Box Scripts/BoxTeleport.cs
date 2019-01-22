using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTeleport : MonoBehaviour
{


    private float cooldown = .001f;
    private float nextTimetoTeleport = 0f;
    private GameObject portal;
    private GameObject portal_a;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.FindWithTag("Portal") != null)
        //{
        //    portal = GameObject.FindWithTag("Portal");
        //}

        //if (GameObject.FindWithTag("Portal_a") != null)
        //{
        //    portal_a = GameObject.FindWithTag("Portal_a");
        //}

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Portal" && Time.time >= nextTimetoTeleport)
        {

            nextTimetoTeleport = Time.time + 1f / cooldown;
            transform.position = portal_a.GetComponent<Transform>().position;


        }
        else if (collision.gameObject.tag ==  "Portal_a" && Time.time >= nextTimetoTeleport)
        {
            nextTimetoTeleport = Time.time + 1f / cooldown;
            transform.position = portal.GetComponent<Transform>().position;
        }
    }
}

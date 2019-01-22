using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject portal;
    private Material portal_color;
    public GameObject portal_a;
    private Material portal_a_color;
    private Material white;
    private float nextTimetoTeleport;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag != "Not-Portal" && hit.collider.tag != "Grabbable")
                {
                    if (portal != null)
                    {
                        portal.GetComponent<Renderer>().material = white;
                        
                    }

                    portal = hit.collider.gameObject;
                
                    portal.GetComponent<Renderer>().material = portal_color;

                }



            }

        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag != "Not-Portal" && hit.collider.tag != "Grabbable")
                {
                    if (portal_a!= null)
                    {
                        portal_a.GetComponent<Renderer>().material = white;
    
                    }
                    portal_a = hit.collider.gameObject;
            
                    portal_a.GetComponent<Renderer>().material = portal_a_color;
                }

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == portal && Time.time >= nextTimetoTeleport)
        {

            nextTimetoTeleport = Time.time + 1f / 2f;
            transform.position = portal_a.GetComponent<Transform>().position;

            Abyss();

        }
        else if (collision.gameObject == portal_a && Time.time >= nextTimetoTeleport)
        {
            nextTimetoTeleport = Time.time + 1f / 2f;
            transform.position = portal.GetComponent<Transform>().position;

            Abyss();
        }
    }
    void Abyss()
    {

        RaycastHit hit;
        while(!(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)))
        {
            var playerRotation = transform.rotation;
            playerRotation.y += 1;
            transform.rotation = playerRotation;
        }
    }

}

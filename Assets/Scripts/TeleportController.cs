using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject portal;
    public Material portal_color;
    public GameObject portal_a;
    public Material portal_a_color;
    public Material white;
    public float cooldown = .001f;
    private float nextTimetoTeleport = 0f;
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
                if (hit.collider.tag != "Not-Portal")
                {
                    if (portal != null)
                    {
                        portal.GetComponent<Renderer>().material = white;
                    }

                    portal = hit.collider.gameObject;
                    hit.collider.GetComponent<Renderer>().material = portal_color;
                }



            }

        }
        else if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag != "Not-Portal")
                {
                    if (portal_a!= null)
                    {
                        portal_a.GetComponent<Renderer>().material = white;
                    }
                    portal_a = hit.collider.gameObject;
                    hit.collider.GetComponent<Renderer>().material = portal_a_color;
                }

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == portal && Time.time >= nextTimetoTeleport)
        {

            nextTimetoTeleport = Time.time + 1f / cooldown;
            transform.position = portal_a.GetComponent<Transform>().position;


        }
        else if (collision.gameObject == portal_a && Time.time >= nextTimetoTeleport)
        {
            nextTimetoTeleport = Time.time + 1f / cooldown;
            transform.position = portal.GetComponent<Transform>().position;
        }
    }
        
}

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
    public AudioClip clip;
    private float nextTimetoTeleport;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.collider.gameObject.tag != "OOB")
            {
                if (hit.collider.tag != "Not-Portal" && hit.collider.tag != "Grabbable")
                {
                    AudioSource.PlayClipAtPoint(clip, new Vector3(0, 1, 0), 2f);
                    if (portal != null)
                    {
                        portal.GetComponent<Renderer>().material = white;
                        

                    }

                    portal = hit.collider.gameObject;
                
                    portal.GetComponent<Renderer>().material = portal_color;
                    
                    

                }



            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.collider.gameObject.tag != "OOB")
            {
                if (hit.collider.tag != "Not-Portal" && hit.collider.tag != "Grabbable")
                {
                    AudioSource.PlayClipAtPoint(clip, new Vector3(0, 1, 0), 2f);
                    if (portal_a!= null)
                    {
                        portal_a.GetComponent<Renderer>().material = white;
    
                    }
                    portal_a = hit.collider.gameObject;
            
                    portal_a.GetComponent<Renderer>().material = portal_a_color;
                    AudioSource.PlayClipAtPoint(clip, new Vector3(0, 1, 0), 2f);
                }

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == portal && Time.time >= nextTimetoTeleport && portal_a != null)
        {

            nextTimetoTeleport = Time.time + 1f / 2f;
            transform.position = portal_a.GetComponent<Transform>().position;

            Abyss();

        }
        else if (collision.gameObject == portal_a && Time.time >= nextTimetoTeleport && portal != null)
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
            while(hit.collider.tag != "OOB")
            {
                var playerRotation = transform.rotation;
                playerRotation.y += 1;
                transform.rotation = playerRotation;
            }

            transform.rotation = new Quaternion(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z, 1);



        }
    }

}

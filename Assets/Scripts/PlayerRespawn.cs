using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

        public int maxYPosition = -50;
        private Vector3 initialPos;
        private Quaternion initialRotation;

        // Use this for initialization
        void Start()
        {
            initialPos = transform.position;
            initialRotation = transform.rotation;

        }


        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.P))
            {
                initialPos.Set(transform.position.x, .5f, transform.position.z);
            }

            if (transform.position.y <= maxYPosition)
            {
                transform.rotation = initialRotation;
                transform.position = initialPos;
            }

        }
}

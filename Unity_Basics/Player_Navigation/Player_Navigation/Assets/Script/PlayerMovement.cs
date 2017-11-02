using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    public float maxSpeed;
    public float speed = 20.0f;

    private Rigidbody rig;
    private Vector3[] directionsForKeys;
    private KeyCode[] inputKeys;

    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        for(int i =0; i < inputKeys.Length; i++)
        {
            var keys = inputKeys[i];

            if (Input.GetKey(keys))
            {
                Vector3 movement = directionsForKeys[i] * speed * Time.deltaTime;
                MovePlayer(movement);
            }
        }
    }

    void MovePlayer(Vector3 movement)
    {
        if (rig.velocity.magnitude * speed > maxSpeed)
        {
            rig.AddForce(movement * (-1));
        }
        else
        {
            rig.AddForce(movement);
        }
    }


}

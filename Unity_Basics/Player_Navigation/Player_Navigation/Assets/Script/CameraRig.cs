using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public float moveSpeed;
    public GameObject target;

    private Transform rigTransform;
    void Start()
    {
        rigTransform = this.transform.parent;
    }

    void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }

        rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}

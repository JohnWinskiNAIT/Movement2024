using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    Rigidbody rbody;
    float distance;
    float antigravForce;
    RaycastHit hit;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        distance = 5.0f;
    }
    void FixedUpdate()
    {
        antigravForce = rbody.mass;
        //if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        if (Physics.BoxCast(transform.position, new Vector3(1.5f,0.4f,2.5f), Vector3.down, out hit, Quaternion.identity, distance))
        {
            rbody.AddForce(transform.up * (distance - hit.distance) / distance *
            antigravForce, ForceMode.Impulse);
        }
    }
}

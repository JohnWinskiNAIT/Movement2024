using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Pool : MonoBehaviour
{
    [SerializeField] Rigidbody rbody;

    float distance = 3.5f;
    float antigravForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (rbody != null)
        {
            antigravForce = rbody.mass;
            rbody.AddForce(transform.up * (distance - transform.position.y) / distance * antigravForce, ForceMode.Impulse);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        rbody = other.GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        rbody = null;
    }
}

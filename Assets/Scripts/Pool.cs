using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Pool : MonoBehaviour
{
    [SerializeField] List<Rigidbody> rbody;

    float distance = 6f;
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
        foreach (Rigidbody r in rbody)
        {
            antigravForce = r.mass;
            r.AddForce(transform.up * (distance - (r.gameObject.transform.position.y - transform.position.y)) / distance * antigravForce, ForceMode.Impulse);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        rbody.Add(other.GetComponentInParent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        rbody.Remove(other.GetComponentInParent<Rigidbody>());
    }
}

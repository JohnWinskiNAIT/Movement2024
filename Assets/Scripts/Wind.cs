using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] List<Rigidbody> rbody;

    [SerializeField] float distance = 5f;
    [SerializeField] float forceAmount = 80.0f;

    void FixedUpdate()
    {
        foreach (Rigidbody r in rbody)
        {
            r.AddForce(transform.forward * Time.fixedDeltaTime * forceAmount, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody currentRbody = other.GetComponentInParent<Rigidbody>();

        if (currentRbody != null)
        {
            if (!rbody.Contains(currentRbody))
            {
                rbody.Add(currentRbody);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rbody.Remove(other.GetComponentInParent<Rigidbody>());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    Rigidbody rbody;

    [SerializeField] float forceAmount = 100.0f;    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbody.AddForceAtPosition(transform.up * Time.fixedDeltaTime * forceAmount, transform.position, ForceMode.Impulse);
    }
}

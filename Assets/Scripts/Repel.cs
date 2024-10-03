using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    [SerializeField] Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        rbody = collision.gameObject.GetComponentInParent<Rigidbody>();

        if (rbody != null)
        {
            //rbody.AddRelativeForce(collision.gameObject.transform.position - transform.position * 1.0f, ForceMode.Impulse);
            rbody.AddRelativeForce(Vector3.up * 100.0f, ForceMode.Impulse);
        }
    }
}

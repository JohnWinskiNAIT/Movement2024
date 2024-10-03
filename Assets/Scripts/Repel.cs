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
        float radius = 10.0F;
        float power =  300.0F;
        Vector3 explosionPos = transform.position;
        rbody = collision.gameObject.GetComponentInParent<Rigidbody>();

        if (rbody != null)
        {
            //rbody.AddRelativeForce(collision.gameObject.transform.position - transform.position * 1.0f, ForceMode.Impulse);
            //rbody.AddForce(Vector3.up * 30.0f, ForceMode.Impulse);
            //rbody.AddExplosionForce(300.0f, transform.position, 100.0f, 3.0f);

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponentInParent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }
    }
}

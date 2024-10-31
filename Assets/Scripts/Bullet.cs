using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health objectHealth;

        objectHealth = collision.gameObject.GetComponent<Health>();

        if (objectHealth != null) 
        {
            objectHealth.ApplyDamage(damage);
        }

        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

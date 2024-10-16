using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroySelf();
    }

    void DestroySelf()
    {
        //Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] int ammo = 10, maxAmmo = 10;

    [SerializeField] float fireRate = 0.5f, timeStamp = -0.5f, fireForce = 20.0f;

    [SerializeField] GameObject bullet, barrelEnd;

    [SerializeField] Material[] myMaterial;

    int index;

    void Fire()
    {
        if (ammo > 0 && Time.time > timeStamp + fireRate)
        {
            ammo--;

            timeStamp = Time.time;

            GameObject instantiatedObject = Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);

            Physics.IgnoreCollision(instantiatedObject.GetComponentInChildren<Collider>(), gameObject.GetComponentInChildren<Collider>());
            instantiatedObject.GetComponent<Rigidbody>().velocity = barrelEnd.transform.forward * fireForce;

            instantiatedObject.GetComponentInChildren<Renderer>().material = myMaterial[index];
            index++;
            if (index >= myMaterial.Length)
            {
                index = 0;
            }
        }
    }

    void Reload()
    {
        ammo = maxAmmo;
    }
}

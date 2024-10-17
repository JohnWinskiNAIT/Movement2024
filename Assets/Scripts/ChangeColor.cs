using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Material[] myMaterials;

    int index;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInChildren<Renderer>().material = gameObject.GetComponentInChildren<Renderer>().material;
        index++;
        if (index == myMaterials.Length)
        {
            index = 0;
        }
    }
}

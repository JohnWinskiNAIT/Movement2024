using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyEvents.Deactivate.AddListener(GoAway);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoAway()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDestruction : MonoBehaviour
{
    public float lifespan = 2.0f;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject && other.tag != "Item")
        {
            Destroy(this.gameObject);
        }
    }
}

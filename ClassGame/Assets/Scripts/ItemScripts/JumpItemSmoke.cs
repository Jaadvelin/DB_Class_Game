using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItemSmoke : MonoBehaviour
{
    public GameObject pickupEffect;

    public void Pickup3()
    {
        GameObject newpickupEffect3 = (GameObject)Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(newpickupEffect3, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

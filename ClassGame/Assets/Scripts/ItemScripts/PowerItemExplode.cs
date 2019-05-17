using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItemExplode : MonoBehaviour
{
    public GameObject pickupEffect;

    public void Pickup()
    {
        GameObject newpickupEffect = (GameObject)Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(newpickupEffect, 1);
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

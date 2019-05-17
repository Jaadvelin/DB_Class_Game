using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemSmoke : MonoBehaviour
{
    public GameObject pickupEffect;

    public void Pickup2()
    {
        GameObject newpickupEffect2 = (GameObject)Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(newpickupEffect2, 1);
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

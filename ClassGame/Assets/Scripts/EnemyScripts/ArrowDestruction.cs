﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestruction : MonoBehaviour
{
    private GameObject player;
    public float lifeSpan = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Destroy(this.gameObject);
        }
    }
}

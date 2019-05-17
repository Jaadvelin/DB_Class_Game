﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject == player)
        {
            playerHealth.enabled = true;
            playerHealth.Killerbox();
        }
    }

    
}

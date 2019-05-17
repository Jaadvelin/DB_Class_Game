using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Health : MonoBehaviour
{

    [SerializeField] private int startingHealth = 10;
    [SerializeField] private int currentHealth;

    private Rigidbody rigidbody;
    private SphereCollider sphereCollider;
    private AudioSource audio;
    public AudioClip killAudioz;
    public GameObject explosionEffect;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.GameOver)
        {
            if (other.tag == "PlayerWeapon")
            {
                audio.PlayOneShot(killAudioz);
                TakeHit();
            }
        }
    }

    void TakeHit()
    {
        if (currentHealth > 0)
        {
            GameObject newexplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(newexplosionEffect, 1);
            currentHealth -= 10;
            
        }
        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        renderer.enabled = false;
        sphereCollider.enabled = false;
        Connection.EnemyDeathUpdater(3);
        new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}

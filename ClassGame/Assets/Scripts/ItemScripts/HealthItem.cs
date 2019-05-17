using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;

    private HealthItemSmoke healthItemSmoke;
    private SphereCollider sphereCollider;
    public float speed = 100f;
    public GameObject pickupEffect2;
    private PotionsManager potionsManager;


    void Pickup2()
    {
        Instantiate(pickupEffect2, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        healthItemSmoke = GetComponent<HealthItemSmoke>();
        sphereCollider = GetComponent<SphereCollider>();
        potionsManager = FindObjectOfType<PotionsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
             PickPotion();
             healthItemSmoke.Pickup2();
             sphereCollider.enabled = false;
             potionsManager.GivePotion();
             Destroy(gameObject);
        }
    }

    void PickPotion()
    {

    }
    
        /* void OnTriggerEnter(Collider other)
         {
             if(other.gameObject == player)
             {
                 StartCoroutine(HealingRoutine());


             }
         }

         public IEnumerator HealingRoutine()
         {
             healthItemSmoke.Pickup2();
             sphereCollider.enabled = false;
             playerHealth.PowerUpHealth();
             yield return new WaitForSeconds(0f);

             Destroy(gameObject);
         }*/
    }

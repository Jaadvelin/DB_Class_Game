using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    private GameObject player;
    private LifeManager lifeManager;

    private SpriteRenderer spriteRenderer;

    private PowerItemExplode powerItemExplode;
    private SphereCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        lifeManager = FindObjectOfType<LifeManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        powerItemExplode = GetComponent<PowerItemExplode>();
        boxCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            PickLife();
        }
    }

    public void PickLife()
    {
        lifeManager.GiveLife();
        powerItemExplode.Pickup();
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        Destroy(gameObject);
    }
}

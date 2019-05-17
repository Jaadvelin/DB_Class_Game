using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cave01Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private float timeSinceLastHit = 0.02f;
    [SerializeField] private float dissapearSpeed = 2f;
    [SerializeField] private int currentHealth;

    private float timer = 0f;
    private Animator anim;
    private bool isAlive;
    private Rigidbody rigidbody;
    private BoxCollider boxCollider;
    private bool dissapearEnemy = false;
    private AudioSource audio;
    public AudioClip cavehurtaudio;
    public AudioClip cavekillaudio;
    private DropItems dropItem;
    public GameObject explosionEffect;

    public bool IsAlive
    {
        get { return isAlive; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        isAlive = true;
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
        dropItem = GetComponent<DropItems>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            GameObject newexplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(newexplosionEffect, 1);

            anim.SetTrigger("Hurt");
            currentHealth -= 10;
            audio.PlayOneShot(cavehurtaudio);
        }

        if (currentHealth <= 0)
        {
            Connection.BossDeathUpdater(4, DateTime.Now);
            isAlive = false;
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        boxCollider.enabled = false;
        anim.SetTrigger("EnemyDie");
        rigidbody.isKinematic = true;
        audio.PlayOneShot(cavekillaudio);

        StartCoroutine(removeEnemy());
        dropItem.Drop();
    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

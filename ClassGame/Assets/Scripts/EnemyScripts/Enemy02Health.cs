using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Health : MonoBehaviour
{

    [SerializeField] private int startingHealth = 20;
    [SerializeField] private float timeSinceLastHit = 0.5f;
    [SerializeField] private float dissapearSpeed = 2f;
    [SerializeField] private int currentHealth;

    private float timer = 0f;
    private Animator anim;
    private bool isAlive;
    private Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private bool dissapearEnemy = false;

    private AudioSource audio;
    public AudioClip hurtAudio;
    public AudioClip killAudio;

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        isAlive = true; 
        currentHealth = startingHealth;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (dissapearEnemy)
        {
            transform.Translate(-Vector3.up * dissapearSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "PlayerWeapon")
            {
                TakeHit();
                timer = 0f;
            }
        }
    }

    void TakeHit()
    {
        if(currentHealth>0)
        {
            anim.Play("EnemyHurt");
            currentHealth -= 10;

            if (currentHealth > 0)
            {
                audio.PlayOneShot(hurtAudio);
            }
        }
        if(currentHealth<=0)
        {
            isAlive = false;
            audio.PlayOneShot(killAudio);
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        capsuleCollider.enabled = false;
        anim.SetTrigger("isDead");
        rigidbody.isKinematic = true;
        Connection.EnemyDeathUpdater(2);
        StartCoroutine(removeEnemy());
        
    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(2f);
        dissapearEnemy = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private float timeBetweenAttacks = 1f;

    private Animator anim;
    private GameObject player;
    private bool playerInRange;

    public float arrowSpeed = 600.0f;
    public Transform arrowSpawn;
    public Rigidbody arrowPrefab;

    private Enemy02Health enemy02Health;
    private PlayerHealth playerHealth;

    private AudioSource audio;
    public AudioClip attackAudio;

    Rigidbody clone;


    // Start is called before the first frame update
    void Start()
    {
        this.arrowSpawn = GameObject.Find("ArrowSpawn").transform;
        this.anim = GetComponent<Animator>();
        this.player = GameManager.instance.Player;
        this.enemy02Health = GetComponent<Enemy02Health>();
        playerHealth = player.GetComponent<PlayerHealth>();
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance (transform.position, player.transform.position) < range && enemy02Health.IsAlive && !GameManager.instance.GameOver && playerHealth.CurrentHealth > 0)
        {

            playerInRange = true;
            anim.SetBool("isAttacking",true);
            
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > range && enemy02Health.IsAlive)
        {
            playerInRange = false;
            anim.SetTrigger("isIdle");
            anim.SetBool("isAttacking",false);
        }
    }

    public void FireProyectile()
    {
        clone = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        audio.PlayOneShot(attackAudio);
    }

}

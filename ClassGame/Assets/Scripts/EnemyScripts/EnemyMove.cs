using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    private Enemy01Health enemy01Health;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        Assert.IsNotNull(player);    
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        enemy01Health = GetComponent<Enemy01Health>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(player.position,this.transform.position) < 6 && playerHealth.CurrentHealth > 0)
        {
            if (!GameManager.instance.GameOver && enemy01Health.IsAlive )
            {
                nav.SetDestination(player.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                nav.isStopped = false;
                //anim.SetBool("isAttacking", false);
            }
        }
        if (Vector3.Distance(player.position, this.transform.position) > 6 || playerHealth.CurrentHealth <= 0)
        {
            if (!GameManager.instance.GameOver && enemy01Health.IsAlive)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);
                nav.isStopped = true;
            }
        }
        if (GameManager.instance.GameOver)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            nav.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class ArcherFlip : MonoBehaviour
{
    [SerializeField] Transform player;
    private Enemy02Health enemy02Health;
    new Rigidbody rigidbody;
    public bool facingLeft = true;
    public float position, position2;


    /*private void Awake()
    {
        Assert.IsNotNull(player);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemy02Health = GetComponent<Enemy02Health>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < rigidbody.position.x && !facingLeft && enemy02Health.IsAlive)
        {
            transform.Rotate(Vector3.up, 180.0f, Space.World);
            facingLeft = true;
        }
        else if (player.position.x > rigidbody.position.x && facingLeft && enemy02Health.IsAlive)
        {
            transform.Rotate(Vector3.up, 180.0f, Space.World);
            facingLeft = false;
        }
    }
}

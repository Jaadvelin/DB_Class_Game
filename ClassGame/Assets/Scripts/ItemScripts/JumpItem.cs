/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour
{
    private GameObject player;
    private SphereCollider sphereCollider;
    public float speed = 100f;
    private CharacterMovement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        sphereCollider = GetComponent<SphereCollider>();
        characterMovement = GetComponent<CharacterMovement>();
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
            StartCoroutine(JumpingRoutine());
        }
    }

    public IEnumerator JumpingRoutine()
    {
        sphereCollider.enabled = false;
        
        characterMovement.PowerUpJump();
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour
{
    private GameObject player;
    private CharacterMovement characterMovement;

    private MeshRenderer meshRenderer;
    private Renderer renderer;

    private JumpItemSmoke jumpItemSmoke;
    private SphereCollider sphereCollider;
    public float speed = 100f;

    public GameObject pickupEffect3;

    private AudioSource audio;
    public AudioClip activateAudio2;
    public AudioClip deactivateAudio2;

    void Pickup3()
    {
        Instantiate(pickupEffect3, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        characterMovement = player.GetComponent<CharacterMovement>();

        meshRenderer = GetComponentInChildren<MeshRenderer>();
        renderer = GetComponent<Renderer>();

        jumpItemSmoke = GetComponent<JumpItemSmoke>();
        sphereCollider = GetComponent<SphereCollider>();

        audio = GetComponent<AudioSource>();
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

            StartCoroutine(JumpingRoutine());
        }
    }

    public IEnumerator JumpingRoutine()
    {
        jumpItemSmoke.Pickup3();

        renderer.enabled = false;
        sphereCollider.enabled = false;
        audio.PlayOneShot(activateAudio2);
        characterMovement.jumpSpeed = 1200f;

        yield return new WaitForSeconds(9f);
        audio.PlayOneShot(deactivateAudio2);
        yield return new WaitForSeconds(1f);
        characterMovement.jumpSpeed = 600f;
        renderer.enabled = true;
        sphereCollider.enabled = true;
    }
}

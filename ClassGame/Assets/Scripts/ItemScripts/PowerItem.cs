using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    private InviManager inviManager;

    private ParticleSystem particleSystem;

    private MeshRenderer meshRenderer;
    private Renderer renderer;
    private ParticleSystem powerParticles;

    private PowerItemExplode powerItemExplode;
    private SphereCollider sphereCollider;
    public float speed = 100f;

    public GameObject pickupEffect;
     
    private AudioSource audio;
    public AudioClip activateAudio;
    public AudioClip deactivateAudio;
    public AudioClip explosionAudio;

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.enabled = true;

        particleSystem = player.GetComponent<ParticleSystem>();
        particleSystem.enableEmission = false;

        meshRenderer = GetComponentInChildren<MeshRenderer>();
        renderer = GetComponent<Renderer>();
        powerParticles = GetComponent<ParticleSystem>();

        powerItemExplode = GetComponent<PowerItemExplode>();
        sphereCollider = GetComponent<SphereCollider>();

        audio = GetComponent<AudioSource>();
        inviManager = FindObjectOfType<InviManager>();
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
            inviManager.GiveInvi();
            renderer.enabled = false;
             meshRenderer.enabled = false;
        }
    }

    public void UseInvis()
    {
       StartCoroutine(InvincibleRoutine());
    }

    public IEnumerator InvincibleRoutine()
    {
        powerItemExplode.Pickup();
        
       
        audio.PlayOneShot(activateAudio);
        audio.PlayOneShot(explosionAudio);
        particleSystem.enableEmission = true;
        playerHealth.enabled = false;
        powerParticles.enableEmission = false;
        sphereCollider.enabled = false;
        
        yield return new WaitForSeconds(9f);
        audio.PlayOneShot(deactivateAudio);
        yield return new WaitForSeconds(1f);
        particleSystem.enableEmission = false;
        playerHealth.enabled = true;
        
        Destroy(gameObject);
    }
}

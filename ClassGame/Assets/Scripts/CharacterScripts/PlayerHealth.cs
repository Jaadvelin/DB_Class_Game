using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] Transform player;
    [SerializeField] int startingHealth;


    [SerializeField] float timeSinceLastHit = 0f;
    [SerializeField] Slider healthSlider;
    [SerializeField] private int currentHealth;

    private CharacterMovement characterMovement;
    private float timer = 0f;
    public bool gamove = false;
    public bool isDead = false;
    private Animator anim;
    private AudioSource audio;
    public AudioClip hurtAudio;
    public AudioClip deathAudio;
    public AudioClip fallAudio;
    public AudioClip healthSound;

    public LevelManager levelManager;
    private PotionsManager potionsManager;

    public static int identifier;

    public int CurrentHealth
    {
        get {return currentHealth;}
        set
        {
            if (value < 0)
                currentHealth = 0;
            else
                currentHealth = value;
        }
    }

    public Slider HealthSlider
    {
        get { return healthSlider; }
    }


    void Awake()
    {
        Assert.IsNotNull(healthSlider);
    } 


    // Start is called before the first frame update
    void Start()
    {
        Connection.LoadPlayer();
        startingHealth = Connection.DBHP;



        anim = GetComponent <Animator>();
        currentHealth = startingHealth;
        characterMovement = GetComponent<CharacterMovement>();
        healthSlider.value = currentHealth;
        audio = GetComponent<AudioSource>();
        levelManager = FindObjectOfType <LevelManager>();
        isDead = false;
        potionsManager = FindObjectOfType<PotionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        PlayerKill();
        if (gamove)
        {
            GameOver();
        }

        if (Input.GetButtonDown("Q")) //potions
        {
            if (potionsManager.potionCounter > 0 && currentHealth <100 && currentHealth >0)
            {
                PowerUpHealth();
                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(timer >= timeSinceLastHit && !GameManager.instance.GameOver)
        {
            if(other.tag == "Weapon")
            {
                takeHit();
                timer = 0;
            }
        }
    }

    void takeHit()
    {
        if (currentHealth > 0)
        {
            GameManager.instance.PlayerHit(currentHealth);
            anim.Play("Hurt");
            currentHealth -= 10;
            Connection.PlayerHpUpdater(identifier, currentHealth);
            healthSlider.value = currentHealth;
            if (currentHealth > 0 )
            {
                audio.PlayOneShot(hurtAudio);
            }
            if(currentHealth <= 0)
            {
               
                audio.PlayOneShot(deathAudio);
                anim.SetBool("isDead", true);
            }
        }
    }

    public void PowerUpHealth()
    {
        if (currentHealth <= 80)
        {
            CurrentHealth += 20;
        }
        else if (currentHealth < startingHealth)
        {
            CurrentHealth = startingHealth;
        }
        healthSlider.value = currentHealth;
        audio.PlayOneShot(healthSound);
        potionsManager.TakePotion();
    }

    public void PlayerKill()
    {
        if (currentHealth <= 0)
        {
            characterMovement.enabled = false;
            healthSlider.value = currentHealth;
           
           // print("playerkill before respawn");
            levelManager.RespawnPlayer();
           // print("playerkill after respawn");
        }
    }

    public void Killerbox()
    {
        audio.PlayOneShot(fallAudio);
        CurrentHealth = 0;
        Connection.PlayerHpUpdater(identifier, currentHealth);
        healthSlider.value = currentHealth;
    }

    void GameOver()
    {
        if (!GameManager.instance.GameOver)
        {
            GameManager.instance.PlayerHit(currentHealth);
            characterMovement.enabled = false;
        }
    }
}

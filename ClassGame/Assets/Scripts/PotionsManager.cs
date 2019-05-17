using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PotionsManager : MonoBehaviour
{
    public int startingPotions;
    public int potionCounter;
    private Text potionText;
    private PlayerHealth playerHealth;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Connection.LoadPlayerItems();
        startingPotions = Connection.DBPotions;

        potionText = GetComponent<Text>();
       potionCounter = startingPotions;
      
        player = GameManager.instance.Player;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        potionText.text = "x " + potionCounter;
    }

    public void GivePotion()
    {
        potionCounter++;
        Connection.PlayerPotionUpdater(playerHealth.CurrentHealth, PlayerHealth.identifier, potionCounter,0);
    }   

    public void TakePotion()
    {
        potionCounter--;
        Connection.PlayerPotionUpdater(playerHealth.CurrentHealth, PlayerHealth.identifier, potionCounter,1);
    }
}

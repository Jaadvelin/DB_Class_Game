using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InviManager : MonoBehaviour
{
    public int startingInvi;
    public int inviCounter;
    private Text inviText;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Connection.LoadPlayerItems();
        startingInvi = Connection.DBInvi;
        inviText = GetComponent<Text>();
       inviCounter = startingInvi;
    }

    // Update is called once per frame
    void Update()
    {
        inviText.text = "x " + inviCounter;
        if (Input.GetButtonDown("W"))
        {
            if (inviCounter > 0)
            {
                TakeInvi();
            }
        }

    }

    public void GiveInvi()
    {
        inviCounter++;
    }

    public void TakeInvi()
    {
        inviCounter--;
        Connection.PlayerInviUpdater();
    }

 
}

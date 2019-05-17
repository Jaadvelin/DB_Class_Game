using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsText : MonoBehaviour
{
    private Text statsText;

    private GameObject player;
    public GameObject gameOverScreen;
    public float waitAfterGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Connection.EnemiesInfo();
        Connection.BossLastKillFunction(4);

        statsText = GetComponent<Text>();

        print(Connection.DBEnemies);
        statsText.text += "ID   Type    Killed  Description\n";
        for (int i = 0; i < 3; i++)
        {
            
            for (int j = 0; j < 4; j++)
            {

                statsText.text += string.Format("{0} ", Connection.DBEnemies[i, j]);
                
            }
            statsText.text += "\n";

        }

        statsText.text += "\n";
        statsText.text += "\n";

        statsText.text += "Last boss kill = "+Connection.Boslaskil;


        // Update is called once per frame
        void Update()
        {



        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    public void Jumpingbutton()
    {
        characterMovement.Jumping();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

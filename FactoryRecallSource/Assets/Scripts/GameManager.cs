using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public enum Character
    {
        Beep, Boop
    }

    public Character currentCharacter;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        gameObject.name = "GameManager";

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
       gameManager.currentCharacter = Character.Beep;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gameManager.currentCharacter == Character.Beep)
            {
                gameManager.currentCharacter = Character.Boop;
            }
            else if (gameManager.currentCharacter == Character.Boop)
            {
                gameManager.currentCharacter = Character.Beep;
            }
        }
    }
}

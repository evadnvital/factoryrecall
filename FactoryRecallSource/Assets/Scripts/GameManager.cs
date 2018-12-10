using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public bool LevelResolved { get; private set; }

    private bool blueCircuitResolved, greenCircuitResolved, puzzleActive;
    public bool BlueCircuitResolved
    {
        get
        {
            return blueCircuitResolved;
        }

        set
        {
            blueCircuitResolved = value;
            UpdateCircuits();
        }
    }
    public bool GreenCircuitResolved
    {
        get
        {
            return greenCircuitResolved;
        }

        set
        {
            greenCircuitResolved = value;
            UpdateCircuits();
        }
    }
    public bool PuzzleActive
    {
        get
        {
            return puzzleActive;
        }

        set
        {
            puzzleActive = value;
        }
    }

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
        puzzleActive = false;
        LevelResolved = false;
        blueCircuitResolved = false;
        greenCircuitResolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleActive)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (gameManager.currentCharacter == Character.Beep && BoopController.boopController.energy > 0)
                {
                    gameManager.currentCharacter = Character.Boop;
                }
                else if (gameManager.currentCharacter == Character.Boop)
                {
                    gameManager.currentCharacter = Character.Beep;
                }
            }
            if (blueCircuitResolved && greenCircuitResolved && BoopController.boopController.energy == 0)
            {
                StartCoroutine(BoopReset());
            }
        }
    }

    private void UpdateCircuits()
    {
        if (blueCircuitResolved && greenCircuitResolved) LevelResolved = true;
        else LevelResolved = false;
    }

    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ResetLevel();
        }
        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            ResetLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetLevel();
    }

    private void ResetLevel()
    {
        gameManager.currentCharacter = Character.Beep;
        puzzleActive = false;
        LevelResolved = false;
        blueCircuitResolved = false;
        greenCircuitResolved = false;
    }

    IEnumerator BoopReset()
    {
        yield return new WaitForSeconds(1.5f);
        if (BoopController.boopController.energy == 0)
            RestartLevel();
    }
}

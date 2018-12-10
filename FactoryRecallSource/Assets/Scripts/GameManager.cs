using System.Collections;
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
        #region instance
        //creates singleton to be accessed by other scripts
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
        #endregion
    }

    void Start()
    {
        //default variable values
        gameManager.currentCharacter = Character.Beep;
        puzzleActive = false;
        LevelResolved = false;
        blueCircuitResolved = false;
        greenCircuitResolved = false;
    }

    void Update()
    {
        //check if game is running (not with a puzzle on screen)
        if (!puzzleActive)
        {
            //check if player is switching characters (Key: Tab)
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //changes to Boop if it has energy
                if (gameManager.currentCharacter == Character.Beep && BoopController.boopController.energy > 0)
                {
                    gameManager.currentCharacter = Character.Boop;
                }
                //changes to Beep
                else if (gameManager.currentCharacter == Character.Boop)
                {
                    gameManager.currentCharacter = Character.Beep;
                }
            }
            //checks if the puzzles were resolved but Boop has no energy to complete level
            if (blueCircuitResolved && greenCircuitResolved && BoopController.boopController.energy == 0)
            {
                StartCoroutine(BoopReset());
            }
        }
    }

    private void UpdateCircuits()
    {
        //if both puzzles were resolved then level is resolved
        if (blueCircuitResolved && greenCircuitResolved) LevelResolved = true;
        else LevelResolved = false;
    }

    public void LoadLevel()
    {
        //loads the next level
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ResetLevel();
        }
        //loads the first level if player is in last level
        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            ResetLevel();
        }
    }

    public void RestartLevel()
    {
        //restarts the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetLevel();
    }

    private void ResetLevel()
    {
        //returns variable values to default values
        gameManager.currentCharacter = Character.Beep;
        puzzleActive = false;
        LevelResolved = false;
        blueCircuitResolved = false;
        greenCircuitResolved = false;
    }

    IEnumerator BoopReset()
    {
        //checks if Boop is recharging to avoid level reset due to no energy
        yield return new WaitForSeconds(1.5f);
        if (BoopController.boopController.energy == 0)
            RestartLevel();
    }
}

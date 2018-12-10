using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager canvasManager { get; private set; }

    [SerializeField] private Text energyLevel;
    [SerializeField] private GameObject puzzleBlue;
    [SerializeField] private CircuitBox circuitBlue;
    [SerializeField] private GameObject puzzleGreen;
    [SerializeField] private CircuitBox circuitGreen;

    private void Awake()
    {
        //allows other scripts to access the Canvas Manager
        canvasManager = this;
    }

    void Start()
    {
        //sets default variable values
        puzzleGreen.SetActive(false);
        puzzleBlue.SetActive(false);
        UpdateEnergy();
    }

    public void UpdateEnergy()
    {
        //updates Boop's energy
        energyLevel.text = BoopController.boopController.energy.ToString();
    }

    public void PopUpPuzzle(string color)
    {
        //displays puzzle
        if (color == "Blue")
        {
            puzzleBlue.SetActive(true);
            GameManager.gameManager.PuzzleActive = true;
        }
        else if (color == "Green")
        {
            puzzleGreen.SetActive(true);
            GameManager.gameManager.PuzzleActive = true;
        }
    }

    public void ResolvePuzzle(string color)
    {
        //sets puzzle as resolved, calls to show cables and returns to game
        if(color == "Blue")
        {
            GameManager.gameManager.BlueCircuitResolved = true;
            circuitBlue.TurnOn();
        }
        else if (color == "Green")
        {
            GameManager.gameManager.GreenCircuitResolved = true;
            circuitGreen.TurnOn();
        }
        puzzleGreen.SetActive(false);
        puzzleBlue.SetActive(false);
        GameManager.gameManager.PuzzleActive = false;
    }
}

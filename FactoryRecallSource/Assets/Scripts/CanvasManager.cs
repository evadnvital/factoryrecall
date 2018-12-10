using System.Collections;
using System.Collections.Generic;
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
        canvasManager = this;
    }

    // Use this for initialization
    void Start()
    {
        puzzleGreen.SetActive(false);
        puzzleBlue.SetActive(false);
        UpdateEnergy();
    }

    // Update is called once per frame
    public void UpdateEnergy()
    {
        energyLevel.text = BoopController.boopController.energy.ToString();
    }

    public void PopUpPuzzle(string color)
    {
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

using System.Collections;
using UnityEngine;

public class CircuitBox : MonoBehaviour
{
    //circuit color
    public enum Color
    {
        Blue, Green
    }

    public Color color;
    public bool isConnected;
    [SerializeField] private GameObject circuit;

    void Start()
    {
        //sets default variable values
        circuit.SetActive(false);
        isConnected = false;
    }

    private void OnTriggerStay(Collider other)
    {
        //checks if Beep is within reach of the circuit box
        if (other.GetComponent<BeepController>())
        {
            //if the current circuit puzzle is not resolved then calls the puzzle
            if (color == Color.Blue && !GameManager.gameManager.BlueCircuitResolved)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    CanvasManager.canvasManager.PopUpPuzzle(color.ToString());
                }
            }
            if (color == Color.Green && !GameManager.gameManager.GreenCircuitResolved)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    CanvasManager.canvasManager.PopUpPuzzle(color.ToString());
                }
            }
        }
    }

    public void TurnOn()
    {
        //shows the cables on the floor if puzzle is reslved
        if (color == Color.Blue && GameManager.gameManager.BlueCircuitResolved)
        {
            isConnected = true;
            circuit.SetActive(true);
            circuit.GetComponent<CircuitCable>().StartCharge();
        }
        else if (color == Color.Green && GameManager.gameManager.GreenCircuitResolved)
        {
            isConnected = true;
            circuit.SetActive(true);
            circuit.GetComponent<CircuitCable>().StartCharge();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if a cleaner robot passes by the circuit box resets puzzle
        if (other.GetComponent<Enemy>())
        {
            StartCoroutine(TurnOff());
        }
    }

    IEnumerator TurnOff()
    {
        //resets puzzle after timer
        yield return new WaitForSeconds(1f);

        isConnected = false;
        circuit.SetActive(false);
        if (color == Color.Blue)
        {
            GameManager.gameManager.BlueCircuitResolved = false;
        }
        else if (color == Color.Green)
        {
            GameManager.gameManager.GreenCircuitResolved = false;
        }
    }
}
